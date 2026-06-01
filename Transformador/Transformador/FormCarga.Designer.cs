namespace Transformador
{
    partial class FormCarga
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
            label2 = new Label();
            label1 = new Label();
            RMEnviado = new RichTextBox();
            RMEsperado = new RichTextBox();
            btnCargar = new Button();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(857, 18);
            label2.Name = "label2";
            label2.Size = new Size(82, 15);
            label2.TabIndex = 9;
            label2.Text = "Mapa Enviado";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(213, 18);
            label1.Name = "label1";
            label1.Size = new Size(88, 15);
            label1.TabIndex = 8;
            label1.Text = "Mapa Esperado";
            // 
            // RMEnviado
            // 
            RMEnviado.Location = new Point(582, 36);
            RMEnviado.Name = "RMEnviado";
            RMEnviado.Size = new Size(581, 368);
            RMEnviado.TabIndex = 7;
            RMEnviado.Text = "";
            // 
            // RMEsperado
            // 
            RMEsperado.Location = new Point(12, 36);
            RMEsperado.Name = "RMEsperado";
            RMEsperado.Size = new Size(564, 368);
            RMEsperado.TabIndex = 6;
            RMEsperado.Text = "";
            // 
            // btnCargar
            // 
            btnCargar.Location = new Point(544, 410);
            btnCargar.Name = "btnCargar";
            btnCargar.Size = new Size(75, 23);
            btnCargar.TabIndex = 5;
            btnCargar.Text = "CARGAR";
            btnCargar.UseVisualStyleBackColor = true;
            btnCargar.Click += btnCargar_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1175, 441);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(RMEnviado);
            Controls.Add(RMEsperado);
            Controls.Add(btnCargar);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private Label label1;
        private RichTextBox RMEnviado;
        private RichTextBox RMEsperado;
        private Button btnCargar;
    }
}