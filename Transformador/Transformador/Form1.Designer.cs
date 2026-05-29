namespace Transformador
{
    partial class Form1
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
            btnActualizar = new Button();
            btnMEsperado = new Button();
            btnMEnviado = new Button();
            dgvMEnviado = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvMEsperado).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvMEnviado).BeginInit();
            SuspendLayout();
            // 
            // dgvMEsperado
            // 
            dgvMEsperado.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMEsperado.Location = new Point(12, 12);
            dgvMEsperado.Name = "dgvMEsperado";
            dgvMEsperado.Size = new Size(616, 550);
            dgvMEsperado.TabIndex = 0;
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(713, 568);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(129, 38);
            btnActualizar.TabIndex = 1;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // btnMEsperado
            // 
            btnMEsperado.Location = new Point(443, 568);
            btnMEsperado.Name = "btnMEsperado";
            btnMEsperado.Size = new Size(129, 38);
            btnMEsperado.TabIndex = 2;
            btnMEsperado.Text = "MEsperado";
            btnMEsperado.UseVisualStyleBackColor = true;
            btnMEsperado.Click += btnMEsperado_Click;
            // 
            // btnMEnviado
            // 
            btnMEnviado.Location = new Point(578, 568);
            btnMEnviado.Name = "btnMEnviado";
            btnMEnviado.Size = new Size(129, 38);
            btnMEnviado.TabIndex = 3;
            btnMEnviado.Text = "MEnviado";
            btnMEnviado.UseVisualStyleBackColor = true;
            btnMEnviado.Click += btnMEnviado_Click;
            // 
            // dgvMEnviado
            // 
            dgvMEnviado.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMEnviado.Location = new Point(646, 12);
            dgvMEnviado.Name = "dgvMEnviado";
            dgvMEnviado.Size = new Size(616, 550);
            dgvMEnviado.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(165, 568);
            label1.Name = "label1";
            label1.Size = new Size(66, 15);
            label1.TabIndex = 5;
            label1.Text = "MEsperado";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(1005, 568);
            label2.Name = "label2";
            label2.Size = new Size(60, 15);
            label2.TabIndex = 6;
            label2.Text = "MEnviado";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1300, 618);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dgvMEnviado);
            Controls.Add(btnMEnviado);
            Controls.Add(btnMEsperado);
            Controls.Add(btnActualizar);
            Controls.Add(dgvMEsperado);
            Name = "Form1";
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
        private Button btnMEnviado;
        private DataGridView dgvMEnviado;
        private Label label1;
        private Label label2;
    }
}
