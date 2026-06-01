using System;
using System.Windows.Forms;

namespace Transformador
{
    public partial class FormCarga : Form
    {

        public string[] LineasEsperado { get; private set; }
        public string[] LineasEnviado { get; private set; }

        public FormCarga()
        {
            InitializeComponent();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {

            LineasEsperado = RMEsperado.Lines;
            LineasEnviado = RMEnviado.Lines;

            this.DialogResult = DialogResult.OK;

            this.Close();
        }
    }
}