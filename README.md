# WS-esp32-Node-Windows-browser
Made a server with NodeJs. Using websocket, i connected a browser, a windows forms, and a esp32 module

Hello! This was a long study i had to myself.
I bought an ESP32 module, and i was playing with it, turning its lights, somehow getting shocked with a capacitor, doing stuff.

So, i made myself a challenge. To connect all devices on my house using only a server, to send data, to recieve data, to connect and transfer orders.

So i made this.

/////////
NodeJs side:

Just run "server.js" file. Make sure to be on the right network. Somehow i forgot about that in a occasion.

//////////
Esp32 Side:

Using Arduino IDE, connect a ESP32 module, if you connect other devices, you will need to change the script to the right Ports, and you'll need to install the right libraries.
Anyways, change the network configs, and this part is ready to go.

/////////
Browser side:
On the script, change the "localhost:8080" part to the address of your desire, or maintain this, you know.

/////////
Windows side:
Open the Form file, change de network address config, remember to change the address
