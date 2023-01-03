using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using WebSocketSharp;
namespace Bid501Client.Controllers
{
    /// <summary>
    /// This controller connects to the JSON Library.
    /// </summary>
    public class ClientCommController : IController
    {
        /// <summary>
        /// This is the name of the ClientCommController.
        /// </summary>
        private string name;

        /// <summary>
        /// This is the WebSocket that we are using.
        /// </summary>
        public WebSocket ws;

        /// <summary>
        /// This is the Message Received event.
        /// </summary>
        public event Message MessageReceived;

        /// <summary>
        /// This is the constructor for the ClientCommController    
        /// </summary>
        public ClientCommController() { }

        /// <summary>
        /// This is to set the Client communication constructor.
        /// </summary>
        /// <param name="ws">This is the connection to the websocket.</param>
        public void SetConstructor(WebSocket ws)
        {
            name = "";
            this.ws = ws;
            ws.OnMessage += (sender, e) => { if (MessageReceived != null) MessageReceived(e.Data); };
        }

        /// <summary>
        /// This method updates the display of the view.
        /// </summary>
        public void UpdateDisplay(string o)
        {

        }

        public void SendMessage(string msg)
        {
            string json = JsonConvert.SerializeObject(msg);
            ws.Send(json);
        }

        /// <summary>
        /// This method handles the users bid.
        /// </summary>
        /// <param name="bid_info">This is the users bid info.</param>
        /// <returns>Returns whether or not the bid goes through.</returns>
        public bool SendBid(string bid_info)
        {
            // Send the message to the server if connection is alive
            if (ws.IsAlive)
            {
                bid_info = JsonConvert.SerializeObject(bid_info);
                ws.Send(bid_info);
                return true;
            }
            else return false;
        }
    }
}
