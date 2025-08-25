namespace AppCore
{
    partial class AgregarClienteFrm
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
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            txtNombre = new TextBox();
            txtNumeroDocumento = new TextBox();
            txtEmail = new TextBox();
            txtApellido = new TextBox();
            txtDireccion = new TextBox();
            Guardarbtn = new Button();
            label1 = new Label();
            txtTelefono = new TextBox();
            label2 = new Label();
            txtTipoDocumento = new TextBox();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(54, 255);
            label3.Name = "label3";
            label3.Size = new Size(233, 32);
            label3.TabIndex = 2;
            label3.Text = "Tipo de Documento:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(54, 191);
            label4.Name = "label4";
            label4.Size = new Size(107, 32);
            label4.TabIndex = 3;
            label4.Text = "Apellido:";
            label4.Click += label4_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(54, 127);
            label5.Name = "label5";
            label5.Size = new Size(107, 32);
            label5.TabIndex = 4;
            label5.Text = "Nombre:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(54, 451);
            label6.Name = "label6";
            label6.Size = new Size(76, 32);
            label6.TabIndex = 5;
            label6.Text = "Email:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(54, 377);
            label7.Name = "label7";
            label7.Size = new Size(112, 32);
            label7.TabIndex = 6;
            label7.Text = "Telefono:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(54, 517);
            label8.Name = "label8";
            label8.Size = new Size(119, 32);
            label8.TabIndex = 7;
            label8.Text = "Direccion:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(362, 120);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(200, 39);
            txtNombre.TabIndex = 8;
            txtNombre.TextChanged += txtNombre_TextChanged;
            // 
            // txtNumeroDocumento
            // 
            txtNumeroDocumento.Location = new Point(362, 304);
            txtNumeroDocumento.Name = "txtNumeroDocumento";
            txtNumeroDocumento.Size = new Size(200, 39);
            txtNumeroDocumento.TabIndex = 9;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(362, 444);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(200, 39);
            txtEmail.TabIndex = 12;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(362, 184);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(200, 39);
            txtApellido.TabIndex = 13;
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(362, 510);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(200, 39);
            txtDireccion.TabIndex = 14;
            // 
            // Guardarbtn
            // 
            Guardarbtn.Location = new Point(248, 600);
            Guardarbtn.Name = "Guardarbtn";
            Guardarbtn.Size = new Size(150, 46);
            Guardarbtn.TabIndex = 15;
            Guardarbtn.Text = "Guardar";
            Guardarbtn.UseVisualStyleBackColor = true;
            Guardarbtn.Click += Guardarbtn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(140, 28);
            label1.Name = "label1";
            label1.Size = new Size(432, 32);
            label1.TabIndex = 0;
            label1.Text = "Ingrese los siguientes datos del cliente:";
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(362, 370);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(200, 39);
            txtTelefono.TabIndex = 10;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(54, 311);
            label2.Name = "label2";
            label2.Size = new Size(271, 32);
            label2.TabIndex = 1;
            label2.Text = "Numero de documento:";
            // 
            // txtTipoDocumento
            // 
            txtTipoDocumento.Location = new Point(362, 248);
            txtTipoDocumento.Name = "txtTipoDocumento";
            txtTipoDocumento.Size = new Size(200, 39);
            txtTipoDocumento.TabIndex = 11;
            // 
            // AgregarClienteFrm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(702, 680);
            Controls.Add(Guardarbtn);
            Controls.Add(txtDireccion);
            Controls.Add(txtApellido);
            Controls.Add(txtEmail);
            Controls.Add(txtTipoDocumento);
            Controls.Add(txtTelefono);
            Controls.Add(txtNumeroDocumento);
            Controls.Add(txtNombre);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "AgregarClienteFrm";
            Text = "AgregarClienteFrm";
            Load += AgregarClienteFrm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private TextBox txtNombre;
        private TextBox txtNumeroDocumento;
        private TextBox txtEmail;
        private TextBox txtApellido;
        private TextBox txtDireccion;
        private Button Guardarbtn;
        private Label label1;
        private TextBox txtTelefono;
        private Label label2;
        private TextBox txtTipoDocumento;
    }
}