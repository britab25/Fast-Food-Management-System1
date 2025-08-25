namespace AppCore
{
    partial class AgregarPedidoFrm
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
            label1 = new Label();
            txtClienteID = new TextBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(108, 66);
            label1.Name = "label1";
            label1.Size = new Size(556, 32);
            label1.TabIndex = 0;
            label1.Text = "Ingrese el Id del cliente correspondiente al pedido:";
            // 
            // txtClienteID
            // 
            txtClienteID.Location = new Point(244, 152);
            txtClienteID.Name = "txtClienteID";
            txtClienteID.Size = new Size(282, 39);
            txtClienteID.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new Point(296, 260);
            button1.Name = "button1";
            button1.Size = new Size(180, 46);
            button1.TabIndex = 2;
            button1.Text = "Crear pedido";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // AgregarPedidoFrm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(txtClienteID);
            Controls.Add(label1);
            Name = "AgregarPedidoFrm";
            Text = "AgregarPedidoFrm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtClienteID;
        private Button button1;
    }
}