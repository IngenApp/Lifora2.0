using System;
using System.IO;

namespace CapaDatos
{
    public class GuardarPersistencia
    {
        public static void Main(string[] args)
        {
            string rutaArchivo = @"D:\IngenApp\archivo.txt";

            ManejoDePersistencia archivo = new ManejoDePersistencia(rutaArchivo);

            archivo.GuardarDatos("Datos a guardar en el archivo");

            string datosCargados = archivo.CargarDatos();

            Console.WriteLine(datosCargados);
        }
    }
}