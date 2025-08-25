namespace AppCore
{
    partial class EliminarUsuario
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
            txtUsuarioId = new TextBox();
            label2 = new Label();
            SuspendLayout();
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(243, 247);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(150, 46);
            btnEliminar.TabIndex = 35;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // txtUsuarioId
            // 
            txtUsuarioId.Location = new Point(145, 174);
            txtUsuarioId.Name = "txtUsuarioId";
            txtUsuarioId.Size = new Size(338, 39);
            txtUsuarioId.TabIndex = 34;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(122, 88);
            label2.Name = "label2";
            label2.Size = new Size(387, 32);
            label2.TabIndex = 33;
            label2.Text = "Ingrese el Id del usuario a eliminar:";
            // 
            // EliminarUsuario
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(652, 406);
            Controls.Add(btnEliminar);
            Controls.Add(txtUsuarioId);
            Controls.Add(label2);
            Name = "EliminarUsuario";
            Text = "EliminarUsuario";
            Load += EliminarUsuario_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnEliminar;
        private TextBox txtUsuarioId;
        private Label label2;
    }
}