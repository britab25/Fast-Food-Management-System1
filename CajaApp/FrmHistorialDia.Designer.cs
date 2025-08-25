namespace CajaApp
{
    partial class FrmHistorialDia
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
            dtpFechaHistorial = new DateTimePicker();
            btnImprimirReporte = new Button();
            dgvVentasDia = new DataGridView();
            dgvAperturasCierres = new DataGridView();
            btnCargarHistorial = new Button();
            lblTotalVentas = new Label();
            lblTotalAperturas = new Label();
            lblTotalCierres = new Label();
            lblFechaSeleccionada = new Label();
            panel1 = new Panel();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvVentasDia).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvAperturasCierres).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dtpFechaHistorial
            // 
            dtpFechaHistorial.Location = new Point(536, 86);
            dtpFechaHistorial.Name = "dtpFechaHistorial";
            dtpFechaHistorial.Size = new Size(250, 27);
            dtpFechaHistorial.TabIndex = 0;
            // 
            // btnImprimirReporte
            // 
            btnImprimirReporte.Location = new Point(513, 398);
            btnImprimirReporte.Name = "btnImprimirReporte";
            btnImprimirReporte.Size = new Size(94, 29);
            btnImprimirReporte.TabIndex = 1;
            btnImprimirReporte.Text = "Imprimir";
            btnImprimirReporte.UseVisualStyleBackColor = true;
            btnImprimirReporte.Click += btnImprimirReporte_Click;
            // 
            // dgvVentasDia
            // 
            dgvVentasDia.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVentasDia.Location = new Point(417, 124);
            dgvVentasDia.Name = "dgvVentasDia";
            dgvVentasDia.RowHeadersWidth = 51;
            dgvVentasDia.Size = new Size(341, 211);
            dgvVentasDia.TabIndex = 2;
            dgvVentasDia.CellContentClick += dgvVentasDia_CellContentClick;
            // 
            // dgvAperturasCierres
            // 
            dgvAperturasCierres.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAperturasCierres.Location = new Point(34, 124);
            dgvAperturasCierres.Name = "dgvAperturasCierres";
            dgvAperturasCierres.RowHeadersWidth = 51;
            dgvAperturasCierres.Size = new Size(336, 211);
            dgvAperturasCierres.TabIndex = 3;
            // 
            // btnCargarHistorial
            // 
            btnCargarHistorial.Location = new Point(216, 398);
            btnCargarHistorial.Name = "btnCargarHistorial";
            btnCargarHistorial.Size = new Size(94, 29);
            btnCargarHistorial.TabIndex = 4;
            btnCargarHistorial.Text = "Cargar";
            btnCargarHistorial.UseVisualStyleBackColor = true;
            btnCargarHistorial.Click += btnCargarHistorial_Click;
            // 
            // lblTotalVentas
            // 
            lblTotalVentas.AutoSize = true;
            lblTotalVentas.Location = new Point(12, 338);
            lblTotalVentas.Name = "lblTotalVentas";
            lblTotalVentas.Size = new Size(40, 20);
            lblTotalVentas.TabIndex = 5;
            lblTotalVentas.Text = "total";
            // 
            // lblTotalAperturas
            // 
            lblTotalAperturas.AutoSize = true;
            lblTotalAperturas.Location = new Point(12, 368);
            lblTotalAperturas.Name = "lblTotalAperturas";
            lblTotalAperturas.Size = new Size(50, 20);
            lblTotalAperturas.TabIndex = 6;
            lblTotalAperturas.Text = "label2";
            // 
            // lblTotalCierres
            // 
            lblTotalCierres.AutoSize = true;
            lblTotalCierres.Location = new Point(398, 338);
            lblTotalCierres.Name = "lblTotalCierres";
            lblTotalCierres.Size = new Size(50, 20);
            lblTotalCierres.TabIndex = 7;
            lblTotalCierres.Text = "label3";
            // 
            // lblFechaSeleccionada
            // 
            lblFechaSeleccionada.AutoSize = true;
            lblFechaSeleccionada.Location = new Point(398, 368);
            lblFechaSeleccionada.Name = "lblFechaSeleccionada";
            lblFechaSeleccionada.Size = new Size(50, 20);
            lblFechaSeleccionada.TabIndex = 8;
            lblFechaSeleccionada.Text = "label4";
            // 
            // panel1
            // 
            panel1.BackColor = Color.Red;
            panel1.Controls.Add(label1);
            panel1.Controls.Add(dtpFechaHistorial);
            panel1.ForeColor = Color.Red;
            panel1.Location = new Point(0, -2);
            panel1.Name = "panel1";
            panel1.Size = new Size(818, 120);
            panel1.TabIndex = 9;
            panel1.Paint += panel1_Paint;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 48F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(60, 4);
            label1.Name = "label1";
            label1.Size = new Size(455, 106);
            label1.TabIndex = 1;
            label1.Text = "HISTORIAL";
            // 
            // FrmHistorialDia
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblFechaSeleccionada);
            Controls.Add(panel1);
            Controls.Add(lblTotalCierres);
            Controls.Add(btnCargarHistorial);
            Controls.Add(lblTotalAperturas);
            Controls.Add(dgvAperturasCierres);
            Controls.Add(lblTotalVentas);
            Controls.Add(dgvVentasDia);
            Controls.Add(btnImprimirReporte);
            Name = "FrmHistorialDia";
            Text = "FrmHistorialDia";
            Load += FrmHistorialDia_Load;
            ((System.ComponentModel.ISupportInitialize)dgvVentasDia).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvAperturasCierres).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvHistorial;
        private Label lblTitulo;
        private Button btnActualizar;
        private DateTimePicker dtpFechaHistorial;
        private Button btnImprimirReporte;
        private DataGridView dgvVentasDia;
        private DataGridView dgvAperturasCierres;
        private Button btnCargarHistorial;
        private Label lblTotalVentas;
        private Label lblTotalAperturas;
        private Label lblTotalCierres;
        private Label lblFechaSeleccionada;
        private Panel panel1;
        private Label label1;
    }
}