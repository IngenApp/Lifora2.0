using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiPost.Models
{
    public class ModeloApiPost
    {
        public int idPost, idPerfil, idComentario;
        public string descripcion, apodo, fecha;
        //public string post, comentario;
        public bool habilitado;
    }
}