using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bid501Client.Proxies
{
    /// <summary>
    /// This is a proxy of the database from the server.
    /// </summary>
    public class DatabaseProxy
    {
        /// <summary>
        /// This is the list of products.
        /// </summary>
        public List<ProductProxy> Products = new();

        /// <summary>
        /// This is the list of credentials.
        /// </summary>
        public List<KeyValuePair<string, string>> CredentialsList = new();

        /// <summary>
        /// This is the constructor for the database.
        /// </summary>
        /// <param name="products">This is the list of products.</param>
        /// <param name="credentialsList">This is the list of credentials.</param>
        public DatabaseProxy(List<ProductProxy> products, List<KeyValuePair<string, string>> credentialsList)
        {
            Products = products;
            CredentialsList = credentialsList;
        }

        /// <summary>
        /// This method updates the list of products.
        /// </summary>
        public void UpdateProductList()
        {

        }
    }
}
