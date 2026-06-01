using System;
using System.Drawing;
using System.Linq; // Agregado para poder limpiar líneas vacías
using System.Windows.Forms;

namespace Transformador
{
    public partial class VistaMapas : Form
    {
        public VistaMapas()
        {
            InitializeComponent();
        }

        // Evento que abre el formulario de carga
        private void btnSubir_Click(object sender, EventArgs e)
        {
            // Instanciamos el formulario secundario
            using (FormCarga formCarga = new FormCarga())
            {
                // Mostramos el formulario y esperamos a que el usuario presione "Cargar" (DialogResult.OK)
                if (formCarga.ShowDialog() == DialogResult.OK)
                {
                    // Si todo salió bien, le pasamos los datos a los DataGridViews
                    CargarMapaEspecifico(formCarga.LineasEsperado, dgvMEsperado);
                    CargarMapaEspecifico(formCarga.LineasEnviado, dgvMEnviado);
                }
            }
        }

        /// <summary>
        /// Recibe directamente las líneas de texto y las dibuja en el grid.
        /// </summary>
        private void CargarMapaEspecifico(string[] lineasBrutas, DataGridView dgv)
        {
            
            string[] lineas = lineasBrutas.Where(l => !string.IsNullOrWhiteSpace(l)).ToArray();

            if (lineas == null || lineas.Length == 0)
            {
                dgv.Rows.Clear();
                dgv.Columns.Clear();
                return;
            }

            int filas = lineas.Length;

            
            int columnasMaximas = 0;
            for (int f = 0; f < filas; f++)
            {
                if (lineas[f].Length > columnasMaximas)
                {
                    columnasMaximas = lineas[f].Length;
                }
            }

            dgv.Rows.Clear();
            dgv.Columns.Clear();
            dgv.ColumnHeadersVisible = false;
            dgv.RowHeadersVisible = false;
            dgv.AllowUserToAddRows = false;
            dgv.ReadOnly = true;
            dgv.SelectionMode = DataGridViewSelectionMode.CellSelect;

            typeof(DataGridView).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty,
                null, dgv, new object[] { true });

            int dimensionCelda = 18;


            for (int c = 0; c < columnasMaximas; c++)
            {
                DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
                col.Width = dimensionCelda;
                dgv.Columns.Add(col);
            }


            for (int f = 0; f < filas; f++)
            {
                dgv.Rows.Add();
                dgv.Rows[f].Height = dimensionCelda;

                string lineaActual = lineas[f];

                for (int c = 0; c < columnasMaximas; c++)
                {
                    DataGridViewCell celda = dgv.Rows[f].Cells[c];


                    if (c < lineaActual.Length)
                    {
                        char caracter = lineaActual[c];
                        celda.Value = caracter.ToString();
                        PintarCeldaSegunCaracter(celda, caracter);
                    }
                    else
                    {

                        celda.Value = "*";
                        PintarCeldaSegunCaracter(celda, '*');
                    }
                }
            }

            dgv.ClearSelection();
        }

        private void PintarCeldaSegunCaracter(DataGridViewCell celda, char caracter)
        {
            switch (caracter)
            {
                case '0':
                    celda.Style.BackColor = Color.White;
                    celda.Style.ForeColor = Color.FromArgb(240, 240, 240);
                    break;
                case '1':
                    celda.Style.BackColor = Color.LightSkyBlue;
                    celda.Style.ForeColor = Color.DarkBlue;
                    break;
                case '2':
                    celda.Style.BackColor = Color.Black;
                    celda.Style.ForeColor = Color.White;
                    break;
                case '3':
                    celda.Style.BackColor = Color.SaddleBrown;
                    celda.Style.ForeColor = Color.White;
                    break;
                case 'b':
                    celda.Style.BackColor = Color.DarkBlue;
                    celda.Style.ForeColor = Color.White;
                    break;
                case '4':
                    celda.Style.BackColor = Color.DimGray;
                    celda.Style.ForeColor = Color.White;
                    break;
                case 'p':
                    celda.Style.BackColor = Color.MediumPurple;
                    celda.Style.ForeColor = Color.Black;
                    break;
                case '5':
                    celda.Style.BackColor = Color.ForestGreen;
                    celda.Style.ForeColor = Color.White;
                    break;
                case '*':
                    celda.Style.BackColor = Color.FromArgb(235, 235, 235);
                    celda.Style.ForeColor = Color.DarkGray;
                    break;
                default:
                    celda.Style.BackColor = Color.Orange;
                    celda.Style.ForeColor = Color.Black;
                    celda.Style.Font = new Font(celda.DataGridView.Font, FontStyle.Bold);
                    break;
            }
        }
    }
}