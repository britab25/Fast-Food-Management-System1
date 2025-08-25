namespace AppCore
{
    partial class ActualizarPedidoFrm
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
            txtPedidoID1 = new TextBox();
            txtNuevoEstado = new TextBox();
            label8 = new Label();
            label5 = new Label();
            label1 = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(61, 65);
            label2.Name = "label2";
            label2.Size = new Size(500, 32);
            label2.TabIndex = 53;
            label2.Text = "Ingrese el ID del pedido que desee actualizar:";
            // 
            // txtPedidoID1
            // 
            txtPedidoID1.Location = new Point(110, 144);
            txtPedidoID1.Name = "txtPedidoID1";
            txtPedidoID1.Size = new Size(402, 39);
            txtPedidoID1.TabIndex = 52;
            // 
            // txtNuevoEstado
            // 
            txtNuevoEstado.Location = new Point(276, 330);
            txtNuevoEstado.Name = "txtNuevoEstado";
            txtNuevoEstado.Size = new Size(200, 39);
            txtNuevoEstado.TabIndex = 49;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(73, 410);
            label8.Name = "label8";
            label8.Size = new Size(0, 32);
            label8.TabIndex = 48;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(110, 337);
            label5.Name = "label5";
            label5.Size = new Size(89, 32);
            label5.TabIndex = 47;
            label5.Text = "Estado:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(137, 248);
            label1.Name = "label1";
            label1.Size = new Size(275, 32);
            label1.TabIndex = 46;
            label1.Text = "Ingrese el nuevo estado:";
            // 
            // button1
            // 
            button1.Location = new Point(192, 419);
            button1.Name = "button1";
            button1.Size = new Size(150, 56);
            button1.TabIndex = 54;
            button1.Text = "Actualizar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // ActualizarPedidoFrm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(634, 544);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(txtPedidoID1);
            Controls.Add(txtNuevoEstado);
            Controls.Add(label8);
            Controls.Add(label5);
            Controls.Add(label1);
            Name = "ActualizarPedidoFrm";
            Text = "ActualizarPedidoFrm";
            Load += ActualizarPedidoFrm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private TextBox txtPedidoID1;
        private TextBox txtNuevoEstado;
        private Label label8;
        private Label label5;
        private Label label1;
        private Button button1;
    }
}