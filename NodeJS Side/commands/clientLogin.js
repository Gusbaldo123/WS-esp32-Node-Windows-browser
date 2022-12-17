module.exports = {
    clientLogin: function (ws,sockets, clientLogin) 
    {
        if(clientLogin.Device == "Computer1")
        {
            console.log("Computer1 logged in");
            sockets.Computer1 = {"clientLogin": clientLogin, "webSocket":ws};
        }
        else if(clientLogin.Device == "Chrome")
        {
            console.log("Chrome logged in");
            sockets.Browser1 = {"clientLogin": clientLogin, "webSocket":ws};
        }
        else if(clientLogin.Device == "ESP32")
        {
            console.log("ESP32 logged in");
            sockets.Arduino1 = {"clientLogin": clientLogin, "webSocket":ws};
        }
    }
}