using System;
using System.Drawing;
using System.Windows.Forms;

namespace Transformador
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarMapaEspecifico("MEsperado", dgvMEsperado);
            CargarMapaEspecifico("MEnviado", dgvMEnviado);
        }

        private void btnMEsperado_Click(object sender, EventArgs e)
        {
            CargarMapaEspecifico("MEsperado", dgvMEsperado);
        }


        private void btnMEnviado_Click(object sender, EventArgs e)
        {
            CargarMapaEspecifico("MEnviado", dgvMEnviado);
        }


        private void CargarMapaEspecifico(string nombreArchivo, DataGridView dgv)
        {
            string[] lineas = Archivo.LeerMapa(nombreArchivo);

            if (lineas == null || lineas.Length == 0) return;

            int filas = lineas.Length;
            int columnas = lineas[0].Length;


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

            for (int c = 0; c < columnas; c++)
            {
                DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
                col.Width = dimensionCelda;
                dgv.Columns.Add(col);
            }

            for (int f = 0; f < filas; f++)
            {
                dgv.Rows.Add();
                dgv.Rows[f].Height = dimensionCelda;
                int columnasEfectivas = Math.Min(columnas, lineas[f].Length);

                for (int c = 0; c < columnasEfectivas; c++)
                {
                    char caracter = lineas[f][c];
                    DataGridViewCell celda = dgv.Rows[f].Cells[c];

                    celda.Value = caracter.ToString();
                    PintarCeldaSegunCaracter(celda, caracter);
                }
            }
            dgv.ClearSelection();
        }

        /// <summary>
        /// Mapea los caracteres del archivo de texto a los colores requeridos.
        /// </summary>
        private void PintarCeldaSegunCaracter(DataGridViewCell celda, char caracter)
        {
            switch (caracter)
            {
                case '0':
                    celda.Style.BackColor = Color.White;
                    celda.Style.ForeColor = Color.FromArgb(240, 240, 240); // Texto chill
                    break;
                case '1':
                    celda.Style.BackColor = Color.LightSkyBlue; // Celeste o azul claro
                    celda.Style.ForeColor = Color.DarkBlue;
                    break;
                case '2':
                    celda.Style.BackColor = Color.Black;
                    celda.Style.ForeColor = Color.White;
                    break;
                case '3':
                    celda.Style.BackColor = Color.SaddleBrown; // Marrón
                    celda.Style.ForeColor = Color.White;
                    break;
                case 'b':
                    celda.Style.BackColor = Color.DarkBlue; // Azul oscuro
                    celda.Style.ForeColor = Color.White;
                    break;
                case '4':
                    celda.Style.BackColor = Color.DimGray; // Gris oscuro
                    celda.Style.ForeColor = Color.White;
                    break;
                case 'p':
                    celda.Style.BackColor = Color.MediumPurple; // Violeta
                    celda.Style.ForeColor = Color.Black;
                    break;
                case '5':
                    celda.Style.BackColor = Color.ForestGreen; // Verde
                    celda.Style.ForeColor = Color.White;
                    break;
                case '*':
                    celda.Style.BackColor = Color.FromArgb(235, 235, 235); // Fondo fuera de mapa
                    celda.Style.ForeColor = Color.DarkGray;
                    break;
                default:
                    // Cualquier letra (U, X, H, O, P, C, S, g, r...)
                    // Agregar colores para mas letras
                    celda.Style.BackColor = Color.Orange;
                    celda.Style.ForeColor = Color.Black;
                    celda.Style.Font = new Font(dgvMEsperado.Font, FontStyle.Bold);
                    break;
            }
        }
    }
}