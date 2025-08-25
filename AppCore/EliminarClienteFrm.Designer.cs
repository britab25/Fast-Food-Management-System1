namespace AppCore
{
    partial class EliminarClienteFrm
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
            txtNumeroDocumento = new TextBox();
            label2 = new Label();
            btnEliminar = new Button();
            SuspendLayout();
            // 
            // txtNumeroDocumento
            // 
            txtNumeroDocumento.Location = new Point(194, 112);
            txtNumeroDocumento.Name = "txtNumeroDocumento";
            txtNumeroDocumento.Size = new Size(338, 39);
            txtNumeroDocumento.TabIndex = 27;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(53, 36);
            label2.Name = "label2";
            label2.Size = new Size(608, 32);
            label2.TabIndex = 26;
            label2.Text = "Ingrese el numero de documento del cliente a eliminar:";
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(292, 185);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(150, 46);
            btnEliminar.TabIndex = 32;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // EliminarClienteFrm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(718, 276);
            Controls.Add(btnEliminar);
            Controls.Add(txtNumeroDocumento);
            Controls.Add(label2);
            Name = "EliminarClienteFrm";
            Text = "EliminarClienteFrm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNumeroDocumento;
        private Label label2;
        private Button btnEliminar;
    }
}