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
    }
}
