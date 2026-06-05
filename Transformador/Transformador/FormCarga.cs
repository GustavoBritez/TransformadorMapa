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
            var (LineasEsperado, LineasEnviado) = Archivo.LeerMapasDesdeArchivo();

            if (LineasEsperado.Length > 0 && LineasEnviado.Length > 0)
            {
                this.LineasEsperado = LineasEsperado;
                this.LineasEnviado = LineasEnviado;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}