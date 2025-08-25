namespace AppCore
{
    partial class DetallePedidoFrm
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
            lblPedidoID = new Label();
            txtProductoID = new TextBox();
            sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            Cantidad = new Label();
            label3 = new Label();
            txtNombreProducto = new TextBox();
            label4 = new Label();
            txtCantidad = new TextBox();
            label5 = new Label();
            txtPrecioUnitario = new TextBox();
            dataGridViewDetalles = new DataGridView();
            label6 = new Label();
            sqlCommand2 = new Microsoft.Data.SqlClient.SqlCommand();
            Anadir = new Button();
            button1 = new Button();
            txtEstado = new TextBox();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewDetalles).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(240, 140);
            label1.Name = "label1";
            label1.Size = new Size(110, 32);
            label1.TabIndex = 0;
            label1.Text = "PedidoID";
            // 
            // lblPedidoID
            // 
            lblPedidoID.AutoSize = true;
            lblPedidoID.Location = new Point(474, 140);
            lblPedidoID.Name = "lblPedidoID";
            lblPedidoID.Size = new Size(78, 32);
            lblPedidoID.TabIndex = 1;
            lblPedidoID.Text = "label2";
            // 
            // txtProductoID
            // 
            txtProductoID.Location = new Point(474, 212);
            txtProductoID.Name = "txtProductoID";
            txtProductoID.Size = new Size(200, 39);
            txtProductoID.TabIndex = 2;
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // Cantidad
            // 
            Cantidad.AutoSize = true;
            Cantidad.Location = new Point(240, 219);
            Cantidad.Name = "Cantidad";
            Cantidad.Size = new Size(142, 32);
            Cantidad.TabIndex = 3;
            Cantidad.Text = "Producto Id:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(240, 390);
            label3.Name = "label3";
            label3.Size = new Size(115, 32);
            label3.TabIndex = 4;
            label3.Text = "Producto:";
            // 
            // txtNombreProducto
            // 
            txtNombreProducto.Location = new Point(474, 383);
            txtNombreProducto.Name = "txtNombreProducto";
            txtNombreProducto.Size = new Size(200, 39);
            txtNombreProducto.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(240, 472);
            label4.Name = "label4";
            label4.Size = new Size(114, 32);
            label4.TabIndex = 6;
            label4.Text = "Cantidad:";
            // 
            // txtCantidad
            // 
            txtCantidad.Location = new Point(474, 465);
            txtCantidad.Name = "txtCantidad";
            txtCantidad.Size = new Size(200, 39);
            txtCantidad.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(240, 556);
            label5.Name = "label5";
            label5.Size = new Size(175, 32);
            label5.TabIndex = 8;
            label5.Text = "Precio Unitario:";
            // 
            // txtPrecioUnitario
            // 
            txtPrecioUnitario.Location = new Point(474, 553);
            txtPrecioUnitario.Name = "txtPrecioUnitario";
            txtPrecioUnitario.Size = new Size(200, 39);
            txtPrecioUnitario.TabIndex = 9;
            // 
            // dataGridViewDetalles
            // 
            dataGridViewDetalles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewDetalles.Location = new Point(50, 812);
            dataGridViewDetalles.Name = "dataGridViewDetalles";
            dataGridViewDetalles.RowHeadersWidth = 82;
            dataGridViewDetalles.Size = new Size(888, 270);
            dataGridViewDetalles.TabIndex = 10;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(286, 61);
            label6.Name = "label6";
            label6.Size = new Size(370, 32);
            label6.TabIndex = 11;
            label6.Text = "Ingrese los detalles de su pedido:";
            // 
            // sqlCommand2
            // 
            sqlCommand2.CommandTimeout = 30;
            sqlCommand2.EnableOptimizedParameterBinding = false;
            // 
            // Anadir
            // 
            Anadir.Location = new Point(388, 733);
            Anadir.Name = "Anadir";
            Anadir.Size = new Size(150, 46);
            Anadir.TabIndex = 12;
            Anadir.Text = "Anadir";
            Anadir.UseVisualStyleBackColor = true;
            Anadir.Click += Anadir_Click;
            // 
            // button1
            // 
            button1.Location = new Point(378, 303);
            button1.Name = "button1";
            button1.Size = new Size(150, 46);
            button1.TabIndex = 13;
            button1.Text = "Buscar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // txtEstado
            // 
            txtEstado.Location = new Point(474, 640);
            txtEstado.Name = "txtEstado";
            txtEstado.Size = new Size(200, 39);
            txtEstado.TabIndex = 15;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(240, 643);
            label2.Name = "label2";
            label2.Size = new Size(89, 32);
            label2.TabIndex = 14;
            label2.Text = "Estado:";
            // 
            // DetallePedidoFrm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(994, 1138);
            Controls.Add(txtEstado);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(Anadir);
            Controls.Add(label6);
            Controls.Add(dataGridViewDetalles);
            Controls.Add(txtPrecioUnitario);
            Controls.Add(label5);
            Controls.Add(txtCantidad);
            Controls.Add(label4);
            Controls.Add(txtNombreProducto);
            Controls.Add(label3);
            Controls.Add(Cantidad);
            Controls.Add(txtProductoID);
            Controls.Add(lblPedidoID);
            Controls.Add(label1);
            Name = "DetallePedidoFrm";
            Text = "DetallePedidoFrm";
            Load += DetallePedidoFrm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewDetalles).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label lblPedidoID;
        private TextBox txtProductoID;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        private Label Cantidad;
        private Label label3;
        private TextBox txtNombreProducto;
        private Label label4;
        private TextBox txtCantidad;
        private Label label5;
        private TextBox txtPrecioUnitario;
        private DataGridView dataGridViewDetalles;
        private Label label6;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand2;
        private Button Anadir;
        private Button button1;
        private TextBox txtEstado;
        private Label label2;
    }
}