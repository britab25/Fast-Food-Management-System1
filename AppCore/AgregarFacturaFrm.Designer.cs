namespace AppCore
{
    partial class AgregarFacturaFrm
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
            label4 = new Label();
            txtTotal = new TextBox();
            label3 = new Label();
            Cantidad = new Label();
            txtPedidoID5 = new TextBox();
            button2 = new Button();
            label1 = new Label();
            cmbEstado = new ComboBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(325, 281);
            button1.Name = "button1";
            button1.Size = new Size(150, 46);
            button1.TabIndex = 20;
            button1.Text = "Buscar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(187, 450);
            label4.Name = "label4";
            label4.Size = new Size(199, 32);
            label4.TabIndex = 18;
            label4.Text = "Metodo de pago:";
            // 
            // txtTotal
            // 
            txtTotal.Location = new Point(421, 361);
            txtTotal.Name = "txtTotal";
            txtTotal.Size = new Size(200, 39);
            txtTotal.TabIndex = 17;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(187, 368);
            label3.Name = "label3";
            label3.Size = new Size(70, 32);
            label3.TabIndex = 16;
            label3.Text = "Total:";
            // 
            // Cantidad
            // 
            Cantidad.AutoSize = true;
            Cantidad.Location = new Point(187, 197);
            Cantidad.Name = "Cantidad";
            Cantidad.Size = new Size(119, 32);
            Cantidad.TabIndex = 15;
            Cantidad.Text = "Pedido Id:";
            // 
            // txtPedidoID5
            // 
            txtPedidoID5.Location = new Point(421, 190);
            txtPedidoID5.Name = "txtPedidoID5";
            txtPedidoID5.Size = new Size(200, 39);
            txtPedidoID5.TabIndex = 14;
            // 
            // button2
            // 
            button2.Location = new Point(325, 545);
            button2.Name = "button2";
            button2.Size = new Size(150, 46);
            button2.TabIndex = 21;
            button2.Text = "Crear";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(233, 88);
            label1.Name = "label1";
            label1.Size = new Size(314, 32);
            label1.TabIndex = 22;
            label1.Text = "Ingrese los siguientes datos:";
            // 
            // cmbEstado
            // 
            cmbEstado.FormattingEnabled = true;
            cmbEstado.Location = new Point(421, 450);
            cmbEstado.Name = "cmbEstado";
            cmbEstado.Size = new Size(200, 40);
            cmbEstado.TabIndex = 23;
            // 
            // AgregarFacturaFrm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(808, 672);
            Controls.Add(cmbEstado);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label4);
            Controls.Add(txtTotal);
            Controls.Add(label3);
            Controls.Add(Cantidad);
            Controls.Add(txtPedidoID5);
            Name = "AgregarFacturaFrm";
            Text = "AgregarFacturaFrm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label4;
        private TextBox txtTotal;
        private Label label3;
        private Label Cantidad;
        private TextBox txtPedidoID5;
        private Button button2;
        private Label label1;
        private ComboBox cmbEstado;
    }
}