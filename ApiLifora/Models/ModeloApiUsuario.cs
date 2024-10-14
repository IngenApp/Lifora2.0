using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Controladores;
using ApiLifora.Models;
using System.Data;


namespace ApiLifora.Models
{
    public class ModeloApiUsuario
    {

        public int idPerfil, idUsuario, idCuenta, idFotoPerfil;
        public string nombre, apellido, fechaNacimiento, email, telefono, contrasena, apodo, idioma, atributo1, atributo2, emailNuevo;
        public bool habilitacion;

    }
}