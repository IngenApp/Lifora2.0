using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace Controladores
{
    public class ControladorEventos
    {
        public static void CrearEvento(int id_cuenta, string nombre_evento, string informacion, string lugar, string fecha_evento)
        {
            ModeloEventos CrearEvento = new ModeloEventos();
            CrearEvento.nombre_evento = nombre_evento;
            CrearEvento.informacion = informacion;
            CrearEvento.lugar = lugar;
            CrearEvento.fecha_evento = fecha_evento;
            CrearEvento.id_cuenta = id_cuenta;
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
        public static void ModificarNombreEvento(int id_evento, string nombre_evento)
        {
            ModeloEventos NombreEvento = new ModeloEventos();
            NombreEvento.id_evento = id_evento;
            NombreEvento.nombre_evento = nombre_evento;
            NombreEvento.ModificarNombreEvento();
        }
        public static void ModificarLugarEvento(int id_evento, string lugar)
        {
            ModeloEventos ModLugar = new ModeloEventos();
            ModLugar.id_evento = id_evento;
            ModLugar.nombre_evento = lugar;
            ModLugar.ModificarLugarEvento();
        }
        public static void ModificarInformacionEvento(int id_evento, string informacion)
        {
            ModeloEventos ModInformacion = new ModeloEventos();
            ModInformacion.id_evento = id_evento;
            ModInformacion.informacion = informacion;
            ModInformacion.ModificarInformacionEvento();
        }
        public static void ModificarFechaEvento(int id_evento, string fecha_evento)
        {
            ModeloEventos ModInformacion = new ModeloEventos();
            ModInformacion.id_evento = id_evento;
            ModInformacion.fecha_evento = fecha_evento;
            ModInformacion.ModificarFechaEvento();
        }
    }
}
