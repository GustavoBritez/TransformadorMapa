namespace Transformador
{
    partial class VistaMapas
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvMEsperado = new DataGridView();
            btnSubir = new Button();
            label1 = new Label();
            label2 = new Label();
            dgvMEnviado = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvMEsperado).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvMEnviado).BeginInit();
            SuspendLayout();
            // 
            // dgvMEsperado
            // 
            dgvMEsperado.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMEsperado.Location = new Point(12, 12);
            dgvMEsperado.Name = "dgvMEsperado";
            dgvMEsperado.Size = new Size(928, 674);
            dgvMEsperado.TabIndex = 0;
            // 
            // btnSubir
            // 
            btnSubir.Location = new Point(825, 692);
            btnSubir.Name = "btnSubir";
            btnSubir.Size = new Size(129, 38);
            btnSubir.TabIndex = 3;
            btnSubir.Text = "Subir Mapas";
            btnSubir.UseVisualStyleBackColor = true;
            btnSubir.Click += btnSubir_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(249, 692);
            label1.Name = "label1";
            label1.Size = new Size(66, 15);
            label1.TabIndex = 5;
            label1.Text = "MEsperado";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(1424, 692);
            label2.Name = "label2";
            label2.Size = new Size(60, 15);
            label2.TabIndex = 6;
            label2.Text = "MEnviado";
            // 
            // dgvMEnviado
            // 
            dgvMEnviado.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMEnviado.Location = new Point(946, 12);
            dgvMEnviado.Name = "dgvMEnviado";
            dgvMEnviado.Size = new Size(928, 674);
            dgvMEnviado.TabIndex = 4;
            // 
            // VistaMapas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1881, 734);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dgvMEnviado);
            Controls.Add(btnSubir);
            Controls.Add(dgvMEsperado);
            Name = "VistaMapas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dgvMEsperado).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvMEnviado).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvMEsperado;
        private Button btnActualizar;
        private Button btnMEsperado;
        private Button btnSubir;
        private Label label1;
        private Label label2;
        private DataGridView dgvMEnviado;
    }
}
