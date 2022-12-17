/*
	Esp32 Websockets Client

	This sketch:
        1. Connects to a WiFi network
        2. Connects to a Websockets server
        3. Sends the websockets server a message ("Hello Server")
        4. Prints all incoming messages while the connection is open

	Hardware:
        For this sketch you only need an ESP32 board.

	Created 15/02/2019
	By Gil Maimon
	https://github.com/gilmaimon/ArduinoWebsockets

*/

#include <ArduinoWebsockets.h>
#include <WiFi.h>

const char* ssid = "ServerNetwork_ID"; //Enter SSID
const char* password = "ServerNetwork_Password"; //Enter Password
const char* websockets_server_host = "ServerNetwork_IP"; //Enter server address
const uint16_t websockets_server_port = 8080; // Enter server port

bool Light = false;
int LED_BUILTIN = 2;

using namespace websockets;

WebsocketsClient client;
void setup() {
    Serial.begin(115200);
    pinMode(LED_BUILTIN, OUTPUT);
    // Connect to wifi
    WiFi.begin(ssid, password);

    // Wait some time to connect to wifi
    for(int i = 0; i < 10 && WiFi.status() != WL_CONNECTED; i++) {
        Serial.print(".");
        delay(1000);
    }

    // Check if connected to wifi
    if(WiFi.status() != WL_CONNECTED) {
        Serial.println("No Wifi!");
        return;
    }

    Serial.println("Connected to Wifi, Connecting to server.");
    // try to connect to Websockets server
    bool connected = client.connect(websockets_server_host, websockets_server_port, "/");
    if(connected) {
        Serial.println("Connected!");
        //client.send("Hello Server");
    } else {
        Serial.println("Not Connected!");
    }
    
    // run callback when messages are received
    client.onMessage([&](WebsocketsMessage message){
        char* command = "";
        Serial.println(message.data());
        if(message.data() == "clientLoginRefuse")
        {
          
        }
        else if(message.data() == "clientLoginRequest")
        {
          command = "{\"clientCommand\":\"clientLogin\",\"clientCredentials\":{\"Device\":\"ESP32\",\"IP\":\"192.168.15.13\",\"Identifier\":\"Arduno1\"}}";
          client.send(command);
        }
        else if(message.data() == "Arduno1TurnLightOn")
        {
          Serial.println("Arduno1TurnLightOn");
          Light = !Light;
          Serial.println(Light);
          digitalWrite(LED_BUILTIN, Light);
        }
    });
}

void loop() {
    // let the websockets client check for incoming messages
    if(client.available()) {
        client.poll();
    }
    delay(5000);
}