using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace CapaLogica
{
    class ControladorEventos
    {
        public static void CrearEvento(String nombre_evento, string informacion, string lugar, string fecha)
        {
            ModeloEventos CrearEvento = new ModeloEventos();
            CrearEvento.nombre_evento = nombre_evento;
            CrearEvento.informacion = informacion;
            CrearEvento.lugar = lugar;
            CrearEvento.fecha = fecha;
            CrearEvento.CrearEvento();
        }
        public static void DeshabilitarEvento(int id_evento)
        {
            ModeloEventos DeshabilitarEvento = new ModeloEventos();
            DeshabilitarEvento.id_evento = id_evento;
            DeshabilitarEvento.DeshabilitarEvento();
        }
        public static void HabilitarEvento(int id_evento)
        {
            ModeloEventos HabilitarEvento = new ModeloEventos();
            HabilitarEvento.id_evento = id_evento;
            HabilitarEvento.HabilitarEvento();
        }
        public static int BuscarIdEvento(string nombre_evento)
        {
            ModeloEventos BuscarIdEvento = new ModeloEventos();
            BuscarIdEvento.nombre_evento = nombre_evento;
            return BuscarIdEvento.ObtenerIdEvento();
        }
    }
}
