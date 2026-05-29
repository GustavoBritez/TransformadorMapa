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

            int maxCeldasReales = 0;
            foreach (var linea in lineas)
            {
                int celdasEnEstaFila = 0;
                int i = 0;
                while (i < linea.Length)
                {
                    if (i < linea.Length - 1 && char.IsLetter(linea[i]) && char.IsLetter(linea[i + 1]))
                    {
                        i += 2; 
                    }
                    else
                    {
                        i += 1; 
                    }
                    celdasEnEstaFila++;
                }
                if (celdasEnEstaFila > maxCeldasReales) maxCeldasReales = celdasEnEstaFila;
            }
            int dimensionCelda = 22; 
            for (int c = 0; c < maxCeldasReales; c++)
            {
                DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
                col.Width = dimensionCelda;
                dgv.Columns.Add(col);
            }

            for (int f = 0; f < filas; f++)
            {
                dgv.Rows.Add();
                dgv.Rows[f].Height = 22;

                string lineaActual = lineas[f];
                int indiceCaracter = 0;
                int columnaActual = 0;

                while (indiceCaracter < lineaActual.Length)
                {
                    string valorCelda = "";
                    char car1 = lineaActual[indiceCaracter];

                    if (indiceCaracter < lineaActual.Length - 1 && char.IsLetter(car1) && char.IsLetter(lineaActual[indiceCaracter + 1]))
                    {
                        char car2 = lineaActual[indiceCaracter + 1];
                        valorCelda = $"{car1}{car2}"; 
                        indiceCaracter += 2;         
                    }
                    else
                    {
                        valorCelda = car1.ToString();
                        indiceCaracter += 1;          
                    }

                    DataGridViewCell celda = dgv.Rows[f].Cells[columnaActual];
                    celda.Value = valorCelda;

                    PintarCeldaDinamica(celda, valorCelda);

                    columnaActual++;
                }
            }
        }

        /// <summary>
        /// Mapea los caracteres del archivo de texto a los colores requeridos.
        /// </summary>
        private void PintarCeldaDinamica(DataGridViewCell celda, string valor)
        {
            if (string.IsNullOrEmpty(valor)) return;

            if (valor.Length == 1)
            {
                char caracter = valor[0];
                switch (caracter)
                {
                    case '0':
                        celda.Style.BackColor = Color.White;
                        celda.Style.ForeColor = Color.FromArgb(240, 240, 240);
                        return;
                    case '1':
                        celda.Style.BackColor = Color.LightSkyBlue;
                        celda.Style.ForeColor = Color.DarkBlue;
                        return;
                    case '2':
                        celda.Style.BackColor = Color.Black;
                        celda.Style.ForeColor = Color.White;
                        return;
                    case '3':
                        celda.Style.BackColor = Color.SaddleBrown;
                        celda.Style.ForeColor = Color.White;
                        return;
                    case 'b':
                        celda.Style.BackColor = Color.DarkBlue;
                        celda.Style.ForeColor = Color.White;
                        return;
                    case '4':
                        celda.Style.BackColor = Color.DimGray;
                        celda.Style.ForeColor = Color.White;
                        return;
                    case 'p':
                        celda.Style.BackColor = Color.MediumPurple;
                        celda.Style.ForeColor = Color.Black;
                        return;
                    case '5':
                        celda.Style.BackColor = Color.ForestGreen;
                        celda.Style.ForeColor = Color.White;
                        return;
                    case '*':
                        celda.Style.BackColor = Color.FromArgb(235, 235, 235);
                        celda.Style.ForeColor = Color.DarkGray;
                        return;
                }
            }
            celda.Style.BackColor = Color.Orange;
            celda.Style.ForeColor = Color.Black;
            celda.Style.Font = new Font(dgvMEsperado.Font, FontStyle.Bold);
        }
    }
}