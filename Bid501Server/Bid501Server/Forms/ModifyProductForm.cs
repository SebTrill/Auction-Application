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
    public partial class ModifyProductForm : Form
    {
        /// <summary>
        /// This is the Mod_MPF_DEL delegate.
        /// </summary>
        Mod_MPF_DEL modify_delegate;

        /// <summary>
        /// This is the list of products.
        /// </summary>
        public RealProduct Product = new();

        /// <summary>
        /// This is the ModifyProductForm constructor.
        /// </summary>
        public ModifyProductForm(RealProduct p)
        {
            Product = p;
            InitializeComponent();
            ux_clientID_label.Visible = false;
        }

        /// <summary>
        /// This sets the values of the delegate(s).
        /// </summary>
        /// <param name="m">This is the Mod_MPF_DEL delegate..</param>
        public void SetConstructor(Mod_MPF_DEL m) { modify_delegate = m; }

        /// <summary>
        /// This is the handler for when the New Name text is changed.
        /// </summary>
        /// <param name="sender">This is the texbox.</param>
        /// <param name="e">These are the arguments.</param>
        private void ux_newName_textbox_TextChanged(object sender, EventArgs e) { Product.Name = (string)ux_newName_textbox.Text; }

        /// <summary>
        /// This is the handler for when the New Price text is changed.
        /// </summary>
        /// <param name="sender">This is the texbox.</param>
        /// <param name="e">These are the arguments.</param>
        private void ux_newPrice_textbox_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(ux_newPrice_textbox.Text, out double value)) Product.Price = value;
            else MessageBox.Show("Not a valid Price");
        }

        /// <summary>
        /// This is the handler for when the New Description text is changed.
        /// </summary>
        /// <param name="sender">This is the texbox.</param>
        /// <param name="e">These are the arguments.</param>
        private void ux_newDescription_textbox_TextChanged(object sender, EventArgs e) { Product.Description = (string)ux_newDescription_textbox.Text; }

        /// <summary>
        /// This is the handler for when the New ID text is changed.
        /// </summary>
        /// <param name="sender">This is the texbox.</param>
        /// <param name="e">These are the arguments.</param>
        private void ux_newID_textbox_TextChanged(object sender, EventArgs e)
        {

            if (int.TryParse(ux_newID_textbox.Text, out int value)) Product.ID = value;
            else MessageBox.Show("Not a valid ID");
        }

        /// <summary>
        /// This is the handler for when the New Status text is changed.
        /// </summary>
        /// <param name="sender">This is the texbox.</param>
        /// <param name="e">These are the arguments.</param>
        private void ux_newStatus_textbox_TextChanged(object sender, EventArgs e)
        {
            if (bool.TryParse(ux_newStatus_textbox.Text, out bool value)) Product.Status = value;
            else MessageBox.Show("Not a valid Status");
        }

        /// <summary>
        /// This is the handler for Modify Product button is clicked.
        /// </summary>
        /// <param name="sender">This is the button.</param>
        /// <param name="e">These are the arguments.</param>
        private void ux_modifyProduct_button_Click(object sender, EventArgs e)
        {
            //might make a delegate here as well
            RealProduct p = new RealProduct(ux_newName_textbox.Text, Convert.ToDouble(ux_newPrice_textbox.Text), ux_newDescription_textbox.Text,
                Convert.ToInt32(ux_newID_textbox.Text), Convert.ToBoolean(ux_newStatus_textbox.Text), ux_clientID_label.Text);

            modify_delegate(p);
            this.Close();
        }

        /// <summary>
        /// This is the handler for when the form opens or loads
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnOpenForm(object sender, EventArgs e)
        {
            //This sould become a delagate of its own
            ux_newName_textbox.Text = Product.Name;
            ux_newPrice_textbox.Text = Product.Price.ToString();
            ux_newStatus_textbox.Text = Product.Status.ToString();
            ux_newDescription_textbox.Text = Product.Description;
            ux_newID_textbox.Text = Product.ID.ToString();  
            ux_clientID_label.Text = Product.Client_ID.ToString();
        }
    }
}
