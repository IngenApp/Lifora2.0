using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiEventos.Models
{
    public class ModeloApiEventos
    {
        public int idEvento, idPerfil;
        public string nombreEvento, informacion, lugar, fechaEvento;
        public bool habilitado;
    }
}