using System;
using System.IO;

namespace CapaDatos
{
    public class GuardarPersistencia
    {
        public static void Main(string[] args)
        {
            string rutaArchivo = @"C:\Users\Andres\Desktop\Proyecto LiForA\Red_Social\Lifora\Persistencia\archivo.txt";

            ManejoDePersistencia archivo = new ManejoDePersistencia(rutaArchivo);

            archivo.GuardarDatos("Datos a guardar en el archivo");

            string datosCargados = archivo.CargarDatos();

            Console.WriteLine(datosCargados);
        }
    }
}