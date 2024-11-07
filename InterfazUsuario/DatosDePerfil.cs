using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;

namespace InterfazUsuario
{
    public class DatosDePerfil
    {

        public static string idVideo { get; set; }
        public static string idAudio { get; set; }
        public static string descripcion { get; set; }
        public static string idImagen { get; set; }
        public static string nuevaDescripcion { get; set; }
        public static int idPost { get; set; }
        public static int idPerfil { get; set; }
        public static string contrasena { get; set; }
        public static string nombre { get; set; }
        public static string apellido { get; set; }
        public static string fechaNacimiento { get; set; }
        public static string email { get; set; }
        public static string telefono { get; set; }
        public static string apodo { get; set; }
        public static int? idFotoPerfil { get; set; }
        public static string idioma { get; set; }
        public static string atributo1 { get; set; }
        public static string atributo2 { get; set; }
        public static List<string> Seguidores { get; set; }
        public static List<string> Seguidos { get; set; }
        public static int CantidadSeguidores { get; set; }
        public static int CantidadSeguidos { get; set; }

    }
}
