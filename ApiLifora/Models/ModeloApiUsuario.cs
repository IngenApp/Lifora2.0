using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiLifora.Models
{
    public class ModeloApiUsuario
    {

        public int idPerfil, idUsuario, idFotoPerfil;
        public string nombre, apellido, fechaNacimiento, email, telefono, contrasena, apodo, idioma, atributo1, atributo2;
        public bool habilitacion;


    }
}