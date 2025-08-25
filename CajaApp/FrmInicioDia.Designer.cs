namespace CajaApp
{
    partial class FrmInicioDia
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
            components = new System.ComponentModel.Container();
            lblCajero = new Label();
            lblSucursal = new Label();
            txtMontoInicial = new TextBox();
            btnIniciarDia = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            lblFechaHora = new Label();
            panel1 = new Panel();
            label2 = new Label();
            label1 = new Label();
            txtObservaciones = new TextBox();
            label3 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // lblCajero
            // 
            lblCajero.AutoSize = true;
            lblCajero.Location = new Point(625, 341);
            lblCajero.Name = "lblCajero";
            lblCajero.Size = new Size(69, 20);
            lblCajero.TabIndex = 0;
            lblCajero.Text = "lblCajero";
            // 
            // lblSucursal
            // 
            lblSucursal.AutoSize = true;
            lblSucursal.Location = new Point(625, 371);
            lblSucursal.Name = "lblSucursal";
            lblSucursal.Size = new Size(139, 20);
            lblSucursal.TabIndex = 1;
            lblSucursal.Text = "Sucursal: PRINCIPAL";
            // 
            // txtMontoInicial
            // 
            txtMontoInicial.Location = new Point(327, 209);
            txtMontoInicial.Name = "txtMontoInicial";
            txtMontoInicial.Size = new Size(125, 27);
            txtMontoInicial.TabIndex = 3;
            // 
            // btnIniciarDia
            // 
            btnIniciarDia.Location = new Point(274, 330);
            btnIniciarDia.Name = "btnIniciarDia";
            btnIniciarDia.Size = new Size(236, 73);
            btnIniciarDia.TabIndex = 4;
            btnIniciarDia.Text = "Iniciar Jornada";
            btnIniciarDia.UseVisualStyleBackColor = true;
            btnIniciarDia.Click += btnIniciarDia_Click;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // lblFechaHora
            // 
            lblFechaHora.AutoSize = true;
            lblFechaHora.Location = new Point(625, 401);
            lblFechaHora.Name = "lblFechaHora";
            lblFechaHora.Size = new Size(163, 20);
            lblFechaHora.TabIndex = 5;
            lblFechaHora.Text = "dd/MM/yyyy HH:mm:ss";
            lblFechaHora.Click += lblFechaHora_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Red;
            panel1.Controls.Add(label2);
            panel1.Location = new Point(0, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(798, 143);
            panel1.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 48F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ButtonFace;
            label2.Location = new Point(190, 20);
            label2.Name = "label2";
            label2.Size = new Size(420, 106);
            label2.TabIndex = 0;
            label2.Text = "ENTRADA";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(305, 178);
            label1.Name = "label1";
            label1.Size = new Size(178, 17);
            label1.TabIndex = 7;
            label1.Text = "Ingrese el monto de Entrada:";
            // 
            // txtObservaciones
            // 
            txtObservaciones.Location = new Point(327, 287);
            txtObservaciones.Name = "txtObservaciones";
            txtObservaciones.Size = new Size(131, 27);
            txtObservaciones.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(318, 267);
            label3.Name = "label3";
            label3.Size = new Size(147, 17);
            label3.TabIndex = 9;
            label3.Text = "Comentario de Entrada:";
            label3.Click += label3_Click;
            // 
            // FrmInicioDia
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label3);
            Controls.Add(txtObservaciones);
            Controls.Add(label1);
            Controls.Add(lblCajero);
            Controls.Add(panel1);
            Controls.Add(lblFechaHora);
            Controls.Add(btnIniciarDia);
            Controls.Add(txtMontoInicial);
            Controls.Add(lblSucursal);
            Name = "FrmInicioDia";
            Text = "Form2";
            Load += FrmInicioDia_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCajero;
        private Label lblSucursal;
        private TextBox txtMontoInicial;
        private Button btnIniciarDia;
        private System.Windows.Forms.Timer timer1;
        private Label lblFechaHora;
        private Panel panel1;
        private Label label1;
        private Label label2;
        private TextBox txtObservaciones;
        private Label label3;
    }
}