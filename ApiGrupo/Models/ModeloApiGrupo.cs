using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiGrupo.Models
{
    public class ModeloApiGrupo
    {
            public int IdGrupo { get; set; }
            public string Nombre { get; set; }
            public string Informacion { get; set; }
            public string Fecha { get; set; }
            public string dFotoGrupo { get; set; }
            public int IdPerfil { get; set; }
        }
}