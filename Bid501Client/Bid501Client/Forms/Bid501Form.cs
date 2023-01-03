using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bid501Client.Proxies;

namespace Bid501Client
{
    public partial class Bid501Form : Form
    {
        /// <summary>
        /// This is the HandleEvents_DEL delegate.
        /// </summary>
        public HandleEvents_DEL handle_events;

        /// <summary>
        /// This is the list of products.
        /// </summary>
        public List<ProductProxy> ProductList;

        /// <summary>
        /// This is a list of the product names from the ProductList (products and their names should match their indices).
        /// </summary>
        public BindingList<string> ProductNamesList = new();

        /// <summary>
        /// Name of current Item selected
        /// </summary>
        public string CurrentProductName;

        /// <summary>
        /// This is the value of the bid that has been made.
        /// </summary>
        public double Bid;

        /// <summary>
        /// This is the number of bids.
        /// </summary>
        public int NumBids = 1;

        /// <summary>
        /// This is the Bid501Form constructor.
        /// </summary>
        public Bid501Form() { InitializeComponent(); }   

        /// <summary>
        /// This updates the list in this class from the constructor.
        /// </summary>
        /// <param name="list"></param>
        public void UpdateList(List<ProductProxy> list)
        {
            this.Invoke(new Action(() => { ProductList = list; }));
            this.Invoke(new Action(() => { ProductNamesList.Clear(); }));
            this.Invoke(new Action(() => { foreach (ProductProxy product in ProductList) ProductNamesList.Add(product.Name); }));
            this.Invoke(new Action(() => { ux_product_listbox.DataSource = ProductNamesList; }));
            this.Invoke(new Action(() => { Refresh(); }));

            int index = 0;
            this.Invoke(new Action(() => { index = ux_product_listbox.SelectedIndex; }));
            this.Invoke(new Action(() => { ux_product_listbox.ClearSelected(); }));
            this.Invoke(new Action(() => { ux_product_listbox.SelectedIndex = index; }));
        }

        /// <summary>
        /// This method sends the bid out.
        /// </summary>
        /// <param name="bid">This is the bid price.</param>
        public void SendBid(double bid) { handle_events("SEND_BID", CurrentProductName + ":" + bid.ToString()); }

        /// <summary>
        /// This clears the selected item in the listbox.
        /// </summary>
        public void ClearListbox()
        {
            int index = 0;
            this.Invoke(new Action(() => { index = ux_product_listbox.SelectedIndex; }));
            this.Invoke(new Action(() => { ux_product_listbox.ClearSelected(); }));
            this.Invoke(new Action(() => { ux_product_listbox.SelectedIndex = index; }));
        }

        /// <summary>
        /// This refreshes the form.
        /// </summary>
        public void RefreshForm() { this.Invoke(new Action(() => { Refresh(); })); }

        /// <summary>
        /// This is the handler for when the bid text is changed.
        /// </summary>
        /// <param name="sender">This is the texbox.</param>
        /// <param name="e">These are the arguments.</param>
        private void ux_bid_textbox_TextChanged(object sender, EventArgs e)
      {
            if (int.TryParse(ux_bid_textbox.Text, out int value))
            {
                ux_placeBid_button.Enabled = true;
                Bid = value;
            }
            else
            {
                ux_placeBid_button.Enabled = false;
                Bid = 0;
            }
        }

        /// <summary>
        /// This is the handler for Place Bid button is clicked.
        /// </summary>
        /// <param name="sender">This is the button.</param>
        /// <param name="e">These are the arguments.</param>
        private void ux_placeBid_button_Click(object sender, EventArgs e)
        {
            if(ux_product_listbox.SelectedIndex != -1)
            {
                ProductProxy p = ProductList[ux_product_listbox.SelectedIndex];

                if (Bid > p.Price) { SendBid(Bid); ux_bid_textbox.Clear(); }
                else MessageBox.Show("Not a valid bid offer");
            }
        }

        /// <summary>
        /// This is the handler for when the Bid501Form is opened.
        /// </summary>
        /// <param name="sender">This is the form.</param>
        /// <param name="e">These are the arguments.</param>
        private void OnOpenForm(object sender, EventArgs e)
        {
            UpdateList(ProductList);
            ux_product_listbox.DataSource = ProductNamesList;
            handle_events("SEND_PRODUCTS", "");
        }

        /// <summary>
        /// This event covers the Selected Index Changed event.
        /// </summary>
        /// <param name="sender">This is the textbox.</param>
        /// <param name="e">These are the arguments.</param>
        private void ux_product_listbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ux_product_listbox.SelectedIndex != -1)
            {
                ProductProxy p = ProductList[ux_product_listbox.SelectedIndex];
                CurrentProductName = p.Name;
                ux_item_name.Text = "Item Name: " + p.Name;
                ux_descriptionLabel.Text = p.Description;
                ux_timer_label.Text = "Timer Countdown: 22 Hours";

                if (p.Status == true)
                {
                    ux_status_label.Text = "Status: Auction Ongoing";
                    ux_bid_textbox.Enabled = true;
                }
                else
                {
                    ux_status_label.Text = "Status: Auction Closed";
                    ux_bid_textbox.Enabled = false;
                }

                ux_minimum_bid.Text = "Minimum Bid: $" + p.Price;
            }
        }
    }
}
