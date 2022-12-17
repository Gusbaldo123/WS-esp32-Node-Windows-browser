var http = require('http'), server;
var fs = require('fs');
var qs = require('querystring');

const command = require("./commands/command")

//Create http connection
server = http.createServer(function(req, res){
    //print html
    console.log("http connection");
    var contents = fs.readFileSync('contents.html');
	res.end(contents);

    if (req.method == 'POST') {
        var body = '';

        sockets.Arduino1.webSocket.send("Arduno1TurnLightOn");
        req.on('data', function (data) {
            body += data;

            // Too much POST data, kill the connection!
            // 1e6 === 1 * Math.pow(10, 6) === 1 * 1000000 ~~~ 1MB
            if (body.length > 1e6)
                {
                    req.destroy();
                    return;
                }
        });

        req.on('end', function () {
            var post = qs.parse(body);

            console.log(post)
        });
    }
});
server.listen(3000);

const WebSocket = require('ws');
const { debug } = require('console');

const wss = new WebSocket.Server({ port: 8080 })

var sockets = 
{
    "Computer1": null,
    "Browser1":null,
    "Arduino1":null
};
wss.on('connection', ws => {

  ws.send('clientLoginRequest');
  ws.on("error",function (err){
    console.log(err.message);
  })
  ws.on('message', function (message){
  if(!message) return;
  var jsonobj = JSON.parse(message); 
  command.commands(ws,sockets, message,jsonobj);
});
});

var standard_input = process.stdin;

standard_input.on('data', function(data) {
    if(!sockets) return;

    sockets.forEach(element => {
        console.log(element.clientLogin);
    });
    
    //Texto escrito no console
    let variable = data.toString().replace(/\n/, "").replace(/\r/, "");
    sockets.Arduino1.webSocket.send(variable);
});