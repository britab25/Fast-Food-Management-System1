namespace AppCore
{
    partial class AgregarUsuario
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
            txtUsuario = new TextBox();
            txtContrasenaa = new TextBox();
            txtRol = new TextBox();
            txtNombre = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            Guardarbtn = new Button();
            SuspendLayout();
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(431, 239);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(200, 39);
            txtUsuario.TabIndex = 22;
            // 
            // txtContrasenaa
            // 
            txtContrasenaa.Location = new Point(431, 303);
            txtContrasenaa.Name = "txtContrasenaa";
            txtContrasenaa.Size = new Size(200, 39);
            txtContrasenaa.TabIndex = 21;
            // 
            // txtRol
            // 
            txtRol.Location = new Point(431, 366);
            txtRol.Name = "txtRol";
            txtRol.Size = new Size(200, 39);
            txtRol.TabIndex = 20;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(431, 175);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(200, 39);
            txtNombre.TabIndex = 19;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(123, 182);
            label5.Name = "label5";
            label5.Size = new Size(107, 32);
            label5.TabIndex = 18;
            label5.Text = "Nombre:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(123, 246);
            label4.Name = "label4";
            label4.Size = new Size(94, 32);
            label4.TabIndex = 17;
            label4.Text = "Usuario";
            label4.Click += label4_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(123, 310);
            label3.Name = "label3";
            label3.Size = new Size(139, 32);
            label3.TabIndex = 16;
            label3.Text = "Contrasena:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(123, 373);
            label2.Name = "label2";
            label2.Size = new Size(52, 32);
            label2.TabIndex = 15;
            label2.Text = "Rol:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(165, 83);
            label1.Name = "label1";
            label1.Size = new Size(439, 32);
            label1.TabIndex = 14;
            label1.Text = "Ingrese los siguientes datos del usuario:";
            // 
            // Guardarbtn
            // 
            Guardarbtn.Location = new Point(305, 477);
            Guardarbtn.Name = "Guardarbtn";
            Guardarbtn.Size = new Size(150, 46);
            Guardarbtn.TabIndex = 23;
            Guardarbtn.Text = "Guardar";
            Guardarbtn.UseVisualStyleBackColor = true;
            Guardarbtn.Click += Guardarbtn_Click;
            // 
            // AgregarUsuario
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(772, 626);
            Controls.Add(Guardarbtn);
            Controls.Add(txtUsuario);
            Controls.Add(txtContrasenaa);
            Controls.Add(txtRol);
            Controls.Add(txtNombre);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "AgregarUsuario";
            Text = "AgregarUsuario";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtUsuario;
        private TextBox txtContrasenaa;
        private TextBox txtRol;
        private TextBox txtNombre;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button Guardarbtn;
    }
}