using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp.Server;
using WebSocketSharp;

namespace Bid501Server.Items
{
    public class ServerDatabase : WebSocketBehavior
    {
        /// <summary>
        /// This is the list of products.
        /// </summary>
        public List<RealProduct> Products = new();

        /// <summary>
        /// This is the list of credentials.
        /// </summary>
        public List<KeyValuePair<string, string>> CredentialsList = new();

        /// <summary>
        /// Server to create proxy
        /// </summary>
        public WebSocketServer Server;

        /// <summary>
        /// This is the constructor for the database.
        /// </summary>
        /// <param name="products">This is the list of products.</param>
        /// <param name="credentialsList">This is the list of credentials.</param>
        public ServerDatabase()
        {
            ReadCredentialsFile();
            ReadProductsFile();
        }

        /// <summary>
        /// This contains what to do when a message happens.
        /// </summary>
        /// <param name="e">These are the arguments.</param>
        protected override void OnMessage(MessageEventArgs e)
        {
            string msg = e.Data;
        }

        /// <summary>
        /// This method reads from the Credentials.txt file.
        /// </summary>
        public void ReadCredentialsFile()
        {
            using (StreamReader sr = new StreamReader("Credentials.txt"))
            {
                string line;
                string username;
                string password;
    
                // Read and display lines from the file until the end of
                // the file is reached.
                while ((line = sr.ReadLine()) != null)
                {
                    string[] splitCredentials = line.Split(',');
                    username = splitCredentials[0];
                    password = splitCredentials[1];
                    CredentialsList.Add(new KeyValuePair<string, string>(username, password));
                }
            }
        }

        /// <summary>
        /// This method reads Products from the .txt file.
        /// </summary>
        public void ReadProductsFile()
        {
            using (StreamReader sr = new StreamReader("Products.txt"))
            {
                string line;
                bool onSale;
                RealProduct p = new RealProduct();

                // Read and display lines from the file until the end of
                // the file is reached.
                while ((line = sr.ReadLine()) != null)
                {
                    // Sessions.SendTo(ID, ($"2/{line}"));
                    string[] split = line.Split('/');

                    if (split[4] == "T") onSale = true;
                    else onSale = false;

                    Products.Add(new RealProduct(split[0], Convert.ToDouble(split[1]), split[2], Convert.ToInt32(split[3]), onSale, ""));
                }
            }
        }
    }
}
