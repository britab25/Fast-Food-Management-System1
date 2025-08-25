namespace AppCore
{
    partial class AgregarClienteFrm1cs
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
            txtNumeroDocumento = new TextBox();
            Guardarbtn1 = new Button();
            txtDireccion = new TextBox();
            txtApellido = new TextBox();
            txtEmail = new TextBox();
            txtTelefono = new TextBox();
            txtNombre = new TextBox();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(76, 45);
            label2.Name = "label2";
            label2.Size = new Size(721, 32);
            label2.TabIndex = 47;
            label2.Text = "Ingrese el numero de documento del cliente que desee actualizar:";
            // 
            // txtNumeroDocumento
            // 
            txtNumeroDocumento.Location = new Point(208, 122);
            txtNumeroDocumento.Name = "txtNumeroDocumento";
            txtNumeroDocumento.Size = new Size(402, 39);
            txtNumeroDocumento.TabIndex = 46;
            // 
            // Guardarbtn1
            // 
            Guardarbtn1.Location = new Point(346, 651);
            Guardarbtn1.Name = "Guardarbtn1";
            Guardarbtn1.Size = new Size(150, 46);
            Guardarbtn1.TabIndex = 62;
            Guardarbtn1.Text = "Guardar";
            Guardarbtn1.UseVisualStyleBackColor = true;
            Guardarbtn1.Click += Guardarbtn_Click;
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(460, 561);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(200, 39);
            txtDireccion.TabIndex = 61;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(460, 343);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(200, 39);
            txtApellido.TabIndex = 60;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(460, 495);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(200, 39);
            txtEmail.TabIndex = 59;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(460, 421);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(200, 39);
            txtTelefono.TabIndex = 57;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(460, 279);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(200, 39);
            txtNombre.TabIndex = 55;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(152, 568);
            label8.Name = "label8";
            label8.Size = new Size(119, 32);
            label8.TabIndex = 54;
            label8.Text = "Direccion:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(152, 428);
            label7.Name = "label7";
            label7.Size = new Size(112, 32);
            label7.TabIndex = 53;
            label7.Text = "Telefono:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(152, 502);
            label6.Name = "label6";
            label6.Size = new Size(76, 32);
            label6.TabIndex = 52;
            label6.Text = "Email:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(152, 286);
            label5.Name = "label5";
            label5.Size = new Size(107, 32);
            label5.TabIndex = 51;
            label5.Text = "Nombre:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(152, 350);
            label4.Name = "label4";
            label4.Size = new Size(107, 32);
            label4.TabIndex = 50;
            label4.Text = "Apellido:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(186, 205);
            label1.Name = "label1";
            label1.Size = new Size(424, 32);
            label1.TabIndex = 63;
            label1.Text = "Ingrese los datos que desee modificar:";
            // 
            // AgregarClienteFrm1cs
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(850, 741);
            Controls.Add(label1);
            Controls.Add(Guardarbtn1);
            Controls.Add(txtDireccion);
            Controls.Add(txtApellido);
            Controls.Add(txtEmail);
            Controls.Add(txtTelefono);
            Controls.Add(txtNombre);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(txtNumeroDocumento);
            Name = "AgregarClienteFrm1cs";
            Text = "AgregarClienteFrm1cs";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private TextBox txtNumeroDocumento;
        private Button Guardarbtn1;
        private TextBox txtDireccion;
        private TextBox txtApellido;
        private TextBox txtEmail;
        private TextBox txtTelefono;
        private TextBox txtNombre;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label1;
    }
}