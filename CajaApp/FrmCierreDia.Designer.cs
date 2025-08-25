namespace CajaApp
{
    partial class FrmCierreDia
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
            lblEstado = new Label();
            txtMontoFinal = new TextBox();
            btnCerrarDia = new Button();
            txtObservacion = new TextBox();
            panel1 = new Panel();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            timerHora = new System.Windows.Forms.Timer(components);
            lblCajero = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Location = new Point(373, 374);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(0, 20);
            lblEstado.TabIndex = 4;
            // 
            // txtMontoFinal
            // 
            txtMontoFinal.Location = new Point(320, 228);
            txtMontoFinal.Name = "txtMontoFinal";
            txtMontoFinal.Size = new Size(125, 27);
            txtMontoFinal.TabIndex = 5;
            // 
            // btnCerrarDia
            // 
            btnCerrarDia.Location = new Point(335, 342);
            btnCerrarDia.Name = "btnCerrarDia";
            btnCerrarDia.Size = new Size(94, 29);
            btnCerrarDia.TabIndex = 6;
            btnCerrarDia.Text = "Cierre";
            btnCerrarDia.UseVisualStyleBackColor = true;
            btnCerrarDia.Click += btnCerrarDia_Click;
            // 
            // txtObservacion
            // 
            txtObservacion.Location = new Point(320, 295);
            txtObservacion.Name = "txtObservacion";
            txtObservacion.Size = new Size(125, 27);
            txtObservacion.TabIndex = 7;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Red;
            panel1.Controls.Add(label1);
            panel1.Location = new Point(-4, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(812, 161);
            panel1.TabIndex = 10;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 48F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(239, 31);
            label1.Name = "label1";
            label1.Size = new Size(310, 106);
            label1.TabIndex = 0;
            label1.Text = "CIERRE";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(332, 272);
            label2.Name = "label2";
            label2.Size = new Size(94, 20);
            label2.TabIndex = 1;
            label2.Text = "Observacion:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(325, 195);
            label3.Name = "label3";
            label3.Size = new Size(120, 20);
            label3.TabIndex = 2;
            label3.Text = "Monto de Cierre:";
            // 
            // lblCajero
            // 
            lblCajero.AutoSize = true;
            lblCajero.Location = new Point(667, 401);
            lblCajero.Name = "lblCajero";
            lblCajero.Size = new Size(50, 20);
            lblCajero.TabIndex = 11;
            lblCajero.Text = "label4";
            // 
            // FrmCierreDia
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblCajero);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(panel1);
            Controls.Add(txtObservacion);
            Controls.Add(btnCerrarDia);
            Controls.Add(txtMontoFinal);
            Controls.Add(lblEstado);
            Name = "FrmCierreDia";
            Text = "FrmCierreDia";
            Load += FrmCierreDia_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblEstado;
        private TextBox txtMontoFinal;
        private Button btnCerrarDia;
        private TextBox txtObservacion;
        private Panel panel1;
        private Label label1;
        private Label label2;
        private Label label3;
        private System.Windows.Forms.Timer timerHora;
        private Label lblCajero;
    }
}