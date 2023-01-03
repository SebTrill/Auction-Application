using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bid501Client.Forms
{
    /// <summary>
    /// This is an enum to cover the state of the BID501Form.
    /// </summary>
    public enum Status
    {
        LOGIN,
        CHECK_CRED,
        MAIN_PAGE,
        ITEM_SELECT,
        BID_PLACED,
        WON_ITEM
    }
}
