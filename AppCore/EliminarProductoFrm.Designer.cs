namespace AppCore
{
    partial class EliminarProductoFrm
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
            txtProductoId = new TextBox();
            label2 = new Label();
            SuspendLayout();
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(208, 232);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(150, 46);
            btnEliminar.TabIndex = 38;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // txtProductoId
            // 
            txtProductoId.Location = new Point(110, 159);
            txtProductoId.Name = "txtProductoId";
            txtProductoId.Size = new Size(338, 39);
            txtProductoId.TabIndex = 37;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(87, 73);
            label2.Name = "label2";
            label2.Size = new Size(406, 32);
            label2.TabIndex = 36;
            label2.Text = "Ingrese el Id del producto a eliminar:";
            // 
            // EliminarProductoFrm
            // 
            AccessibleRole = AccessibleRole.PageTabList;
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(550, 356);
            Controls.Add(btnEliminar);
            Controls.Add(txtProductoId);
            Controls.Add(label2);
            Name = "EliminarProductoFrm";
            Text = "EliminarProductoFrm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnEliminar;
        private TextBox txtProductoId;
        private Label label2;
    }
}