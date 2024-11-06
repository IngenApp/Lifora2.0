using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiPost.Models
{
    public class ModeloApiPost
    {
        public int idPost, idPerfil, idComentario, idEvento;
        public string post, descripcion, apodo, fecha, comentario, idAudio, idImagen, idVideo;
        public bool habilitado, comparteHabilitado;
        public DateTime fechaHora, fechaComparte;
    }
}