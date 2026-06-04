using System;
using System.IO;
using System.Windows.Forms;

namespace Transformador
{
    public class Archivo
    {
        /// <summary>
        /// Lee un archivo de mapa buscando desde la carpeta de ejecución hacia la raíz del proyecto.
        /// </summary>
        public static (string[] esperado, string[] enviado) LeerMapasDesdeArchivo()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
                openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Title = "Seleccionar Mapa (Archivo TXT)";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string contenidoCompleto = File.ReadAllText(openFileDialog.FileName);

                        string[] bloques = contenidoCompleto.Split(new string[] { "\r\n\r\n", "\n\n" }, StringSplitOptions.RemoveEmptyEntries);

                        if (bloques.Length >= 2)
                        {
                            string[] lineasEsperado = bloques[0].Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
                            string[] lineasEnviado = bloques[1].Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);

                            return (lineasEsperado, lineasEnviado);
                        }
                        else
                        {
                            MessageBox.Show("El archivo no contiene la estructura esperada de dos mapas separados por un espacio en blanco.",
                                            "Estructura Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al procesar el archivo: {ex.Message}",
                                        "Error de Lectura", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            return (new string[0], new string[0]);
        }
    }
}