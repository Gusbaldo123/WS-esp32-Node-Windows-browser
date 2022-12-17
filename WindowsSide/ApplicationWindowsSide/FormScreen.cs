using Newtonsoft.Json;
using System;
using System.Windows.Forms;
using WebSocketSharp;

namespace ApplicationWindowsSide
{
    public partial class form_ApplicationWindowsSide : Form
    {
        public form_ApplicationWindowsSide()
        {
            InitializeComponent();
            InitializeWebSocket();
        }

        WebSocket ws;
        string credentials = "\"clientCredentials\":{\"Device\":\"Computer1\",\"IP\":\"YOUR_ADDRESS\",\"Identifier\":\"ChompPanel\"}";
        string connection = "ws://localhost:8080";//SERVER_ADDRESS
        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateButtons();
            if (ws.IsAlive) return;
            InitializeWebSocket();
        }

        void UpdateButtons()
        {
            bt_InitializeConnection.Enabled = !ws.IsAlive;
            bt_SendLightSignal.Enabled = ws.IsAlive;
            bt_TerminateConnection.Enabled = ws.IsAlive;
        }
        void InitializeWebSocket()
        {
            ws = new WebSocket(connection);
            ws.OnOpen += (sender, e) =>
            { 
                //Connect
            };
            ws.OnMessage += (sender, e) => 
            {
                string command = "";
                switch (e.Data)
                {
                    case "clientLoginRefuse":
                        ConnectionRefuse();
                        return;
                        break;
                    case "clientLoginRequest":
                        command = GETClientCommand("clientLogin");
                        break;
                }
                ws.Send(command);
            };

            ws.OnError += (sender, e) =>
            {
                ws.Send(GETClientCommand("clientError"));
            };

            ws.Connect();

            UpdateButtons();
        }

        string GETClientCommand(string command)
        {
            UpdateButtons();

            string Json = "{\"clientCommand\":\"";
            Json += command;
            Json += "\"," + credentials + "}";
            return Json;
        }
        void ConnectionRefuse()
        {
            MessageBox.Show("Connection Refused");
            UpdateButtons();
        }

        private void bt_SendLightSignal_Click(object sender, EventArgs e)
        {
            UpdateButtons();
            ws.Send(GETClientCommand("Arduno1TurnLightOn"));
        }

        private void bt_TerminateConnection_Click(object sender, EventArgs e)
        {
            UpdateButtons();
            if (!ws.IsAlive) return;
            ws.Send(GETClientCommand("clientTerminate"));
            ws.Close();
        }

        private void bt_InitializeConnection_Click(object sender, EventArgs e)
        {
            UpdateButtons();
            if (ws.IsAlive) return;
            InitializeWebSocket();
        }
    }
}
