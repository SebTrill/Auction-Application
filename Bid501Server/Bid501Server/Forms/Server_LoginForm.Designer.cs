namespace Bid501Server.Forms
{
    partial class Server_LoginForm
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
            this.ux_loginButton = new System.Windows.Forms.Button();
            this.ux_passwordLabel = new System.Windows.Forms.Label();
            this.ux_passwordText = new System.Windows.Forms.TextBox();
            this.ux_usernameLabel = new System.Windows.Forms.Label();
            this.ux_usernameText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ux_loginButton
            // 
            this.ux_loginButton.Enabled = false;
            this.ux_loginButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ux_loginButton.Location = new System.Drawing.Point(326, 384);
            this.ux_loginButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ux_loginButton.Name = "ux_loginButton";
            this.ux_loginButton.Size = new System.Drawing.Size(267, 115);
            this.ux_loginButton.TabIndex = 9;
            this.ux_loginButton.Text = "Login";
            this.ux_loginButton.UseVisualStyleBackColor = true;
            this.ux_loginButton.Click += new System.EventHandler(this.ux_loginButton_Click);
            // 
            // ux_passwordLabel
            // 
            this.ux_passwordLabel.AutoSize = true;
            this.ux_passwordLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ux_passwordLabel.Location = new System.Drawing.Point(139, 258);
            this.ux_passwordLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ux_passwordLabel.Name = "ux_passwordLabel";
            this.ux_passwordLabel.Size = new System.Drawing.Size(160, 46);
            this.ux_passwordLabel.TabIndex = 8;
            this.ux_passwordLabel.Text = "Password";
            // 
            // ux_passwordText
            // 
            this.ux_passwordText.Enabled = false;
            this.ux_passwordText.Location = new System.Drawing.Point(338, 258);
            this.ux_passwordText.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ux_passwordText.Name = "ux_passwordText";
            this.ux_passwordText.PasswordChar = '*';
            this.ux_passwordText.Size = new System.Drawing.Size(427, 47);
            this.ux_passwordText.TabIndex = 7;
            this.ux_passwordText.TextChanged += new System.EventHandler(this.ux_passwordText_TextChanged);
            // 
            // ux_usernameLabel
            // 
            this.ux_usernameLabel.AutoSize = true;
            this.ux_usernameLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ux_usernameLabel.Location = new System.Drawing.Point(115, 119);
            this.ux_usernameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ux_usernameLabel.Name = "ux_usernameLabel";
            this.ux_usernameLabel.Size = new System.Drawing.Size(185, 46);
            this.ux_usernameLabel.TabIndex = 6;
            this.ux_usernameLabel.Text = "User Name";
            // 
            // ux_usernameText
            // 
            this.ux_usernameText.Location = new System.Drawing.Point(338, 119);
            this.ux_usernameText.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ux_usernameText.Name = "ux_usernameText";
            this.ux_usernameText.Size = new System.Drawing.Size(427, 47);
            this.ux_usernameText.TabIndex = 5;
            this.ux_usernameText.TextChanged += new System.EventHandler(this.ux_usernameText_TextChanged);
            // 
            // Server_LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 41F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 617);
            this.Controls.Add(this.ux_loginButton);
            this.Controls.Add(this.ux_passwordLabel);
            this.Controls.Add(this.ux_passwordText);
            this.Controls.Add(this.ux_usernameLabel);
            this.Controls.Add(this.ux_usernameText);
            this.Name = "Server_LoginForm";
            this.Text = "Server_LoginForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button ux_loginButton;
        private Label ux_passwordLabel;
        private TextBox ux_passwordText;
        private Label ux_usernameLabel;
        private TextBox ux_usernameText;
    }
}