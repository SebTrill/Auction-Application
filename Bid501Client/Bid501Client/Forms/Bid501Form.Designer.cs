namespace Bid501Client
{
    partial class Bid501Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ux_item_name = new System.Windows.Forms.Label();
            this.ux_product_label = new System.Windows.Forms.Label();
            this.ux_product_listbox = new System.Windows.Forms.ListBox();
            this.ux_timer_label = new System.Windows.Forms.Label();
            this.ux_status_label = new System.Windows.Forms.Label();
            this.ux_bid_textbox = new System.Windows.Forms.TextBox();
            this.ux_minimum_bid = new System.Windows.Forms.Label();
            this.ux_placeBid_button = new System.Windows.Forms.Button();
            this.ux_descriptionLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ux_item_name
            // 
            this.ux_item_name.AutoSize = true;
            this.ux_item_name.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ux_item_name.Location = new System.Drawing.Point(49, 25);
            this.ux_item_name.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ux_item_name.MaximumSize = new System.Drawing.Size(550, 0);
            this.ux_item_name.Name = "ux_item_name";
            this.ux_item_name.Size = new System.Drawing.Size(202, 46);
            this.ux_item_name.TabIndex = 0;
            this.ux_item_name.Text = "Item Name: ";
            // 
            // ux_product_label
            // 
            this.ux_product_label.AutoSize = true;
            this.ux_product_label.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ux_product_label.Location = new System.Drawing.Point(753, 68);
            this.ux_product_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ux_product_label.Name = "ux_product_label";
            this.ux_product_label.Size = new System.Drawing.Size(152, 46);
            this.ux_product_label.TabIndex = 1;
            this.ux_product_label.Text = "Products";
            // 
            // ux_product_listbox
            // 
            this.ux_product_listbox.FormattingEnabled = true;
            this.ux_product_listbox.ItemHeight = 41;
            this.ux_product_listbox.Location = new System.Drawing.Point(619, 137);
            this.ux_product_listbox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ux_product_listbox.Name = "ux_product_listbox";
            this.ux_product_listbox.Size = new System.Drawing.Size(405, 619);
            this.ux_product_listbox.TabIndex = 2;
            this.ux_product_listbox.SelectedIndexChanged += new System.EventHandler(this.ux_product_listbox_SelectedIndexChanged);
            // 
            // ux_timer_label
            // 
            this.ux_timer_label.AutoSize = true;
            this.ux_timer_label.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ux_timer_label.Location = new System.Drawing.Point(49, 328);
            this.ux_timer_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ux_timer_label.Name = "ux_timer_label";
            this.ux_timer_label.Size = new System.Drawing.Size(305, 46);
            this.ux_timer_label.TabIndex = 3;
            this.ux_timer_label.Text = "Timer Countdown: ";
            // 
            // ux_status_label
            // 
            this.ux_status_label.AutoSize = true;
            this.ux_status_label.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ux_status_label.Location = new System.Drawing.Point(49, 396);
            this.ux_status_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ux_status_label.Name = "ux_status_label";
            this.ux_status_label.Size = new System.Drawing.Size(127, 46);
            this.ux_status_label.TabIndex = 4;
            this.ux_status_label.Text = "Status: ";
            // 
            // ux_bid_textbox
            // 
            this.ux_bid_textbox.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ux_bid_textbox.Location = new System.Drawing.Point(49, 467);
            this.ux_bid_textbox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ux_bid_textbox.Name = "ux_bid_textbox";
            this.ux_bid_textbox.Size = new System.Drawing.Size(249, 52);
            this.ux_bid_textbox.TabIndex = 5;
            this.ux_bid_textbox.TextChanged += new System.EventHandler(this.ux_bid_textbox_TextChanged);
            // 
            // ux_minimum_bid
            // 
            this.ux_minimum_bid.AutoSize = true;
            this.ux_minimum_bid.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ux_minimum_bid.Location = new System.Drawing.Point(49, 569);
            this.ux_minimum_bid.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ux_minimum_bid.Name = "ux_minimum_bid";
            this.ux_minimum_bid.Size = new System.Drawing.Size(314, 46);
            this.ux_minimum_bid.TabIndex = 7;
            this.ux_minimum_bid.Text = "Minimum Bid: $0.00";
            // 
            // ux_placeBid_button
            // 
            this.ux_placeBid_button.Enabled = false;
            this.ux_placeBid_button.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ux_placeBid_button.Location = new System.Drawing.Point(49, 659);
            this.ux_placeBid_button.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ux_placeBid_button.Name = "ux_placeBid_button";
            this.ux_placeBid_button.Size = new System.Drawing.Size(289, 96);
            this.ux_placeBid_button.TabIndex = 8;
            this.ux_placeBid_button.Text = "Place Bid";
            this.ux_placeBid_button.UseVisualStyleBackColor = true;
            this.ux_placeBid_button.Click += new System.EventHandler(this.ux_placeBid_button_Click);
            // 
            // ux_descriptionLabel
            // 
            this.ux_descriptionLabel.AutoSize = true;
            this.ux_descriptionLabel.Location = new System.Drawing.Point(49, 137);
            this.ux_descriptionLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ux_descriptionLabel.MaximumSize = new System.Drawing.Size(550, 0);
            this.ux_descriptionLabel.Name = "ux_descriptionLabel";
            this.ux_descriptionLabel.Size = new System.Drawing.Size(190, 41);
            this.ux_descriptionLabel.TabIndex = 9;
            this.ux_descriptionLabel.Text = "Description...";
            // 
            // Bid501Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 41F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1081, 798);
            this.Controls.Add(this.ux_descriptionLabel);
            this.Controls.Add(this.ux_placeBid_button);
            this.Controls.Add(this.ux_minimum_bid);
            this.Controls.Add(this.ux_bid_textbox);
            this.Controls.Add(this.ux_status_label);
            this.Controls.Add(this.ux_timer_label);
            this.Controls.Add(this.ux_product_listbox);
            this.Controls.Add(this.ux_product_label);
            this.Controls.Add(this.ux_item_name);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "Bid501Form";
            this.Text = "Bid501Form";
            this.Load += new System.EventHandler(this.OnOpenForm);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label ux_item_name;
        private Label ux_product_label;
        private ListBox ux_product_listbox;
        private Label ux_timer_label;
        private Label ux_status_label;
        private TextBox ux_bid_textbox;
        private Label ux_bid_number;
        private Label ux_minimum_bid;
        private Button ux_placeBid_button;
        private Label ux_descriptionLabel;
    }
}