using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bid501Server.Forms
{
    public partial class Server_LoginForm : Form
    {
        /// <summary>
        /// This is the Login_DEL delegate.
        /// </summary>
        public Login_DEL login;

        /// <summary>
        /// This is the entered username.
        /// </summary>
        public string Username = "";

        /// <summary>
        /// This is the entered password.
        /// </summary>
        public string Password = "";

        /// <summary>
        /// This is the Login_Form constructor.
        /// </summary>
        public Server_LoginForm() { InitializeComponent(); }

        /// <summary>
        /// This clears the login of data.
        /// </summary>
        public void ClearLogin()
        {
            ux_usernameText.Clear();
            ux_passwordText.Clear();
        }

        /// <summary>
        /// This makes the login form invisible.
        /// </summary>
        public void CloseLogin() { this.Visible = false; }

        /// <summary>
        /// This is the event handler for the Username textbox when the username is entered.
        /// </summary>
        /// <param name="sender">This is the textbox.</param>
        /// <param name="e">These are the arguments.</param>
        private void ux_usernameText_TextChanged(object sender, EventArgs e)
        {
            if (ux_usernameText.Text != "")
            {
                ux_passwordText.Enabled = true;
                Username = ux_usernameText.Text;
            }
            else
            {
                ux_passwordText.Enabled = false;
                Username = "";
            }
        }

        /// <summary>
        /// This is the event handler for the Password textbox when the password is entered.
        /// </summary>
        /// <param name="sender">This is the textbox.</param>
        /// <param name="e">These are the arguments.</param>
        private void ux_passwordText_TextChanged(object sender, EventArgs e)
        {
            if (ux_passwordText.Text != "")
            {
                ux_loginButton.Enabled = true;
                Password = ux_passwordText.Text;
            }
            else
            {
                ux_loginButton.Enabled = false;
                Password = "";
            }
        }

        /// <summary>
        /// This is the event handler for the Login button.
        /// </summary>
        /// <param name="sender">This is the button.</param>
        /// <param name="e">These are the arguments.</param>
        private void ux_loginButton_Click(object sender, EventArgs e) { if (login(Username + "," + Password) == false) MessageBox.Show("Invalid admin credentials."); }
    }
}
