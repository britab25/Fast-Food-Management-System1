namespace AppCore
{
    partial class ActualizarProveedorFrm
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
            button1 = new Button();
            txtDescripcion = new TextBox();
            txtNombreProveedor = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label1 = new Label();
            txtCodigoProveedor = new TextBox();
            label2 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(302, 485);
            button1.Name = "button1";
            button1.Size = new Size(150, 46);
            button1.TabIndex = 25;
            button1.Text = "Agregar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(446, 391);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(200, 39);
            txtDescripcion.TabIndex = 24;
            // 
            // txtNombreProveedor
            // 
            txtNombreProveedor.Location = new Point(446, 323);
            txtNombreProveedor.Name = "txtNombreProveedor";
            txtNombreProveedor.Size = new Size(200, 39);
            txtNombreProveedor.TabIndex = 23;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(138, 330);
            label5.Name = "label5";
            label5.Size = new Size(264, 32);
            label5.TabIndex = 22;
            label5.Text = "Nombre: del proveedor";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(138, 394);
            label4.Name = "label4";
            label4.Size = new Size(143, 32);
            label4.TabIndex = 21;
            label4.Text = "Descripcion:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(107, 237);
            label1.Name = "label1";
            label1.Size = new Size(588, 32);
            label1.TabIndex = 20;
            label1.Text = "Ingrese los datos del proveedor que desee actualizar: ";
            // 
            // txtCodigoProveedor
            // 
            txtCodigoProveedor.Location = new Point(175, 130);
            txtCodigoProveedor.Name = "txtCodigoProveedor";
            txtCodigoProveedor.Size = new Size(438, 39);
            txtCodigoProveedor.TabIndex = 26;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(177, 52);
            label2.Name = "label2";
            label2.Size = new Size(436, 32);
            label2.TabIndex = 27;
            label2.Text = "Ingrese el ID del proveedor a modificar:";
            // 
            // ActualizarProveedorFrm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(806, 588);
            Controls.Add(label2);
            Controls.Add(txtCodigoProveedor);
            Controls.Add(button1);
            Controls.Add(txtDescripcion);
            Controls.Add(txtNombreProveedor);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label1);
            Name = "ActualizarProveedorFrm";
            Text = "ActualizarProveedorFrm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox txtDescripcion;
        private TextBox txtNombreProveedor;
        private Label label5;
        private Label label4;
        private Label label1;
        private TextBox txtCodigoProveedor;
        private Label label2;
    }
}