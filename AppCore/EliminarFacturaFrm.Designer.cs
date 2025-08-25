namespace AppCore
{
    partial class EliminarFacturaFrm
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
            txtFacturaId = new TextBox();
            label2 = new Label();
            SuspendLayout();
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(261, 210);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(150, 46);
            btnEliminar.TabIndex = 35;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // txtFacturaId
            // 
            txtFacturaId.Location = new Point(163, 137);
            txtFacturaId.Name = "txtFacturaId";
            txtFacturaId.Size = new Size(338, 39);
            txtFacturaId.TabIndex = 34;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(22, 61);
            label2.Name = "label2";
            label2.Size = new Size(608, 32);
            label2.TabIndex = 33;
            label2.Text = "Ingrese el numero de documento del cliente a eliminar:";
            // 
            // EliminarFacturaFrm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(652, 316);
            Controls.Add(btnEliminar);
            Controls.Add(txtFacturaId);
            Controls.Add(label2);
            Name = "EliminarFacturaFrm";
            Text = "EliminarFacturaFrm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnEliminar;
        private TextBox txtFacturaId;
        private Label label2;
    }
}