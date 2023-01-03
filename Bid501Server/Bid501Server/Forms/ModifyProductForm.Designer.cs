namespace Bid501Server
{
    partial class ModifyProductForm
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
            this.ux_newName_label = new System.Windows.Forms.Label();
            this.ux_newPrice_label = new System.Windows.Forms.Label();
            this.ux_newDescription_label = new System.Windows.Forms.Label();
            this.ux_newID_label = new System.Windows.Forms.Label();
            this.ux_newStatus_label = new System.Windows.Forms.Label();
            this.ux_newName_textbox = new System.Windows.Forms.TextBox();
            this.ux_newPrice_textbox = new System.Windows.Forms.TextBox();
            this.ux_newDescription_textbox = new System.Windows.Forms.TextBox();
            this.ux_newID_textbox = new System.Windows.Forms.TextBox();
            this.ux_newStatus_textbox = new System.Windows.Forms.TextBox();
            this.ux_modifyProduct_button = new System.Windows.Forms.Button();
            this.ux_clientID_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ux_newName_label
            // 
            this.ux_newName_label.AutoSize = true;
            this.ux_newName_label.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ux_newName_label.Location = new System.Drawing.Point(53, 52);
            this.ux_newName_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ux_newName_label.Name = "ux_newName_label";
            this.ux_newName_label.Size = new System.Drawing.Size(193, 46);
            this.ux_newName_label.TabIndex = 0;
            this.ux_newName_label.Text = "New Name:";
            // 
            // ux_newPrice_label
            // 
            this.ux_newPrice_label.AutoSize = true;
            this.ux_newPrice_label.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ux_newPrice_label.Location = new System.Drawing.Point(53, 150);
            this.ux_newPrice_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ux_newPrice_label.Name = "ux_newPrice_label";
            this.ux_newPrice_label.Size = new System.Drawing.Size(177, 46);
            this.ux_newPrice_label.TabIndex = 1;
            this.ux_newPrice_label.Text = "New Price:";
            // 
            // ux_newDescription_label
            // 
            this.ux_newDescription_label.AutoSize = true;
            this.ux_newDescription_label.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ux_newDescription_label.Location = new System.Drawing.Point(53, 254);
            this.ux_newDescription_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ux_newDescription_label.Name = "ux_newDescription_label";
            this.ux_newDescription_label.Size = new System.Drawing.Size(275, 46);
            this.ux_newDescription_label.TabIndex = 2;
            this.ux_newDescription_label.Text = "New Description:";
            // 
            // ux_newID_label
            // 
            this.ux_newID_label.AutoSize = true;
            this.ux_newID_label.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ux_newID_label.Location = new System.Drawing.Point(53, 358);
            this.ux_newID_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ux_newID_label.Name = "ux_newID_label";
            this.ux_newID_label.Size = new System.Drawing.Size(137, 46);
            this.ux_newID_label.TabIndex = 3;
            this.ux_newID_label.Text = "New ID:";
            // 
            // ux_newStatus_label
            // 
            this.ux_newStatus_label.AutoSize = true;
            this.ux_newStatus_label.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ux_newStatus_label.Location = new System.Drawing.Point(53, 462);
            this.ux_newStatus_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ux_newStatus_label.Name = "ux_newStatus_label";
            this.ux_newStatus_label.Size = new System.Drawing.Size(195, 46);
            this.ux_newStatus_label.TabIndex = 4;
            this.ux_newStatus_label.Text = "New Status:";
            // 
            // ux_newName_textbox
            // 
            this.ux_newName_textbox.Location = new System.Drawing.Point(277, 49);
            this.ux_newName_textbox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ux_newName_textbox.Name = "ux_newName_textbox";
            this.ux_newName_textbox.Size = new System.Drawing.Size(660, 47);
            this.ux_newName_textbox.TabIndex = 5;
            this.ux_newName_textbox.TextChanged += new System.EventHandler(this.ux_newName_textbox_TextChanged);
            // 
            // ux_newPrice_textbox
            // 
            this.ux_newPrice_textbox.Location = new System.Drawing.Point(253, 150);
            this.ux_newPrice_textbox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ux_newPrice_textbox.Name = "ux_newPrice_textbox";
            this.ux_newPrice_textbox.Size = new System.Drawing.Size(684, 47);
            this.ux_newPrice_textbox.TabIndex = 6;
            this.ux_newPrice_textbox.TextChanged += new System.EventHandler(this.ux_newPrice_textbox_TextChanged);
            // 
            // ux_newDescription_textbox
            // 
            this.ux_newDescription_textbox.Location = new System.Drawing.Point(347, 254);
            this.ux_newDescription_textbox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ux_newDescription_textbox.Name = "ux_newDescription_textbox";
            this.ux_newDescription_textbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ux_newDescription_textbox.Size = new System.Drawing.Size(589, 47);
            this.ux_newDescription_textbox.TabIndex = 7;
            this.ux_newDescription_textbox.TextChanged += new System.EventHandler(this.ux_newDescription_textbox_TextChanged);
            // 
            // ux_newID_textbox
            // 
            this.ux_newID_textbox.Location = new System.Drawing.Point(209, 358);
            this.ux_newID_textbox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ux_newID_textbox.Name = "ux_newID_textbox";
            this.ux_newID_textbox.Size = new System.Drawing.Size(728, 47);
            this.ux_newID_textbox.TabIndex = 8;
            this.ux_newID_textbox.TextChanged += new System.EventHandler(this.ux_newID_textbox_TextChanged);
            // 
            // ux_newStatus_textbox
            // 
            this.ux_newStatus_textbox.Location = new System.Drawing.Point(265, 462);
            this.ux_newStatus_textbox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ux_newStatus_textbox.Name = "ux_newStatus_textbox";
            this.ux_newStatus_textbox.Size = new System.Drawing.Size(672, 47);
            this.ux_newStatus_textbox.TabIndex = 9;
            this.ux_newStatus_textbox.TextChanged += new System.EventHandler(this.ux_newStatus_textbox_TextChanged);
            // 
            // ux_modifyProduct_button
            // 
            this.ux_modifyProduct_button.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ux_modifyProduct_button.Location = new System.Drawing.Point(338, 541);
            this.ux_modifyProduct_button.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ux_modifyProduct_button.Name = "ux_modifyProduct_button";
            this.ux_modifyProduct_button.Size = new System.Drawing.Size(313, 107);
            this.ux_modifyProduct_button.TabIndex = 10;
            this.ux_modifyProduct_button.Text = "Modify Product";
            this.ux_modifyProduct_button.UseVisualStyleBackColor = true;
            this.ux_modifyProduct_button.Click += new System.EventHandler(this.ux_modifyProduct_button_Click);
            // 
            // ux_clientID_label
            // 
            this.ux_clientID_label.AutoSize = true;
            this.ux_clientID_label.Location = new System.Drawing.Point(53, 577);
            this.ux_clientID_label.Name = "ux_clientID_label";
            this.ux_clientID_label.Size = new System.Drawing.Size(97, 41);
            this.ux_clientID_label.TabIndex = 11;
            this.ux_clientID_label.Text = "label1";
            // 
            // ModifyProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 41F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1001, 681);
            this.Controls.Add(this.ux_clientID_label);
            this.Controls.Add(this.ux_modifyProduct_button);
            this.Controls.Add(this.ux_newStatus_textbox);
            this.Controls.Add(this.ux_newID_textbox);
            this.Controls.Add(this.ux_newDescription_textbox);
            this.Controls.Add(this.ux_newPrice_textbox);
            this.Controls.Add(this.ux_newName_textbox);
            this.Controls.Add(this.ux_newStatus_label);
            this.Controls.Add(this.ux_newID_label);
            this.Controls.Add(this.ux_newDescription_label);
            this.Controls.Add(this.ux_newPrice_label);
            this.Controls.Add(this.ux_newName_label);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "ModifyProductForm";
            this.Text = "ModifyProductForm";
            this.Load += new System.EventHandler(this.OnOpenForm);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label ux_newName_label;
        private Label ux_newPrice_label;
        private Label ux_newDescription_label;
        private Label ux_newID_label;
        private Label ux_newStatus_label;
        private TextBox ux_newName_textbox;
        private TextBox ux_newPrice_textbox;
        private TextBox ux_newDescription_textbox;
        private TextBox ux_newID_textbox;
        private TextBox ux_newStatus_textbox;
        private Button ux_modifyProduct_button;
        private Label ux_clientID_label;
    }
}