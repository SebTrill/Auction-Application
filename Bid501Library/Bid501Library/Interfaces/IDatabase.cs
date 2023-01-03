using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bid501Library.Interfaces
{
    public interface IDatabase
    {
        /// <summary>
        /// This sends the Product List of the product from the server to the client or vice-versa.
        /// </summary>
        /// <returns>This is the Product List to send.</returns>
        public List<IProduct> SendProductList();

        /// <summary>
        /// This sends the Credentials List of the product from the server to the client or vice-versa.
        /// </summary>
        /// <returns>This is the Credentials List to send.</returns>
        public List<string> SendCredentialsList();

        /// <summary>
        /// This updates the current Product List.
        /// </summary>
        public void UpdateProductList();
    }
}
