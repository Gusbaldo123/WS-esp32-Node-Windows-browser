module.exports = {
    commands: function (ws,sockets,message, jsonobj) {
        function Missformat()
        {
            console.log("Wrong format, breaking connection...");
            ws.send('clientLoginRefuse');
            ws.close();
        }

        if(!jsonobj.clientCredentials)
        {
            Missformat();
            return;
        }
        if(!jsonobj.clientCredentials.Device || !jsonobj.clientCredentials.IP || !jsonobj.clientCredentials.Identifier)
        {
            Missformat();
            return;
        }

        if(jsonobj.clientCommand == "clientLogin")
        {
            require('./clientLogin').clientLogin(ws,sockets, jsonobj.clientCredentials);
            
        }
        else if(jsonobj.clientCommand == "clientTerminate")
        {
            require('./clientTerminate').clientTerminate(ws, jsonobj.clientCredentials);
        }
        else if(jsonobj.clientCommand == "Arduno1TurnLightOn")
        {
            sockets.Arduino1.webSocket.send(jsonobj.clientCommand);
        }
        else
        {
            Missformat();
            return;
        }
    }
}