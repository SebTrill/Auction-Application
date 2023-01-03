using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bid501Server.Items;

namespace Bid501Server.Controllers
{
    public interface IServerController
    {
        /// <summary>
        /// This method updates the display of the view.
        /// </summary>
        public void UpdateDisplay(List<RealProduct> list);

        /// <summary>
        /// This method is for when the bidding stops on a product.
        /// </summary>
        public void StopBidding(string p);
    }
}
