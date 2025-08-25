namespace AppCore
{
    partial class EliminarPedidoFrm
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
            btnEliminar = new Button();
            txtPedidoId = new TextBox();
            label2 = new Label();
            SuspendLayout();
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(178, 214);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(150, 46);
            btnEliminar.TabIndex = 41;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // txtPedidoId
            // 
            txtPedidoId.Location = new Point(80, 141);
            txtPedidoId.Name = "txtPedidoId";
            txtPedidoId.Size = new Size(338, 39);
            txtPedidoId.TabIndex = 40;
            txtPedidoId.TextChanged += txtPedidoId_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(57, 55);
            label2.Name = "label2";
            label2.Size = new Size(384, 32);
            label2.TabIndex = 39;
            label2.Text = "Ingrese el Id del pedido a eliminar:";
            // 
            // EliminarPedidoFrm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(542, 328);
            Controls.Add(btnEliminar);
            Controls.Add(txtPedidoId);
            Controls.Add(label2);
            Name = "EliminarPedidoFrm";
            Text = "EliminarPedidoFrm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnEliminar;
        private TextBox txtPedidoId;
        private Label label2;
    }
}