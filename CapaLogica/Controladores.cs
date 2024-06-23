using System;
using System.Data;
using System.IO;

namespace CapaDeDatos
{
    public class Controlador
    {
        private static string rutaArchivo = @"C:\Users\Andres\Desktop\Proyecto LiForA\Red_Social\Lifora\Persistencia\archivo.txt";

        public static void Create(string idUser)
        {
            try
            {
                string datosNuevos = $"{ObtenerSiguienteId()}, {idUser}";
                SaveToFile(datosNuevos);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al Crear Archivo: {ex.Message}");
            }
        }

        public static void Delete(string id)
        {
            try
            {
                string[] lineas = File.ReadAllLines(rutaArchivo);
                using (StreamWriter sw = new StreamWriter(rutaArchivo))
                {
                    foreach (string linea in lineas)
                    {
                        if (!linea.StartsWith(id + ","))
                            sw.WriteLine(linea);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al Eliminar Archivo: {ex.Message}");
            }
        }
            private static int ObtenerSiguienteId()
        {
            int siguienteId = 1;
            try
            {
                string[] lineas = File.ReadAllLines(rutaArchivo);
                if (lineas.Length > 0)
                {
                    string[] ultimaLinea = lineas[lineas.Length - 1].Split(',');
                    siguienteId = Int32.Parse(ultimaLinea[0]) + 1;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener siguiente ID: {ex.Message}");
            }
            return siguienteId;
        }
        private static void SaveToFile(string datos)
        {
            try
            {
                using (StreamWriter sw = File.AppendText(rutaArchivo))
                {
                    sw.WriteLine(datos);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al Guardar Archivo: {ex.Message}");
            }
        }
    }
}

