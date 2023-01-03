namespace Bid501Server
{
    partial class AddProductForm
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
            this.ux_unlistedProduct_listbox = new System.Windows.Forms.ListBox();
            this.ux_addProduct_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ux_unlistedProduct_listbox
            // 
            this.ux_unlistedProduct_listbox.FormattingEnabled = true;
            this.ux_unlistedProduct_listbox.ItemHeight = 41;
            this.ux_unlistedProduct_listbox.Location = new System.Drawing.Point(34, 34);
            this.ux_unlistedProduct_listbox.Name = "ux_unlistedProduct_listbox";
            this.ux_unlistedProduct_listbox.Size = new System.Drawing.Size(658, 824);
            this.ux_unlistedProduct_listbox.TabIndex = 0;
            // 
            // ux_addProduct_button
            // 
            this.ux_addProduct_button.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ux_addProduct_button.Location = new System.Drawing.Point(229, 890);
            this.ux_addProduct_button.Name = "ux_addProduct_button";
            this.ux_addProduct_button.Size = new System.Drawing.Size(261, 114);
            this.ux_addProduct_button.TabIndex = 1;
            this.ux_addProduct_button.Text = "Add Product";
            this.ux_addProduct_button.UseVisualStyleBackColor = true;
            this.ux_addProduct_button.Click += new System.EventHandler(this.ux_addProduct_button_Click);
            // 
            // AddProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 41F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 1033);
            this.Controls.Add(this.ux_addProduct_button);
            this.Controls.Add(this.ux_unlistedProduct_listbox);
            this.Name = "AddProductForm";
            this.Text = "AddProductForm";
            this.Load += new System.EventHandler(this.OnOpenForm);
            this.ResumeLayout(false);

        }

        #endregion

        private ListBox ux_unlistedProduct_listbox;
        private Button ux_addProduct_button;
    }
}