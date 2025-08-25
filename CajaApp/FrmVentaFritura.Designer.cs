
namespace CajaApp
{
    partial class FrmVentaFritura
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
            cmbProductos = new ComboBox();
            txtCantidad = new TextBox();
            txtNombreCliente = new TextBox();
            btnAgregarProducto = new Button();
            btnConfirmarVenta = new Button();
            btnCancelar = new Button();
            dgvOrden = new DataGridView();
            lblTotal = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            panel1 = new Panel();
            VENTAS = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvOrden).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // cmbProductos
            // 
            cmbProductos.FormattingEnabled = true;
            cmbProductos.Location = new Point(56, 167);
            cmbProductos.Name = "cmbProductos";
            cmbProductos.Size = new Size(151, 28);
            cmbProductos.TabIndex = 0;
            // 
            // txtCantidad
            // 
            txtCantidad.Location = new Point(56, 221);
            txtCantidad.Name = "txtCantidad";
            txtCantidad.Size = new Size(125, 27);
            txtCantidad.TabIndex = 1;
            // 
            // txtNombreCliente
            // 
            txtNombreCliente.Location = new Point(56, 289);
            txtNombreCliente.Name = "txtNombreCliente";
            txtNombreCliente.Size = new Size(125, 27);
            txtNombreCliente.TabIndex = 2;
            // 
            // btnAgregarProducto
            // 
            btnAgregarProducto.Location = new Point(56, 347);
            btnAgregarProducto.Name = "btnAgregarProducto";
            btnAgregarProducto.Size = new Size(94, 29);
            btnAgregarProducto.TabIndex = 3;
            btnAgregarProducto.Text = "Agregar";
            btnAgregarProducto.UseVisualStyleBackColor = true;
            btnAgregarProducto.Click += btnAgregarProducto_Click;
            // 
            // btnConfirmarVenta
            // 
            btnConfirmarVenta.Location = new Point(87, 400);
            btnConfirmarVenta.Name = "btnConfirmarVenta";
            btnConfirmarVenta.Size = new Size(94, 29);
            btnConfirmarVenta.TabIndex = 4;
            btnConfirmarVenta.Text = "Pagar";
            btnConfirmarVenta.UseVisualStyleBackColor = true;
            btnConfirmarVenta.Click += btnConfirmarVenta_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(234, 400);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(94, 29);
            btnCancelar.TabIndex = 5;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // dgvOrden
            // 
            dgvOrden.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOrden.Location = new Point(310, 128);
            dgvOrden.Name = "dgvOrden";
            dgvOrden.RowHeadersWidth = 51;
            dgvOrden.Size = new Size(356, 248);
            dgvOrden.TabIndex = 6;
            dgvOrden.CellContentClick += dgvOrden_CellContentClick;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(458, 404);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(50, 20);
            lblTotal.TabIndex = 7;
            lblTotal.Text = "label1";
            lblTotal.Click += lblTotal_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(51, 198);
            label1.Name = "label1";
            label1.Size = new Size(178, 20);
            label1.TabIndex = 8;
            label1.Text = "Seleccionar una cantidad:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(56, 135);
            label2.Name = "label2";
            label2.Size = new Size(173, 20);
            label2.TabIndex = 9;
            label2.Text = "Seleccionar un producto:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(56, 266);
            label3.Name = "label3";
            label3.Size = new Size(142, 20);
            label3.TabIndex = 10;
            label3.Text = "Nombre del Cliente:";
            // 
            // panel1
            // 
            panel1.BackColor = Color.Red;
            panel1.Controls.Add(VENTAS);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(696, 122);
            panel1.TabIndex = 11;
            panel1.Paint += panel1_Paint;
            // 
            // VENTAS
            // 
            VENTAS.AutoSize = true;
            VENTAS.Font = new Font("Segoe UI", 48F, FontStyle.Bold, GraphicsUnit.Point, 0);
            VENTAS.ForeColor = SystemColors.ButtonHighlight;
            VENTAS.Location = new Point(162, 9);
            VENTAS.Name = "VENTAS";
            VENTAS.Size = new Size(346, 106);
            VENTAS.TabIndex = 0;
            VENTAS.Text = "VENTAS";
            // 
            // FrmVentaFritura
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(697, 450);
            Controls.Add(label2);
            Controls.Add(panel1);
            Controls.Add(cmbProductos);
            Controls.Add(label1);
            Controls.Add(label3);
            Controls.Add(lblTotal);
            Controls.Add(dgvOrden);
            Controls.Add(btnCancelar);
            Controls.Add(btnConfirmarVenta);
            Controls.Add(btnAgregarProducto);
            Controls.Add(txtNombreCliente);
            Controls.Add(txtCantidad);
            Name = "FrmVentaFritura";
            Text = "FrmVentaFritura";
            Load += FrmVentaFritura_Load;
            ((System.ComponentModel.ISupportInitialize)dgvOrden).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }


        #endregion

        private ComboBox cmbProductos;
        private TextBox txtCantidad;
        private TextBox txtNombreCliente;
        private Button btnAgregarProducto;
        private Button btnConfirmarVenta;
        private Button btnCancelar;
        private DataGridView dgvOrden;
        private Label lblTotal;
        private Label label1;
        private Label label2;
        private Label label3;
        private Panel panel1;
        private Label VENTAS;
    }
}