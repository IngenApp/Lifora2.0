using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using System.Data;

namespace Controladores
{
    public class ControladorEventos
    {
        public static void CrearEvento(int idPerfil, string nombreEvento, string informacion, string lugar, string fechaEvento)
        {
            try
            {
                ModeloEventos CrearEvento = new ModeloEventos();
                CrearEvento.nombreEvento = nombreEvento;
                CrearEvento.informacion = informacion;
                CrearEvento.lugar = lugar;
                CrearEvento.fechaEvento = fechaEvento;
                CrearEvento.idPerfil = idPerfil;
                CrearEvento.CrearEvento();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void DeshabilitarEvento(int id_evento)
        {
            try
            {
                ModeloEventos DeshabilitarEvento = new ModeloEventos();
                DeshabilitarEvento.idEvento = id_evento;
                DeshabilitarEvento.DeshabilitarEvento();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void HabilitarEvento(int id_evento)
        {
            try
            {
                ModeloEventos HabilitarEvento = new ModeloEventos();
                HabilitarEvento.idEvento = id_evento;
                HabilitarEvento.HabilitarEvento();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static Dictionary<string, string> BuscarEventoPorNombre(string nombreEvento)
        {
            try
            {
                ModeloEventos modeloEvento = new ModeloEventos();
                modeloEvento.nombreEvento = nombreEvento;
                return modeloEvento.ObtenerEventoPorNombreEvento();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public static void ModificarEvento(string idEvento, string nombre_evento, string informacion, string lugar, string fecha)
        {
            try
            {
                ModeloEventos ModEventoBO = new ModeloEventos();
                ModEventoBO.idEvento = Int32.Parse(idEvento);
                ModEventoBO.nombreEvento = nombre_evento;
                ModEventoBO.informacion = informacion;
                ModEventoBO.lugar = lugar;
                ModEventoBO.fechaEvento = fecha;
                ModEventoBO.ModificarEvento();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static DataTable ListarEventos()
        {
            try
            {
                DataTable tabla = new DataTable();
                tabla.Columns.Add("ID_Evento", typeof(int));
                tabla.Columns.Add("Nombre_Evento", typeof(string));
                tabla.Columns.Add("Informacion", typeof(string));
                tabla.Columns.Add("Lugar", typeof(string));
                tabla.Columns.Add("Fecha", typeof(DateTime));
                tabla.Columns.Add("habilitado", typeof(Boolean));
                tabla.Columns.Add("ID_Perfil", typeof(string));
                tabla.Columns.Add("id_foto_evento", typeof(string));

                ModeloEventos ListarEventos = new ModeloEventos();
                foreach (ModeloEventos p in ListarEventos.ObtenerEventos())
                {
                    DataRow fila = tabla.NewRow();
                    fila["ID_Evento"] = p.idEvento;
                    fila["Nombre_Evento"] = p.nombreEvento;
                    fila["Informacion"] = p.informacion;
                    fila["Lugar"] = p.lugar;
                    fila["Fecha"] = p.fechaEvento;
                    fila["habilitado"] = p.habilitado;
                    fila["ID_Perfil"] = p.idPerfil;
                    fila["id_foto_evento"] = p.idFotoEvento;
                    tabla.Rows.Add(fila);
                }
                return tabla;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

    }

}
