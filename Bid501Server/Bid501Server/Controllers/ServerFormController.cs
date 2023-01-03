using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bid501Server.Items;
using WebSocketSharp.Server;
using WebSocketSharp;
using System.ComponentModel;
using Newtonsoft.Json;

namespace Bid501Server.Controllers
{
    public class ServerFormController : WebSocketBehavior, IServerController
    {
        /// <summary>
        /// This is a delegate to update the lists on other forms.
        /// </summary>
        public UpdateList_DEL update_list;

        /// <summary>
        /// This closes the bid when the StopBidding button is clicked.
        /// </summary>
        public CloseBid_DEL close_bid;

        /// <summary>
        /// This updates the client list in the form.
        /// </summary>
        public UpdateClients_DEL update_clients;

        /// <summary>
        /// this clears the data in login form.
        /// </summary>
        public ClearLogin_DEL clear_login;

        /// <summary>
        /// This closes the login form.
        /// </summary>
        public CloseLogin_DEL close_login;

        /// <summary>
        /// This sends the new list to the client.
        /// </summary>
        public SendNewProductList_DEL send_list;

        /// <summary>
        /// This is the list of products.
        /// </summary>
        public List<RealProduct> ProductList = new();

        /// <summary>
        /// This is a temp list of products.
        /// </summary>
        public List<RealProduct> Temp_List = new();

        /// <summary>
        /// This is the index of the item being modified.
        /// </summary>
        public int ProductIndex;

        /// <summary>
        /// This is the list of client names.
        /// </summary>
        public BindingList<string> ClientNames = new();

        /// <summary>
        /// This is the list of client names.
        /// </summary>
        public List<string> ClientIDs = new();

        /// <summary>
        /// This is the list of credentials.
        /// </summary>
        public List<KeyValuePair<string, string>> CredentialsList = new();

        /// <summary>
        /// This is the number of clients currently on the server.
        /// </summary>
        public int NumberClients = 0;

        /// <summary>
        /// This is the server database.
        /// </summary>
        public ServerDatabase Database;

        /// <summary>
        /// Server to create proxy
        /// </summary>
        public WebSocketServer Server;

        /// <summary>
        /// This holds a temp username.
        /// </summary>
        public string Temp_Username;

        /// <summary>
        /// This holds a temp product name.
        /// </summary>
        public string Temp_ProductName;

        /// <summary>
        /// This holds a temp bid price.
        /// </summary>
        public string Temp_BidPrice;

        /// <summary>
        /// This is the constructor of the ServerFormController.
        /// </summary>
        public ServerFormController(ServerDatabase d)
        {
            Database = d;
            Server = d.Server;
            CredentialsList = d.CredentialsList;
        }

        /// <summary>
        /// This method handles the delegates from the controller to the view.
        /// </summary>
        public void HandleEvents(string s, object? o)
        {
            switch (s)
            {
                case "ADD_FORM":
                    AddProductForm apf = new();
                    apf.SetConstructor(AddProduct);
                    apf.Show();
                    break;
                case "MODIFY_FORM":
                    if(o == null) MessageBox.Show("No item selected");
                    else
                    {
                        RealProduct p = new();
                        foreach (RealProduct item in ProductList) if ((string)o == item.Name) p = item;

                        ModifyProductForm mpf = new(p);
                        mpf.SetConstructor(ModifyProduct);

                        int i = 0;
                        foreach(RealProduct item in ProductList)
                        {
                            if (item == o) ProductIndex = i;
                            else i++;
                        }
                            

                        mpf.Show();
                    }
                    break;
                case "LOCAL_PRODUCT":
                    AddProductToDatabase(o.ToString());
                    break;
                case "BID":
                    RecieveBid(o.ToString());
                    break;
                case "NEWACC":
                    string[] s2 = Convert.ToString(o).Split(",");
                    Database.CredentialsList.Add(new KeyValuePair<string, string>(s2[1], s2[2]));
                    break;
                case "STOP_BIDDING":
                    if(o != null) StopBidding((string)o);
                    break;
                case "CLIENT_ID":
                    HandleClientNames((string)o);
                    break;
            }
        }

        /// <summary>
        /// This sets the server form constructor first.
        /// </summary>
        /// <param name="u">This is the UpdateList_DEL from the ServerForm.</param>
        public void SetConstructor1(UpdateList_DEL u, UpdateClients_DEL c) { update_list = u; update_clients = c; }

        /// <summary>
        /// This sets the server form constructor second.
        /// </summary>
        /// <param name="c">This is the CloseBid_DEL from the Comm Controller.</param>
        public void SetConstructor2(CloseBid_DEL c, SendNewProductList_DEL s) { close_bid = c; send_list = s; }

        /// <summary>
        /// This is used to connect the delegates from the login form.
        /// </summary>
        public void SetConstructor3(ClearLogin_DEL cl, CloseLogin_DEL c) { clear_login = cl; close_login = c; }

        /// <summary>
        /// This moves the list to the update display method.
        /// </summary>
        /// <param name="list">This is the list to move.</param>
        public void MoveList(List<RealProduct> list) { UpdateDisplay(list); }

        /// <summary>
        /// This handles the login.
        /// </summary>
        /// <param name="s">This is the incoming users information.</param>
        /// <returns>returns whether or not the credentials are correct.</returns>
        public bool Login(string s)
        {
            string[] creds = s.Split(',');
            string incoming_user = creds[0];
            string incoming_pass = creds[1];

            if(incoming_user == "admin")
            {
                foreach (KeyValuePair<string, string> pair in CredentialsList)
                {
                    string check_user = pair.Key;
                    string check_pass = pair.Value;

                    if (incoming_user == check_user && incoming_pass == check_pass)
                    {
                        clear_login();
                        close_login();

                        ServerForm form = new();
                        SetConstructor1(form.UpdateList, form.UpdateClients);
                        form.SetConstructor(HandleEvents, SendClientNameList);

                        form.Show();

                        return true;
                    }
                }
            }

            clear_login();
            return false;
        }

        /// <summary>
        /// This connects the usernames to the client ids.
        /// </summary>
        /// <param name="s">this is the input.</param>
        public void HandleClientNames(string s)
        {
            string[] split = s.Split(",");
            string username = split[1];

            ClientNames.Add(username);
        }

        /// <summary>
        /// This send the list of client names to the server form.
        /// </summary>
        /// <returns>This is the list of names.</returns>
        public BindingList<string> SendClientNameList() { return ClientNames; }

        /// <summary>
        /// This makes a string of the product list to send to the client.
        /// </summary>
        /// <returns>This is the string to return.</returns>
        public string CreateProductListString4Bid()
        {
            string list_string = "4," + Temp_Username + "," + Temp_ProductName + "," + Temp_BidPrice + ",";

            foreach(RealProduct p in ProductList)
            {
                list_string += p.Name + "/" + p.Price.ToString() + "/" + p.Description + "/" + p.ID.ToString() + "/" + p.Status.ToString() + "/" + p.Client_ID.ToString();
                list_string += ":";
            }

            return list_string;
        }

        /// <summary>
        /// This makes a string of the product list to send to the client.
        /// </summary>
        /// <returns>This is the string to return.</returns>
        public string CreateProductListString4OnOpen()
        {
            string list_string = "5,";

            foreach (RealProduct p in ProductList)
            {
                list_string += p.Name + "/" + p.Price.ToString() + "/" + p.Description + "/" + p.ID.ToString() + "/" + p.Status.ToString() + "/" + p.Client_ID.ToString();
                list_string += ":";
            }

            return list_string;
        }

        /// <summary>
        /// This adds a client to the list of client names when a client joins the server.
        /// </summary>
        public void AddClient(List<string> ids)
        {
            ClientIDs.Clear();
            foreach(string id in ids)
            {
                ClientIDs.Add(id); 
                NumberClients++;
            }
        }

        /// <summary>
        /// Method to RecieveBid
        /// </summary>
        /// <param name="bid">This is the bid to recieve.</param>
        public void RecieveBid(string bid)
        {
            string[] split1 = bid.Split(",");
            string[] split2 = split1[1].Split('/');
            string[] bid_info = split2[1].Split(':');

            string ID = split1[0];
            string username = split2[0];
            string product_name = bid_info[0];
            double incoming_bid = Convert.ToDouble(bid_info[1]);

            Temp_Username = username;
            Temp_ProductName = product_name;
            Temp_BidPrice = incoming_bid.ToString();

            foreach (RealProduct r in ProductList) if(r.Name == product_name)
                {
                    r.Price = incoming_bid;

                    int i = 0;
                    int index = 0;
                    foreach(string s in ClientNames)
                    {
                        if (s == username) index = i;
                        else i++;
                    }

                    r.Client_ID = ClientIDs[index];
                }
        }

        /// <summary>
        /// Method to add product to database if not already excisted
        /// </summary>
        /// <param name="product">product to add</param>
        public void AddProductToDatabase(string product)
        {
            string[] split = product.Split("/");
            RealProduct r;

            if (split[5] == " T")  r = new RealProduct(split[1], Convert.ToDouble(split[2]), split[3], Convert.ToInt32(split[4]), true, "");
            else r = new RealProduct(split[1], Convert.ToDouble(split[2]), split[3], Convert.ToInt32(split[4]), false, "");

            if (!ProductList.Contains(r)) ProductList.Add(r);
            UpdateDisplay(ProductList);
        }

        /// <summary>
        /// This adds a product to the list of products.
        /// </summary>
        public void AddProduct(RealProduct P)
        {
            ProductList.Add(P);
            UpdateDisplay(ProductList);
            if(send_list != null) send_list(ProductList);
        }

        /// <summary>
        /// This modifies a product in the list of products.
        /// </summary>
        public void ModifyProduct(RealProduct p)
        {
            ProductList[ProductIndex] = p;
            UpdateDisplay(ProductList);
            if (send_list != null) send_list(ProductList);
        }

        /// <summary>
        /// This updates the lists that we see on the forms.
        /// </summary>
        public void UpdateDisplay(List<RealProduct> list) { update_list(list); }

        /// <summary>
        /// This sends the full credentials list to the client.
        /// </summary>
        public void SendCredentials() 
        {
            foreach (KeyValuePair<string, string> cred in Database.CredentialsList)
            {
                string msg = JsonConvert.SerializeObject($"1/{cred.Key}/{cred.Value}");
                Sessions.SendTo(ID, msg);
            }
        }

        /// <summary>
        /// This method sends the list of products to the client.
        /// </summary>
        public void SendProducts()
        {
            foreach(RealProduct p in Database.Products)
            {
                string state = "";

                if (p.Status == true) state = "T";
                else state = "F";

                string msg = JsonConvert.SerializeObject($"2/{p.Name}/{p.Price}/{p.Description}/{p.ID}/{state}/{p.Client_ID}");

                Sessions.SendTo(ID, msg);
            }
        }

        /// <summary>
        /// This makes a string of the product list to send to the client.
        /// </summary>
        /// <returns>This is the string to return.</returns>
        public string CreateProductListString4StopBidding(RealProduct p)
        {
            string list_string = "6,";
            list_string += p.Name + "/" + p.Price.ToString() + "/" + p.Description + "/" + p.ID.ToString() + "/false/" + p.Client_ID.ToString();

            return list_string;
        }

        /// <summary>
        /// This method is for when the bidding stops on a product.
        /// </summary>
        public void StopBidding(string p)
        {
            foreach(RealProduct p2 in ProductList)
            {
                if (p2.Name == p)
                {
                    p2.Status = false;
                    close_bid(CreateProductListString4StopBidding(p2));
                }
            }
                
        }
    }
}
