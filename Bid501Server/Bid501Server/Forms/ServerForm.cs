using Bid501Server.Items;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bid501Server
{
    public partial class ServerForm : Form
    {
        /// <summary>
        /// This is the HandleEvents_DEL delegate.
        /// </summary>
        public HandleEvents_DEL handle_events;

        /// <summary>
        /// This brings the client names list from the controller to the form.
        /// </summary>
        public SendClientNameList_DEL send_clients;

        /// <summary>
        /// This is the list of Client ID's.
        /// </summary>
        public BindingList<string> ClientNameList = new();

        /// <summary>
        /// This is the list of products.
        /// </summary>
        public List<RealProduct> ProductList = new();

        /// <summary>
        /// List of the product names, corresponds with the list of products exactly
        /// </summary>
        public BindingList<string> ProductNamesList = new();

        /// <summary>
        /// This is the ServerForm constructor.
        /// </summary>
        public ServerForm() { InitializeComponent(); }

        /// <summary>
        /// This sets the server form constructor.
        /// </summary>
        /// <param name="h">This is the HandleEvents_DEL from the ServerFormController.</param>
        public void SetConstructor(HandleEvents_DEL h, SendClientNameList_DEL s) { handle_events = h; send_clients = s; }

        /// <summary>
        /// This updates the list.
        /// </summary>
        public void UpdateList(List<RealProduct> list)
        {
            ProductList.Clear();
            ProductNamesList.Clear();

            foreach(RealProduct product in list)
            {
                ProductList.Add(product);
                ProductNamesList.Add(product.Name);
            }
        }

        /// <summary>
        /// This updates the client list.
        /// </summary>
        public void UpdateClients()
        {
            this.Invoke(new Action(() => { ClientNameList = send_clients(); }));
            this.Invoke(new Action(() => { Refresh(); }));
            this.Invoke(new Action(() => { ux_clients_listbox.Items.Add(ClientNameList[ClientNameList.Count - 1]); }));
        }

        /// <summary>
        /// This is the handler for Add Product button is clicked.
        /// </summary>
        /// <param name="sender">This is the button.</param>
        /// <param name="e">These are the arguments.</param>
        private void ux_add_button_Click(object sender, EventArgs e) { handle_events("ADD_FORM", null); }

        /// <summary>
        /// This is the handler for Modify Product button is clicked.
        /// </summary>
        /// <param name="sender">This is the button.</param>
        /// <param name="e">These are the arguments.</param>
        private void ux_modify_button_Click(object sender, EventArgs e)
        {
            if(ux_product_listbox.SelectedItem != null) handle_events("MODIFY_FORM", ux_product_listbox.SelectedItem);
            else handle_events("MODIFY_FORM", null);
        }

        /// <summary>
        /// This is the handler for when the ServerForm is opened.
        /// </summary>
        /// <param name="sender">This is the form.</param>
        /// <param name="e">These are the arguments.</param>
        private void OnOpenForm(object sender, EventArgs e)
        {
            ux_product_listbox.DataSource = ProductNamesList;
        }

        /// <summary>
        /// This is the button for stopping a bid.
        /// </summary>
        /// <param name="sender">This is the stop bidding button.</param>
        /// <param name="e">These are the arguments.</param>
        private void ux_stopBiddingButton_Click(object sender, EventArgs e)
        {
            if (ux_product_listbox.SelectedItem != null) handle_events("STOP_BIDDING", ux_product_listbox.SelectedItem);
            else MessageBox.Show("No item selected.");
        }
    }
}