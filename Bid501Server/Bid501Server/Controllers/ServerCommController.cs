using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebSocketSharp;
using WebSocketSharp.Server;
using Bid501Server.Items;
using Newtonsoft.Json;

namespace Bid501Server.Controllers
{
    public class ServerCommController : WebSocketBehavior, IServerController
    {
        /// <summary>
        /// This is the server name.
        /// </summary>
        private string name = "server";

        /// <summary>
        /// This is the connection to the ServerFormController.
        /// </summary>
        public ServerFormController ServerFormControl;

        /// <summary>
        /// This is the delegate to update the server form list.
        /// </summary>
        public MoveList_DEL move_list;

        /// <summary>
        /// This is the HandleEvents_DEL in the ServerFormController.
        /// </summary>
        public HandleEvents_DEL handle;

        /// <summary>
        /// This is the constructor for the ServerCommController    
        /// </summary>
        public ServerCommController() { }

        /// <summary>
        /// This handles specific events and sends information through the handle delegate.
        /// </summary>
        /// <param name="input"></param>
        public void Handle_Events(string input)
        {
            string[] split = input.Split(",");
            switch (split[0])
            {
                case "1":
                    handle("LOCAL_PRODUCT", input);
                    break;
                case "2":
                    handle("BID", input);
                    string msg = ServerFormControl.CreateProductListString4Bid();
                    msg = JsonConvert.SerializeObject(msg);
                    Sessions.Broadcast(msg);
                    break;
                case "3":
                    handle("NEWACC", input);
                    break;
                case "4":
                    handle("CLIENT_ID", input);
                    ServerFormControl.update_clients();
                    int a = ServerFormControl.ClientNames.Count();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// This updates the server display.
        /// </summary>
        public void UpdateDisplay(List<RealProduct> list) { move_list(list); }

        /// <summary>
        /// This closes the bid.
        /// </summary>
        /// <param name="s">This is the bid info.</param>
        public void CloseBid(string s)
        {
            string[] split = s.Split(',');
            string[] product_info = split[1].Split('/');
            s = JsonConvert.SerializeObject(s);
            Sessions.Broadcast(s);

            string second_message = "7," + split[1];
            second_message = JsonConvert.SerializeObject(second_message);
            string LosingMessage = $"8,{split[1]}";
            LosingMessage = JsonConvert.SerializeObject(LosingMessage);
            Sessions.SendTo(product_info[5], second_message);
            foreach(string id in Sessions.IDs)
            {
                if(id != product_info[5])
                {
                    Sessions.SendTo(id, LosingMessage);
                }
            }
        }

        /// <summary>
        /// This sends the new product list out to the clients.
        /// </summary>
        /// <param name="list">This is the list to send.</param>
        public void SendNewProductList(List<RealProduct> list)
        {
            string input = MakeNewListString(list);
            input = JsonConvert.SerializeObject(input);
            Sessions.Broadcast(input);
        }

        /// <summary>
        /// This sets up a string from the product list so we can send them to the clients.
        /// </summary>
        /// <param name="list">This is the list to convert.</param>
        /// <returns>Returns a string to send tot he clients.</returns>
        public string MakeNewListString(List<RealProduct> list)
        {
            string temp = "9,";

            foreach(RealProduct p in list)
            {
                temp += p.Name + "/" + p.Price.ToString() + "/" + p.Description + "/" + p.ID.ToString() + "/" + p.Status.ToString() + "/" + p.Client_ID.ToString();
                temp += ":";
            }

            return temp;
        }

        /// <summary>
        /// This contains what to do when the server is opened.
        /// </summary>
        protected override void OnOpen()
        {
            ServerFormControl.AddClient((List<string>)Sessions.IDs);

            string allCreds = "1,";
            foreach(KeyValuePair<string, string> cred in ServerFormControl.Database.CredentialsList)
            {
                string newCred = cred.Key + "/" + cred.Value + "/";
                allCreds += newCred;
            }
            allCreds = JsonConvert.SerializeObject(allCreds);
            Sessions.SendTo(ID, allCreds);

            string temp = ServerFormControl.CreateProductListString4OnOpen();
            temp = JsonConvert.SerializeObject(temp);
            Sessions.Broadcast(temp);
        }

        /// <summary>
        /// This contains what to do when a message happens.
        /// </summary>
        /// <param name="e">These are the arguments.</param>
        protected override void OnMessage(MessageEventArgs e)
        {
            string msg = e.Data;
            msg = (string)JsonConvert.DeserializeObject(msg);
            Handle_Events(msg);
        }

        /// <summary>
        /// This method is for when the bidding stops on a product.
        /// </summary>
        public void StopBidding(string p)
        {
            //p.Status = false;
        }
    }
}
