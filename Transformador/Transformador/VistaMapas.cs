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

        private void btnSubir_Click(object sender, EventArgs e)
        {
            using (FormCarga formCarga = new FormCarga())
            {
                if (formCarga.ShowDialog() == DialogResult.OK)
                {
                    dgvMEsperado.CurrentCellChanged -= Grid_CurrentCellChanged;
                    dgvMEnviado.CurrentCellChanged -= Grid_CurrentCellChanged;

                    CargarMapaEspecifico(formCarga.LineasEsperado, dgvMEsperado);
                    CargarMapaEspecifico(formCarga.LineasEnviado, dgvMEnviado, formCarga.LineasEsperado);

                    dgvMEsperado.CurrentCellChanged += Grid_CurrentCellChanged;
                    dgvMEnviado.CurrentCellChanged += Grid_CurrentCellChanged;
                }
            }
        }

        /// <summary>
        /// Sincroniza la celda seleccionada entre dgvMEsperado y dgvMEnviado en tiempo real.
        /// </summary>
        private void Grid_CurrentCellChanged(object sender, EventArgs e)
        {
            DataGridView gridOrigen = (DataGridView)sender;

            DataGridView gridDestino = (gridOrigen == dgvMEsperado) ? dgvMEnviado : dgvMEsperado;

            if (gridOrigen.CurrentCell != null && gridDestino.Rows.Count > 0 && gridDestino.Columns.Count > 0)
            {
                int fila = gridOrigen.CurrentCell.RowIndex;
                int columna = gridOrigen.CurrentCell.ColumnIndex;

                if (fila < gridDestino.Rows.Count && columna < gridDestino.Columns.Count)
                {
                    gridDestino.CurrentCellChanged -= Grid_CurrentCellChanged;

                    gridDestino.CurrentCell = gridDestino.Rows[fila].Cells[columna];

                    gridDestino.CurrentCellChanged += Grid_CurrentCellChanged;
                }
            }
        }

        /// <summary>
        /// Recibe directamente las líneas de texto y las dibuja en el grid.
        /// </summary>
        private void CargarMapaEspecifico(string[] lineasBrutas, DataGridView dgv, string[] lineasBaseComparacion = null)
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

                string[] lineasEsperadasFiltradas = lineasBaseComparacion?.Where(l => !string.IsNullOrWhiteSpace(l)).ToArray();

                for (int c = 0; c < columnasMaximas; c++)
                {
                    DataGridViewCell celda = dgv.Rows[f].Cells[c];

                    if (c < lineaActual.Length)
                    {
                        char caracterActual = lineaActual[c];
                        celda.Value = caracterActual.ToString();

                        bool esError = false;
                        if (lineasEsperadasFiltradas != null)
                        {
                            if (f < lineasEsperadasFiltradas.Length && c < lineasEsperadasFiltradas[f].Length)
                            {
                                char caracterEsperado = lineasEsperadasFiltradas[f][c];

                                if (caracterActual != caracterEsperado)
                                {
                                    esError = true;
                                }
                            }
                            else
                            {
                                esError = true;
                            }
                        }

                        if (esError)
                        {
                            celda.Style.BackColor = Color.Red;
                            celda.Style.ForeColor = Color.White;
                            celda.Style.Font = new Font(dgv.Font, FontStyle.Bold);
                        }
                        else
                        {
                            PintarCeldaSegunCaracter(celda, caracterActual);
                        }
                    }
                    else
                    {
                        celda.Value = "";
                        celda.Style.BackColor = Color.Black;
                        celda.Style.ForeColor = Color.Black;
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
                    celda.Style.ForeColor = Color.DarkRed;
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