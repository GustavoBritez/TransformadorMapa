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
        public static string[] LeerMapa(string nombreArchivo)
        {
            try
            {
                if (!nombreArchivo.EndsWith(".txt"))
                {
                    nombreArchivo += ".txt";
                }

                string rutaBase = AppDomain.CurrentDomain.BaseDirectory;
                string rutaCompleta = Path.Combine(rutaBase, nombreArchivo);

                int intentos = 0;
                while (!File.Exists(rutaCompleta) && intentos < 4)
                {
                    rutaBase = Directory.GetParent(rutaBase)?.FullName;
                    if (rutaBase == null) break;
                    rutaCompleta = Path.Combine(rutaBase, nombreArchivo);
                    intentos++;
                }

                if (!File.Exists(rutaCompleta))
                {
                    MessageBox.Show($"No se encontró el archivo '{nombreArchivo}' en la ruta:\n{rutaCompleta}",
                                    "Archivo No Encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return new string[0];
                }

                return File.ReadAllLines(rutaCompleta);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al leer el archivo {nombreArchivo}: {ex.Message}",
                                "Error de Lectura", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new string[0];
            }
        }
    }
}