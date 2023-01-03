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
    public partial class AddProductForm : Form
    {
        /// <summary>
        /// This is the Add_SF_DEL delegate.
        /// </summary>
        Add_SF_DEL add_delegate;

        /// <summary>
        /// This is the list of products.
        /// </summary>
        public List<RealProduct> ProductList = new();

        /// <summary>
        /// List of the product names, corresponds with the list of products exactly
        /// </summary>
        public List<string> ProductNamesList = new();

        /// <summary>
        /// This is the AddProductForm constructor.
        /// </summary>
        public AddProductForm() { InitializeComponent(); }

        /// <summary>
        /// This sets the values of the delegate(s).
        /// </summary>
        /// <param name="a">This is the Add_SF_DEL delegate.</param>
        public void SetConstructor(Add_SF_DEL a) { add_delegate = a; }

        /// <summary>
        /// This is the handler for Add Product button is clicked.
        /// </summary>
        /// <param name="sender">This is the button.</param>
        /// <param name="e">These are the arguments.</param>
        private void ux_addProduct_button_Click(object sender, EventArgs e)
        {
            add_delegate(ProductList[ux_unlistedProduct_listbox.SelectedIndex]);
            this.Close();
        }

        /// <summary>
        /// This is the handler for when the ServerForm is opened.
        /// </summary>
        /// <param name="sender">This is the form.</param>
        /// <param name="e">These are the arguments.</param>
        private void OnOpenForm(object sender, EventArgs e)
        {
            ProductList.Add(new("PS4", 400.00, "A 5th generation video game console made by Sony", 10001, true, ""));
            ProductNamesList.Add("PS4");

            ProductList.Add(new("Macbook", 1200.00, "A sleek laptop made by Apple Inc.", 10002, true, ""));
            ProductNamesList.Add("Macbook");

            ProductList.Add(new("Lionel 2026", 110.00, "A model 2-6-2 Praire type steam locomotive produced from 1949-1951", 02026, true, ""));
            ProductNamesList.Add("Lionel 2026");

            ProductList.Add(new("Shrek Anthology", 1000000000.00, "The single most pofitable movie franchise of all time (5 movie collection)", 10003, true, ""));
            ProductNamesList.Add("Shrek Antholoy");

            ProductList.Add(new("Xbox XX", 500.00, "A secret generation Xbox only released to the most interesting man in the world by Microsoft", 69669, true, ""));
            ProductNamesList.Add("Xbox XX");

            ProductList.Add(new("Surface Pro", 1000.00, "A sleek touchscreen laptop made by Microsoft Inc.", 42069, true, ""));
            ProductNamesList.Add("Surface Pro");

            ProductList.Add(new("Whale", 50000.00, "A literal 3-Ton Whale. Don't ask if this is legal.", 11202, true, ""));
            ProductNamesList.Add("Whale");

            ProductList.Add(new("The Bee Movie Collectors Addition", 1000000.00, "The entire cinematic masterpiece condensed into 5 seconds for best experience", 80085, false, ""));
            ProductNamesList.Add("The Bee Movie Collectors Addition");

            ProductList.Add(new("A singular piece of sand", 66.00, "Sand Grain from Star Wars Episode II. Confirmed to be thrown by Anikan Skywalker as he talked about hating sand", 66666, true, ""));
            ProductNamesList.Add("A singular piece of sand");

            ux_unlistedProduct_listbox.DataSource = ProductNamesList;
        }
    }
}
