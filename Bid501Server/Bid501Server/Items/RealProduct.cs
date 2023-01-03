using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bid501Server.Items
{
    public class RealProduct
    {
        /// <summary>
        /// This is the name of the product.
        /// </summary>
        public string Name;

        /// <summary>
        /// This is the price of the product.
        /// </summary>
        public double Price;

        /// <summary>
        /// This is the description of the product.
        /// </summary>
        public string Description;

        /// <summary>
        /// This is the ID of the product.
        /// </summary>
        public int ID;

        /// <summary>
        /// This is the status of the product.
        /// </summary>
        public bool Status;

        /// <summary>
        /// This is the clients ID.
        /// </summary>
        public string Client_ID;

        /// <summary>
        /// This is the constructor for the product.
        /// </summary>
        /// <param name="name">This is the name of the product.</param>
        /// <param name="price">This is the price of the product.</param>
        /// <param name="description">This is the description of the product.</param>
        /// <param name="id">This is the ID of the product.</param>
        /// <param name="status">This is the status of the product.</param>
        /// <param name="id">This is the status of the product.</param>
        public RealProduct(string name, double price, string description, int cid, bool status, string id)
        {
            Name = name;
            Price = price;
            Description = description;
            ID = cid;
            Status = status;
            Client_ID = id;
        }

        /// <summary>
        /// This will be the default constructor.
        /// </summary>
        public RealProduct()
        {
            Name = "Test";
            Price = 0.00;
            Description = "Test Desc";
            ID = 666;
            Status = true;
            Client_ID = "";
        }
    }
}
