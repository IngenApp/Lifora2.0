using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Modelo;
using System.Data;

namespace Controladores
{
    public class ControladorMensajes
    {
        public static DataTable MostrarChat(int idPerfil)
        {
            DataTable tabla = new DataTable();
            tabla.Columns.Add("Apodo", typeof(string));
            tabla.Columns.Add("Fecha", typeof(DateTime));
            
            ModeloMensajes Chat = new ModeloMensajes();

            foreach (ModeloMensajes p in Chat.ObtenerChat(idPerfil))
            {
                DataRow fila = tabla.NewRow();
                fila["Apodo"] = p.apodo;
                fila["Fecha"] = p.fechaHora;
                tabla.Rows.Add(fila);
            }
            return tabla;
        }
        public static DataTable MostrarMensajes(int idPerfil1, int idPerfil2)
        {
            DataTable mensajesTable = new DataTable();

            mensajesTable.Columns.Add("Apodo", typeof(string));
            mensajesTable.Columns.Add("Mensaje", typeof(string));
            mensajesTable.Columns.Add("Fecha", typeof(string));

            ModeloMensajes Mensajes = new ModeloMensajes();

            foreach (ModeloMensajes p in Mensajes.ObtenerMensajesDeConversacion(idPerfil1, idPerfil2))
            {
                DataRow fila = mensajesTable.NewRow();
                fila["Apodo"] = p.apodo;
                fila["Mensaje"] = p.contenido;
                fila["Fecha"] = p.fechaHora;
                mensajesTable.Rows.Add(fila);
            }

            return mensajesTable;
        }

    }
}
