namespace Bid501Server
{
    partial class ServerForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ux_product_listbox = new System.Windows.Forms.ListBox();
            this.ux_clients_listbox = new System.Windows.Forms.ListBox();
            this.ux_modify_button = new System.Windows.Forms.Button();
            this.ux_add_button = new System.Windows.Forms.Button();
            this.ux_stopBiddingButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ux_product_listbox
            // 
            this.ux_product_listbox.FormattingEnabled = true;
            this.ux_product_listbox.ItemHeight = 20;
            this.ux_product_listbox.Location = new System.Drawing.Point(19, 15);
            this.ux_product_listbox.Margin = new System.Windows.Forms.Padding(1);
            this.ux_product_listbox.Name = "ux_product_listbox";
            this.ux_product_listbox.Size = new System.Drawing.Size(230, 404);
            this.ux_product_listbox.TabIndex = 0;
            // 
            // ux_clients_listbox
            // 
            this.ux_clients_listbox.FormattingEnabled = true;
            this.ux_clients_listbox.ItemHeight = 20;
            this.ux_clients_listbox.Location = new System.Drawing.Point(266, 15);
            this.ux_clients_listbox.Margin = new System.Windows.Forms.Padding(1);
            this.ux_clients_listbox.Name = "ux_clients_listbox";
            this.ux_clients_listbox.Size = new System.Drawing.Size(230, 404);
            this.ux_clients_listbox.TabIndex = 1;
            // 
            // ux_modify_button
            // 
            this.ux_modify_button.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ux_modify_button.Location = new System.Drawing.Point(181, 433);
            this.ux_modify_button.Margin = new System.Windows.Forms.Padding(1);
            this.ux_modify_button.Name = "ux_modify_button";
            this.ux_modify_button.Size = new System.Drawing.Size(145, 60);
            this.ux_modify_button.TabIndex = 2;
            this.ux_modify_button.Text = "Modify";
            this.ux_modify_button.UseVisualStyleBackColor = true;
            this.ux_modify_button.Click += new System.EventHandler(this.ux_modify_button_Click);
            // 
            // ux_add_button
            // 
            this.ux_add_button.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ux_add_button.Location = new System.Drawing.Point(351, 433);
            this.ux_add_button.Margin = new System.Windows.Forms.Padding(1);
            this.ux_add_button.Name = "ux_add_button";
            this.ux_add_button.Size = new System.Drawing.Size(145, 60);
            this.ux_add_button.TabIndex = 3;
            this.ux_add_button.Text = "Add Product";
            this.ux_add_button.UseVisualStyleBackColor = true;
            this.ux_add_button.Click += new System.EventHandler(this.ux_add_button_Click);
            // 
            // ux_stopBiddingButton
            // 
            this.ux_stopBiddingButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ux_stopBiddingButton.Location = new System.Drawing.Point(19, 433);
            this.ux_stopBiddingButton.Margin = new System.Windows.Forms.Padding(1);
            this.ux_stopBiddingButton.Name = "ux_stopBiddingButton";
            this.ux_stopBiddingButton.Size = new System.Drawing.Size(145, 60);
            this.ux_stopBiddingButton.TabIndex = 4;
            this.ux_stopBiddingButton.Text = "Stop Bidding";
            this.ux_stopBiddingButton.UseVisualStyleBackColor = true;
            this.ux_stopBiddingButton.Click += new System.EventHandler(this.ux_stopBiddingButton_Click);
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 509);
            this.Controls.Add(this.ux_stopBiddingButton);
            this.Controls.Add(this.ux_add_button);
            this.Controls.Add(this.ux_modify_button);
            this.Controls.Add(this.ux_clients_listbox);
            this.Controls.Add(this.ux_product_listbox);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "ServerForm";
            this.Text = "ServerForm";
            this.Load += new System.EventHandler(this.OnOpenForm);
            this.ResumeLayout(false);

        }

        #endregion

        private ListBox ux_product_listbox;
        private ListBox ux_clients_listbox;
        private Button ux_modify_button;
        private Button ux_add_button;
        private Button ux_stopBiddingButton;
    }
}