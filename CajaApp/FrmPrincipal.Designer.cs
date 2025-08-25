namespace CajaApp
{
    partial class FrmPrincipal
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
            btnVender = new Button();
            btnImprimirRecibo = new Button();
            btnHistorial = new Button();
            btnCierreDia = new Button();
            panel1 = new Panel();
            label1 = new Label();
            lblHora = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            btnInicioDia = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnVender
            // 
            btnVender.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnVender.Location = new Point(390, 149);
            btnVender.Name = "btnVender";
            btnVender.Size = new Size(212, 83);
            btnVender.TabIndex = 0;
            btnVender.Text = "Vender";
            btnVender.UseVisualStyleBackColor = true;
            btnVender.Click += btnVender_Click_1;
            // 
            // btnImprimirRecibo
            // 
            btnImprimirRecibo.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnImprimirRecibo.Location = new Point(390, 254);
            btnImprimirRecibo.Name = "btnImprimirRecibo";
            btnImprimirRecibo.Size = new Size(212, 83);
            btnImprimirRecibo.TabIndex = 1;
            btnImprimirRecibo.Text = "Recibo";
            btnImprimirRecibo.UseVisualStyleBackColor = true;
            btnImprimirRecibo.Click += btnImprimirRecibo_Click;
            // 
            // btnHistorial
            // 
            btnHistorial.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHistorial.Location = new Point(42, 254);
            btnHistorial.Name = "btnHistorial";
            btnHistorial.Size = new Size(212, 80);
            btnHistorial.TabIndex = 2;
            btnHistorial.Text = "Historial";
            btnHistorial.UseVisualStyleBackColor = true;
            btnHistorial.Click += btnHistorial_Click;
            // 
            // btnCierreDia
            // 
            btnCierreDia.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCierreDia.Location = new Point(42, 358);
            btnCierreDia.Name = "btnCierreDia";
            btnCierreDia.Size = new Size(212, 80);
            btnCierreDia.TabIndex = 4;
            btnCierreDia.Text = "Cierre";
            btnCierreDia.UseVisualStyleBackColor = true;
            btnCierreDia.Click += btnCierreDia_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Red;
            panel1.Controls.Add(label1);
            panel1.Location = new Point(1, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(802, 143);
            panel1.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 48F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(21, 9);
            label1.Name = "label1";
            label1.Size = new Size(611, 106);
            label1.TabIndex = 0;
            label1.Text = "Menu Principal";
            // 
            // lblHora
            // 
            lblHora.AutoSize = true;
            lblHora.Location = new Point(470, 445);
            lblHora.Name = "lblHora";
            lblHora.Size = new Size(163, 20);
            lblHora.TabIndex = 1;
            lblHora.Text = "dd/MM/yyyy HH:mm:ss";
            lblHora.Click += lblHora_Click;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // btnInicioDia
            // 
            btnInicioDia.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnInicioDia.Location = new Point(42, 149);
            btnInicioDia.Name = "btnInicioDia";
            btnInicioDia.Size = new Size(212, 83);
            btnInicioDia.TabIndex = 6;
            btnInicioDia.Text = "Entrada";
            btnInicioDia.UseVisualStyleBackColor = true;
            // 
            // FrmPrincipal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(643, 473);
            Controls.Add(btnInicioDia);
            Controls.Add(lblHora);
            Controls.Add(panel1);
            Controls.Add(btnCierreDia);
            Controls.Add(btnHistorial);
            Controls.Add(btnImprimirRecibo);
            Controls.Add(btnVender);
            Name = "FrmPrincipal";
            Text = "FrmPrincipal";
            Load += FrmPrincipal_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnVender;
        private Button btnImprimirRecibo;
        private Button btnHistorial;
        private Button btnCierreDia;
        private Panel panel1;
        private Label label1;
        private Label lblHora;
        private System.Windows.Forms.Timer timer1;
        private Button btnInicioDia;
    }
}