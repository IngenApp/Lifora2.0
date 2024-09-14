using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiEventos.Models
{
    public class ModeloApiEventos
    {
        public int id_evento;
        public string nombre_evento;
        public string informacion;
        public string lugar;
        public string fecha_evento;
        public int id_cuenta;
        public string habilitado;
    }
}