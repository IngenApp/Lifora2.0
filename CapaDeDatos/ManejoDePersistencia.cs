using System;
using System.IO;
public class ManejoDePersistencia
{
    private string rutaArchivo;

    public ManejoDePersistencia(string rutaArchivo)
    {
        this.rutaArchivo = rutaArchivo;
    }

    public void GuardarDatos(string datos)
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
            Console.WriteLine($"Error al guardar en archivo: {ex.Message}");
        }
    }

    public string CargarDatos()
    {
        string datos = "";
        try
        {
            using (StreamReader sr = new StreamReader(rutaArchivo))
            {
                datos = sr.ReadToEnd();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al cargar desde archivo: {ex.Message}");
        }
        return datos;
    }
}

