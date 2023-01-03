using Bid501Client.Proxies;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Bid501Client.Controllers
{
    /// <summary>
    /// This controller covers the Login and Bid501Form.
    /// </summary>
    public class Bid501Controller : IController
    {
        /// <summary>
        /// This clears the listbox selected item.
        /// </summary>
        ClearListbox_DEL clear_listbox;

        /// <summary>
        /// This is to update the form list.
        /// </summary>
        UpdateList_DEL update_form;

        /// <summary>
        /// This is used to refresh the bid form.
        /// </summary>
        RefreshForm_DEL refresh_form;

        /// <summary>
        /// This clears the login form of data.
        /// </summary>
        ClearLogin_DEL clear_login;

        /// <summary>
        /// This closes the login form.
        /// </summary>
        CloseLogin_DEL close_login;

        /// <summary>
        /// This is the list of products.
        /// </summary>
        public List<ProductProxy> ProductList = new();

        /// <summary>
        /// This is the list of credentials.
        /// </summary>
        public List<KeyValuePair<string, string>> CredentialsList = new();

        /// <summary>
        /// BidForm we are using
        /// </summary>
        public Bid501Form BidForm;

        /// <summary>
        /// This is the proxy database.
        /// </summary>
        public DatabaseProxy database;

        /// <summary>
        /// This is the connection to the Communication Controller.
        /// </summary>
        public ClientCommController CommController;

        /// <summary>
        /// This is the Username of the client.
        /// </summary>
        public string Username;

        /// <summary>
        /// This is the constructor of the Bid501Controller.
        /// </summary>
        public Bid501Controller(ClientCommController c)
        {
            CommController = c;
            database = new DatabaseProxy(ProductList, CredentialsList);
        }

        /// <summary>
        /// This is used to set the delegates
        /// </summary>
        /// <param name="cl">This is the ClearListbox_DEL.</param>
        public void SetConstructor1(ClearListbox_DEL cl, UpdateList_DEL u, RefreshForm_DEL r) { clear_listbox = cl; update_form = u; refresh_form = r; }

        /// <summary>
        /// This is a second set constructor to allow for other delegates to be initialized.
        /// </summary>
        /// <param name="c">This is the ClearLogin_DEL.</param>
        public void SetConstructor2(ClearLogin_DEL c, CloseLogin_DEL cl) { clear_login = c; close_login = cl; }

        /// <summary>
        /// This method handles the delegates from the controller to the view.
        /// </summary>
        public void HandleEvents(string s, object? o)
        {
            switch (s)
            {
                case "FILL_LIST":
                    UpdateDisplay(Convert.ToString(o));
                    break;
                case "SEND_BID":
                    if (o == null) MessageBox.Show("Can't send bid. Bid returns NULL");
                    else SendBid($"2,{Username}/" + Convert.ToString(o));
                    break;
                case "LOGIN":
                    if (CheckCredentials(Convert.ToString(o)) == false) InvalidCred();
                    else
                    {
                        close_login();
                        BidForm = new Bid501Form();
                        SetConstructor1(BidForm.ClearListbox, BidForm.UpdateList, BidForm.RefreshForm);
                        BidForm.ProductList = ProductList;
                        BidForm.handle_events = HandleEvents;
                        BidForm.Show();
                    }
                    break;
                case "ADD_PRODUCT":
                    AddProductToList(Convert.ToString(o));
                    break;
                case "SEND_PRODUCTS":
                    SendProducts();
                    break;
                case "SEND":
                    SendBid((string)o);
                    break;
                case "STOP_BIDDING":
                    StopBid((string)o);
                    break;
                case "RESET_LIST":
                    UpdateDisplay((string)o);
                    refresh_form();
                    break;
            }
        }

        /// <summary>
        /// This runs when the login fails.
        /// </summary>
        public void InvalidCred()
        {
            clear_login();
            MessageBox.Show("Invalid Credentials, Please Try Again");
        }

        /// <summary>
        /// This prepares the products to be sent throught the handle events delegate.
        /// </summary>
        public void SendProducts()
        {
            string productInfo;
            foreach (var product in ProductList)
            {
                if (product.Status == true) productInfo = $"1/{product.Name}/{Convert.ToString(product.Price)}/{product.Description}/{Convert.ToString(product.ID)}/T/{Convert.ToString(product.Client_ID)}";
                else productInfo = $"1/{product.Name}/{Convert.ToString(product.Price)}/{product.Description}/{Convert.ToString(product.ID)}/F/{Convert.ToString(product.Client_ID)}";

                HandleEvents("SEND", productInfo);
            }
        }

        /// <summary>
        /// This is the method to add products to the ProductList.
        /// </summary>
        /// <param name="product">This is the product to add.</param>
        public void AddProductToList(string product)
        {
            string[] split = product.Split("/");
            bool ToF = false;

            if (split[4] == "T") ToF = true;

            ProductList.Add(new ProductProxy(split[0], Convert.ToDouble(split[1]), split[2], Convert.ToInt32(split[3]), ToF, split[5]));
            database.Products.Add(new ProductProxy(split[0], Convert.ToDouble(split[1]), split[2], Convert.ToInt32(split[3]), ToF, split[5]));
        }

        /// <summary>
        /// This method checks if the entered credentials match the ones in the database.
        /// </summary>
        /// <returns>Returns if the credentials entered were correct or not.</returns>
        public bool CheckCredentials(string creds)
        {
            string[] split = creds.Split(",");
            string incoming_user = split[0];
            string incoming_pass = split[1];

            Username = incoming_user;

            foreach (KeyValuePair<string, string> pair in CredentialsList)
            {
                string check_user = pair.Key;
                string check_pass = pair.Value;

                if (incoming_user == check_user && incoming_pass == check_pass)
                {
                    CommController.SendMessage("4," + Username);
                    return true;
                }
            }
            
            return false;
        }

        /// <summary>
        /// Makes new account and adds it to the list
        /// </summary>
        /// <param name="creds">Credentials not split</param>
        public void MakeNewAccount(string input)
        {
            string[] creds = input.Split(",");
            database.CredentialsList.Add(new KeyValuePair<string, string>(creds[0], creds[1]));
            CommController.SendMessage("3," + input);
        }

        /// <summary>
        /// This method checks if an item has been won.
        /// </summary>
        public void ItemWon()
        {

        }

        /// <summary>
        /// This method updates the display of the view.
        /// </summary>
        public void UpdateDisplay(string input)
        {
            string[] product_stringList = input.Split(':');
            List<ProductProxy> temp = new();

            foreach(string product in product_stringList)
            {
                if(product != "")
                {
                    string[] product_info = product.Split('/');
                    bool b = false;

                    string item_name = product_info[0];
                    double item_price = Convert.ToDouble(product_info[1]);
                    string item_des = product_info[2];
                    int item_id = Convert.ToInt32(product_info[3]);
                    if (product_info[4] == "True") b = true;
                    string client_id = product_info[5];

                    temp.Add(new(item_name, item_price, item_des, item_id, b, client_id));
                }
            }

            ProductList.Clear();
            ProductList = temp;

            if(update_form != null) update_form(ProductList);
        }

        /// <summary>
        /// This closes the specific bid.
        /// </summary>
        /// <param name="s">This is the bid info.</param>
        public void StopBid(string s)
        {
            string[] product_info = s.Split('/');
            string item_name = product_info[0];

            foreach (ProductProxy p in ProductList) if (p.Name == item_name) p.Status = false;
            update_form(ProductList);
            clear_listbox();
            refresh_form();
        }

        /// <summary>
        /// This method handles the users bid.
        /// </summary>
        /// <param name="product_info">This is information for the product the user is bidding on.</param>
        /// <returns>Returns whether or not the bid goes through.</returns>
        public bool SendBid(string product_info) { return CommController.SendBid(product_info); }

        /// <summary>
        /// Messages organized based on catagory
        /// 1 = Username and Password
        /// 2 = Product
        /// 4 & 5 = update product list.
        /// 6 = handles closing a bid.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool MessageReceived(string message)
        {
            message = (string)JsonConvert.DeserializeObject(message);
            // Invoke is used to make sure that this is done in the GUI thread
            //Invoke(new Action(() => messageListBox.TopIndex = messageListBox.Items.Add(message)));
            string[] newMessage = message.Split(',');

            
            int catagory = Convert.ToInt32(newMessage[0]);

            switch (catagory)
            {
                case 1:
                    FillCredentialsList(newMessage[1]);
                    break;
                case 2:
                    HandleEvents("ADD_PRODUCT", message);
                    break;
                case 4:
                    HandleEvents("FILL_LIST", newMessage[4]);
                    MessageBox.Show(newMessage[1] + " has successfully bid on " + newMessage[2] + " at price $" + newMessage[3]);
                    clear_listbox();
                    break;
                case 5:
                    HandleEvents("FILL_LIST", newMessage[1]);
                    break;
                case 6:
                    HandleEvents("STOP_BIDDING", newMessage[1]);
                    break;
                case 7:
                    string[] product_info = newMessage[1].Split('/');
                    MessageBox.Show("You won " + product_info[0] + " for $" + product_info[1]);
                    break;
                case 8:
                    string[] split = newMessage[1].Split("/");
                    MessageBox.Show($"The Following Item is now off the market: {split[0]}");
                    break;
                case 9:
                    HandleEvents("RESET_LIST", newMessage[1]);
                    break;
                default:
                    break;
            }

            return true;
        }

        public void FillCredentialsList(string userInfo)
        {
            string[] split = userInfo.Split('/');
            int count = (split.Count() - 1) / 2;
            for (int i = 0; i < split.Count() - 1; i += 2)
            {
                CredentialsList.Add(new KeyValuePair<string, string>(split[i], split[i + 1]));
            }
        }

        /// <summary>
        /// This makes a string for input.
        /// </summary>
        /// <param name="s">this is the input string.</param>
        /// <param name="c"></param>
        /// <returns></returns>
        public string MakeInputString(string s)
        {
            string[] info1 = s.Split('/');
            string[] info2 = s.Split(',');
            string newLine = "";

            if(info1.Length > 2)
            {
                newLine += info1[0] + ",";
                for (int i = 1; i < info1.Length; i++) newLine += info1[i] + "/";
                return newLine;
            }
            else
            {
                newLine += info2[0] + ",";
                for (int i = 1; i < info2.Length; i++) newLine += info2[i] + "/";
                return newLine;
            }
        }
    }
}
