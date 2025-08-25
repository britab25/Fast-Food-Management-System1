namespace CajaApp
{
    partial class FrmImprimirRecibo
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
            dgvFacturas = new DataGridView();
            dgvDetalle = new DataGridView();
            lblTotal = new Label();
            lblEstado = new Label();
            lblFechaFactura = new Label();
            label1 = new Label();
            label2 = new Label();
            btnMarcarPendiente = new Button();
            btnMarcarCompletado = new Button();
            btnImprimir = new Button();
            btnSeleccionarFactura = new Button();
            panel1 = new Panel();
            FACTURAS = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvFacturas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDetalle).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvFacturas
            // 
            dgvFacturas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFacturas.Location = new Point(22, 105);
            dgvFacturas.Name = "dgvFacturas";
            dgvFacturas.RowHeadersWidth = 51;
            dgvFacturas.Size = new Size(300, 233);
            dgvFacturas.TabIndex = 0;
            // 
            // dgvDetalle
            // 
            dgvDetalle.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetalle.Location = new Point(443, 105);
            dgvDetalle.Name = "dgvDetalle";
            dgvDetalle.RowHeadersWidth = 51;
            dgvDetalle.Size = new Size(300, 233);
            dgvDetalle.TabIndex = 1;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(112, 357);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(42, 20);
            lblTotal.TabIndex = 2;
            lblTotal.Text = "Total";
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Location = new Point(354, 357);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(54, 20);
            lblEstado.TabIndex = 4;
            lblEstado.Text = "Estado";
            // 
            // lblFechaFactura
            // 
            lblFechaFactura.AutoSize = true;
            lblFechaFactura.Location = new Point(528, 357);
            lblFechaFactura.Name = "lblFechaFactura";
            lblFechaFactura.Size = new Size(47, 20);
            lblFechaFactura.TabIndex = 5;
            lblFechaFactura.Text = "Fecha";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(343, 383);
            label1.Name = "label1";
            label1.Size = new Size(0, 20);
            label1.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(432, 383);
            label2.Name = "label2";
            label2.Size = new Size(0, 20);
            label2.TabIndex = 7;
            // 
            // btnMarcarPendiente
            // 
            btnMarcarPendiente.Location = new Point(217, 379);
            btnMarcarPendiente.Name = "btnMarcarPendiente";
            btnMarcarPendiente.Size = new Size(105, 29);
            btnMarcarPendiente.TabIndex = 8;
            btnMarcarPendiente.Text = "Pendiente";
            btnMarcarPendiente.UseVisualStyleBackColor = true;
            btnMarcarPendiente.Click += btnMarcarPendiente_Click;
            // 
            // btnMarcarCompletado
            // 
            btnMarcarCompletado.Location = new Point(443, 383);
            btnMarcarCompletado.Name = "btnMarcarCompletado";
            btnMarcarCompletado.Size = new Size(105, 29);
            btnMarcarCompletado.TabIndex = 9;
            btnMarcarCompletado.Text = "Completado";
            btnMarcarCompletado.UseVisualStyleBackColor = true;
            btnMarcarCompletado.Click += btnMarcarCompletado_Click;
            // 
            // btnImprimir
            // 
            btnImprimir.Location = new Point(443, 415);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new Size(105, 29);
            btnImprimir.TabIndex = 10;
            btnImprimir.Text = "Imprimir";
            btnImprimir.UseVisualStyleBackColor = true;
            btnImprimir.Click += btnImprimir_Click;
            // 
            // btnSeleccionarFactura
            // 
            btnSeleccionarFactura.Location = new Point(217, 415);
            btnSeleccionarFactura.Name = "btnSeleccionarFactura";
            btnSeleccionarFactura.Size = new Size(105, 29);
            btnSeleccionarFactura.TabIndex = 11;
            btnSeleccionarFactura.Text = "Seleccionar";
            btnSeleccionarFactura.UseVisualStyleBackColor = true;
            btnSeleccionarFactura.Click += btnSeleccionarFactura_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Red;
            panel1.Controls.Add(FACTURAS);
            panel1.Location = new Point(1, -4);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 103);
            panel1.TabIndex = 12;
            // 
            // FACTURAS
            // 
            FACTURAS.AutoSize = true;
            FACTURAS.Font = new Font("Segoe UI", 48F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FACTURAS.ForeColor = SystemColors.ControlLightLight;
            FACTURAS.Location = new Point(216, 0);
            FACTURAS.Name = "FACTURAS";
            FACTURAS.Size = new Size(372, 106);
            FACTURAS.TabIndex = 0;
            FACTURAS.Text = "RECIBOS";
            FACTURAS.Click += label3_Click;
            // 
            // FrmImprimirRecibo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Controls.Add(btnSeleccionarFactura);
            Controls.Add(btnImprimir);
            Controls.Add(btnMarcarCompletado);
            Controls.Add(btnMarcarPendiente);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblFechaFactura);
            Controls.Add(lblEstado);
            Controls.Add(lblTotal);
            Controls.Add(dgvDetalle);
            Controls.Add(dgvFacturas);
            Name = "FrmImprimirRecibo";
            Text = "FrmImprimirRecibo";
            Load += FrmImprimirRecibo_Load;
            ((System.ComponentModel.ISupportInitialize)dgvFacturas).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDetalle).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvFacturas;
        private DataGridView dgvDetalle;
        private Label lblTotal;
        private Label lblEstado;
        private Label lblFechaFactura;
        private Label label1;
        private Label label2;
        private Button btnMarcarPendiente;
        private Button btnMarcarCompletado;
        private Button btnImprimir;
        private Button btnSeleccionarFactura;
        private Panel panel1;
        private Label FACTURAS;
    }
}