using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bid501Library.Interfaces
{
    public interface IProduct
    {
        /// <summary>
        /// This sends the Name of the product from the server to the client or vice-versa.
        /// </summary>
        /// <returns>This is the Name to send.</returns>
        public string SendName();

        /// <summary>
        /// This sends the Price of the product from the server to the client or vice-versa.
        /// </summary>
        /// <returns>This is the Price to send.</returns>
        public double SendPrice();

        /// <summary>
        /// This sends the Description of the product from the server to the client or vice-versa.
        /// </summary>
        /// <returns>This is the Description to send.</returns>
        public string SendDescription();

        /// <summary>
        /// This sends the ID of the product from the server to the client or vice-versa.
        /// </summary>
        /// <returns>This is the ID to send.</returns>
        public int SendID();

        /// <summary>
        /// This sends the Status of the product from the server to the client or vice-versa.
        /// </summary>
        /// <returns>This is the Status to send.</returns>
        public bool SendStatus();
    }
}
