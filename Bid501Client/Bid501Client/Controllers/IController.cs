using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bid501Client.Controllers
{
    public interface IController
    {
        /// <summary>
        /// This method updates the display of the view.
        /// </summary>
        public void UpdateDisplay(string o);

        /// <summary>
        /// This method handles the users bid.
        /// </summary>
        /// <param name="bid_price">This is the users bid.</param>
        /// <returns>Returns whether or not the bid goes through.</returns>
        public bool SendBid(string bid_price);
    }
}
