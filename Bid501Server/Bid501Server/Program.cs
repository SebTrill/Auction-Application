using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Bid501Server.Controllers;
using Bid501Server.Items;
using WebSocketSharp;
using WebSocketSharp.Server;
using Bid501Server.Forms;

namespace Bid501Server
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
            ApplicationConfiguration.Initialize();

            // ServerForm sf = new();
            Server_LoginForm lf = new();

            List<RealProduct> newProducts = new List<RealProduct>
            {
                new RealProduct("PS4", 400.00, "A 5th generation video game console made by Sony", 10001, true, ""),
                new RealProduct("Macbook", 1200.00, "A sleek laptop made by Apple Inc.", 10002, true, ""),
                new RealProduct("Lionel 2026", 110.00, "A model 2-6-2 Praire type steam locomotive produced from 1949-1951", 02026, true, ""),
                new RealProduct("Shrek Anthology", 1000000.00, "The single most pofitable movie franchise of all time, 5 movie collection", 10003, false, ""),
                new RealProduct("Xbox XX", 500.00, "A secret generation Xbox only released to the most interesting man in the world by Microsoft", 69669, true, ""),
                new RealProduct("Surface Pro", 1000.00, "A sleek touchscreen laptop made by Microsoft Inc.", 42069, true, ""),
                new RealProduct("Whale", 50000.00, "A literal 3-Ton Whale. Don't ask if this is legal, OBO", 11202, true, ""),
                new RealProduct("The Bee Movie Collectors Addition", 1000000.00, "The entire cinematic masterpiece condensed into 5 seconds for best experience", 80085, false, ""),
                new RealProduct("A singular piece of sand", 66.00, "Sand Grain from Star Wars Episode II. Confirmed to be thrown by Anikan Skywalker as he talked about hating sand", 66666, true, "")
            };

            ServerDatabase serverDatabase = new ServerDatabase();

            ServerFormController serverFormController = new ServerFormController(serverDatabase);
            serverFormController.SetConstructor3(lf.ClearLogin, lf.CloseLogin);
            lf.login = serverFormController.Login;

            // Start a websocket server at port 48965 or 8001
            var wss = new WebSocketServer(48965);

            // Add the Chat websocket service
            wss.AddWebSocketService("/chat", () =>
            {
                ServerCommController ComControl = new ServerCommController();
                serverFormController.SetConstructor2(ComControl.CloseBid, ComControl.SendNewProductList);
                ComControl.move_list = serverFormController.MoveList;
                ComControl.ServerFormControl = serverFormController;
                ComControl.handle = serverFormController.HandleEvents;

                return ComControl;
            });
            
            // Start the server
            wss.Start();

            // Run the server form.
            Application.Run(lf);

            // Stop the server
            wss.Stop();
        }


        // Ask for a name (that is a non-empty string)
        /// <summary>
        /// This gets the name from the user.
        /// </summary>
        /// <returns>Returns the name given as a string.</returns>
        private static string GetName()
        {
            string name = "";
            do while (InputBox("Name", "Enter user name:", ref name) != DialogResult.OK) ;
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

    // Delegates!
    public delegate void HandleEvents_DEL(string s, object? o);
    public delegate void Add_SF_DEL(RealProduct p);
    public delegate void Mod_MPF_DEL(RealProduct p); 
    public delegate void UpdateList_DEL(List<RealProduct> list);
    public delegate BindingList<string> SendClientNameList_DEL();
    public delegate void UpdateClients_DEL();
    public delegate void SendNewProductList_DEL(List<RealProduct> list);

    public delegate void CloseBid_DEL(string s);
    public delegate void ClearLogin_DEL();
    public delegate void CloseLogin_DEL();
    public delegate void MoveList_DEL(List<RealProduct> list);

    public delegate bool Login_DEL(string s);

}