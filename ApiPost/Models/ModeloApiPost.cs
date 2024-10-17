using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiPost.Models
{
    public class ModeloApiPost
    {
        public int idPost, idPerfil, idComentario;
        public string post, descripcion, apodo, fecha, comentario;
        public bool habilitado;
    }
}