using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiPost.Models
{
    public class ModeloApiPost
    {
        public int IdPost { get; set; }
        public int IdPerfil { get; set; }
        public int IdComentario { get; set; }
        public int IdEvento { get; set; }
        public string Post { get; set; }
        public string Descripcion { get; set; }
        public string Apodo { get; set; }
        public string Fecha { get; set; }
        public string Comentario { get; set; }
        public int cantidad { get; set; }
        public string IdAudio { get; set; }
        public string IdImagen { get; set; }
        public string IdVideo { get; set; }
        public bool Habilitado { get; set; }
        public bool ComparteHabilitado { get; set; }
        public DateTime FechaHora { get; set; }
        public DateTime FechaComparte { get; set; }
    }
}