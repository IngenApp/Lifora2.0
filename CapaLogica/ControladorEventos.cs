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
            ModeloEventos CrearEvento = new ModeloEventos();
            CrearEvento.nombreEvento = nombreEvento;
            CrearEvento.informacion = informacion;
            CrearEvento.lugar = lugar;
            CrearEvento.fechaEvento = fechaEvento;
            CrearEvento.idPerfil = idPerfil;
            CrearEvento.CrearEvento();
        }
        public static void DeshabilitarEvento(int id_evento)
        {
            ModeloEventos DeshabilitarEvento = new ModeloEventos();
            DeshabilitarEvento.idEvento = id_evento;
            DeshabilitarEvento.DeshabilitarEvento();
        }
        public static void HabilitarEvento(int id_evento)
        {
            ModeloEventos HabilitarEvento = new ModeloEventos();
            HabilitarEvento.idEvento = id_evento;
            HabilitarEvento.HabilitarEvento();
        }
        public static Dictionary<string, string> BuscarEventoPorId(int id_evento)
        {
            ModeloEventos modeloEvento = new ModeloEventos();
            modeloEvento.idEvento = id_evento;
            return modeloEvento.ObtenerEventoPorId();
        }
        public static void ModificarEvento(string idEvento, string nombre_evento, string informacion, string lugar, string fecha)
        {
            ModeloEventos ModEventoBO = new ModeloEventos();
            ModEventoBO.idEvento = Int32.Parse(idEvento);
            ModEventoBO.nombreEvento = nombre_evento;
            ModEventoBO.informacion = informacion;
            ModEventoBO.lugar = lugar;
            ModEventoBO.fechaEvento = fecha;
            ModEventoBO.ModificarEvento();
        }
        public static DataTable ListarEventos()
        {
            DataTable tabla = new DataTable();
            tabla.Columns.Add("ID_Evento", typeof(int));
            tabla.Columns.Add("Nombre_Evento", typeof(string));
            tabla.Columns.Add("Informacion", typeof(string));
            tabla.Columns.Add("Lugar", typeof(string));
            tabla.Columns.Add("Fecha", typeof(DateTime));
            tabla.Columns.Add("habilitado", typeof(Boolean));
            tabla.Columns.Add("ID_Perfil", typeof(string));

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
                tabla.Rows.Add(fila);
            }
            return tabla;
        }
    }
}
