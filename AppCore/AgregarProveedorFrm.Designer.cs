namespace AppCore
{
    partial class AgregarProveedorFrm
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
            txtDescripcion = new TextBox();
            txtNombreProveedor = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label1 = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(380, 246);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(200, 39);
            txtDescripcion.TabIndex = 18;
            // 
            // txtNombreProveedor
            // 
            txtNombreProveedor.Location = new Point(380, 178);
            txtNombreProveedor.Name = "txtNombreProveedor";
            txtNombreProveedor.Size = new Size(200, 39);
            txtNombreProveedor.TabIndex = 17;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(72, 185);
            label5.Name = "label5";
            label5.Size = new Size(264, 32);
            label5.TabIndex = 16;
            label5.Text = "Nombre: del proveedor";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(72, 249);
            label4.Name = "label4";
            label4.Size = new Size(143, 32);
            label4.TabIndex = 15;
            label4.Text = "Descripcion:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(109, 82);
            label1.Name = "label1";
            label1.Size = new Size(471, 32);
            label1.TabIndex = 14;
            label1.Text = "Ingrese los siguientes datos del proveedor:";
            label1.Click += label1_Click;
            // 
            // button1
            // 
            button1.Location = new Point(236, 340);
            button1.Name = "button1";
            button1.Size = new Size(150, 46);
            button1.TabIndex = 19;
            button1.Text = "Agregar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // AgregarProveedorFrm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(664, 446);
            Controls.Add(button1);
            Controls.Add(txtDescripcion);
            Controls.Add(txtNombreProveedor);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label1);
            Name = "AgregarProveedorFrm";
            Text = "AgregarProveedorFrm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtDescripcion;
        private TextBox txtNombreProveedor;
        private Label label5;
        private Label label4;
        private Label label1;
        private Button button1;
    }
}