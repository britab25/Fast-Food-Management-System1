namespace AppCore
{
    partial class Form1
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
            txtUsuario = new TextBox();
            lblLogin = new Label();
            txtPassword = new TextBox();
            label1 = new Label();
            label3 = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(298, 192);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(200, 39);
            txtUsuario.TabIndex = 0;
            // 
            // lblLogin
            // 
            lblLogin.AutoSize = true;
            lblLogin.Location = new Point(354, 94);
            lblLogin.Name = "lblLogin";
            lblLogin.Size = new Size(73, 32);
            lblLogin.TabIndex = 1;
            lblLogin.Text = "Login";
            lblLogin.Click += label1_Click;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(298, 303);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(200, 39);
            txtPassword.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(141, 199);
            label1.Name = "label1";
            label1.Size = new Size(66, 32);
            label1.TabIndex = 3;
            label1.Text = "User:";
            label1.Click += label1_Click_1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(141, 310);
            label3.Name = "label3";
            label3.Size = new Size(116, 32);
            label3.TabIndex = 5;
            label3.Text = "Password:";
            // 
            // button1
            // 
            button1.Location = new Point(330, 405);
            button1.Name = "button1";
            button1.Size = new Size(150, 46);
            button1.TabIndex = 6;
            button1.Text = "Acceder";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(782, 548);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(txtPassword);
            Controls.Add(lblLogin);
            Controls.Add(txtUsuario);
            Name = "Form1";
            Text = "LogInFrm";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtUsuario;
        private Label lblLogin;
        private TextBox txtPassword;
        private Label label1;
        private Label label3;
        private Button button1;
    }
}
