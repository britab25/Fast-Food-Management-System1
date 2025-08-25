namespace AppCore
{
    partial class ActualizarUsuario
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
            label2 = new Label();
            txtUsuarioID = new TextBox();
            Guardarbtn1 = new Button();
            txtRol = new TextBox();
            txtNombre = new TextBox();
            label8 = new Label();
            label5 = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(167, 58);
            label2.Name = "label2";
            label2.Size = new Size(503, 32);
            label2.TabIndex = 45;
            label2.Text = "Ingrese el ID del usuario que desee actualizar:";
            // 
            // txtUsuarioID
            // 
            txtUsuarioID.Location = new Point(187, 137);
            txtUsuarioID.Name = "txtUsuarioID";
            txtUsuarioID.Size = new Size(402, 39);
            txtUsuarioID.TabIndex = 44;
            // 
            // Guardarbtn1
            // 
            Guardarbtn1.Location = new Point(308, 515);
            Guardarbtn1.Name = "Guardarbtn1";
            Guardarbtn1.Size = new Size(150, 46);
            Guardarbtn1.TabIndex = 43;
            Guardarbtn1.Text = "Guardar";
            Guardarbtn1.UseVisualStyleBackColor = true;
            Guardarbtn1.Click += Guardarbtn1_Click;
            // 
            // txtRol
            // 
            txtRol.Location = new Point(432, 404);
            txtRol.Name = "txtRol";
            txtRol.Size = new Size(200, 39);
            txtRol.TabIndex = 42;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(432, 323);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(200, 39);
            txtNombre.TabIndex = 38;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(124, 407);
            label8.Name = "label8";
            label8.Size = new Size(52, 32);
            label8.TabIndex = 37;
            label8.Text = "Rol:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(124, 330);
            label5.Name = "label5";
            label5.Size = new Size(107, 32);
            label5.TabIndex = 34;
            label5.Text = "Nombre:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(124, 235);
            label1.Name = "label1";
            label1.Size = new Size(553, 32);
            label1.TabIndex = 31;
            label1.Text = "Ingrese los datos que quiera actualizar del usuario:";
            // 
            // ActualizarUsuario
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(868, 643);
            Controls.Add(label2);
            Controls.Add(txtUsuarioID);
            Controls.Add(Guardarbtn1);
            Controls.Add(txtRol);
            Controls.Add(txtNombre);
            Controls.Add(label8);
            Controls.Add(label5);
            Controls.Add(label1);
            Name = "ActualizarUsuario";
            Text = "ActualizarUsuario";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private TextBox txtUsuarioID;
        private Button Guardarbtn1;
        private TextBox txtRol;
        private TextBox txtNombre;
        private Label label8;
        private Label label5;
        private Label label1;
    }
}