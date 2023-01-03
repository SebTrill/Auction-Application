using Bid501Client.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebSocketSharp.Server;
using Bid501Client.Proxies;
using WebSocketSharp;
using System.Net;

namespace Bid501Client
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ApplicationConfiguration.Initialize();

            // Creating the comm controller to connect it with the websocket.
            ClientCommController comControl = new ClientCommController();

            // Creating the bid controller so we can connect delegate(s).
            Bid501Controller controller = new(comControl);
            Login_Form lf = new();

            controller.SetConstructor2(lf.ClearLogin, lf.CloseLogin);

            comControl.MessageReceived += controller.MessageReceived;

            // Connecting delegate(s).
            lf.login = controller.HandleEvents;

            // External IP: 24.255.208.200 (Manhattan)
            // Local IP: 10.150.81.179 (On Campus WiFi) 10.132.72.6
            // IP: 127.0.0.1 (Default)
            WebSocket ws = new WebSocket("ws://127.0.0.1:48965/chat");
            comControl.SetConstructor(ws);

            ws.Connect();

            // Running the application.
            Application.Run(lf);
        }

        /// <summary>
        /// This gets the name from the user.
        /// </summary>
        /// <returns>Returns the name given as a string.</returns>
        private static string GetName()
        {
            string name = "";
            do while (InputBox("Name", "Enter user name:", ref name) != DialogResult.OK);
            while (name == "");
            return name;
        }

        // From http://www.csharp-examples.net/inputbox/
        /// <summary>
        /// This is the input box shown to the user.
        /// </summary>
        /// <param name="title">This is the title of the inputbox.</param>
        /// <param name="promptText">This is the prompt text shown to the user.</param>
        /// <param name="value">This is the value used by the inputbox.</param>
        /// <returns>Returns a dialog of what the user input into the inputbox.</returns>
        public static DialogResult InputBox(string title, string promptText, ref string value)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            return dialogResult;
        }
    }

    // Deleagtes!
    public delegate void HandleEvents_DEL(string s, object? o);
    public delegate bool Login_DEL(string user, string pass);
    public delegate bool Message(string message);
    public delegate void MakeNewAccount_DEL(string user, string pass);
    
    public delegate void ClearListbox_DEL();
    public delegate void RefreshForm_DEL();
    public delegate void UpdateList_DEL(List<ProductProxy> list);

    public delegate void ClearLogin_DEL();
    public delegate void CloseLogin_DEL();
}