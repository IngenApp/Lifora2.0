using System;
using System.Collections.Generic;
using Modelo;
using System.Data;

namespace Controladores
{
    public class ControladorCuentaUsuario
    {
        public static List<string> ObtenerSeguidores(int idPerfil)
        {
            ModeloPersonas modelo = new ModeloPersonas();

            return modelo.ObtenerSeguidores(idPerfil);
        }
        public static int ObtenerCantidadSeguidores(int idPerfil)
        {
            try
            {
                ModeloPersonas modeloPersonas = new ModeloPersonas();
                int cantidadSeguidores = modeloPersonas.ObtenerCantidadSeguidores(idPerfil);
                return cantidadSeguidores;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener la cantidad de seguidores: {ex.Message}");
                return 0;
            }
        }
        public static List<string> ObtenerSeguidos(int idPerfil)
        {
            ModeloPersonas modelo = new ModeloPersonas();
            return modelo.ObtenerSeguidos(idPerfil);
        }
        public static int ObtenerCantidadSeguidos(int idPerfil)
        {
            try
            {
                ModeloPersonas modeloPersonas = new ModeloPersonas();
                int cantidadSeguidos = modeloPersonas.ObtenerCantidadSeguidos(idPerfil);
                return cantidadSeguidos;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener la cantidad de seguidos: {ex.Message}");
                return 0;
            }
        }
        public static void AltaCuentaUsuario(string nombre, string apellido, string fechaNacimiento, string email, string telefono, string contrasena)
        {
            ModeloPersonas CuentaUsuario = new ModeloPersonas();
            CuentaUsuario.nombre = nombre;
            CuentaUsuario.apellido = apellido;
            CuentaUsuario.fechaNacimiento = fechaNacimiento;
            CuentaUsuario.email = email;
            CuentaUsuario.telefono = telefono;
            CuentaUsuario.contrasena = contrasena;
            CuentaUsuario.GuardarCuentaUsuario();
        }
        public static void CrearPerfil(string apodo, string email, string idioma)
        {
            ModeloPersonas crearPerfil = new ModeloPersonas();
            crearPerfil.apodo = apodo;
            crearPerfil.email = email;
            crearPerfil.idioma = idioma;
            crearPerfil.CrearPerfil();
        }
        public static bool Login(string email, string contrasena)
        {
            ModeloPersonas mp = new ModeloPersonas();
            mp.email = email;
            mp.contrasena = contrasena;
            return mp.Autenticar();
        }
        public static bool LoginBackoffice(string email, string contrasena)
        {
            ModeloPersonas lb = new ModeloPersonas();
            lb.email = email;
            lb.contrasena = contrasena;
            return lb.AutenticarBackoffice();
        }
        public static void DeshabilitaCuentaUsuario(int idUsuario)
        {
            ModeloPersonas CuentaUsuario = new ModeloPersonas();
            CuentaUsuario.idUsuario = idUsuario;
            CuentaUsuario.DeshabilitarCuentaUsuario();
        }
        public static void HabilitaCuentaUsuario(int idUsuario)
        {
            ModeloPersonas CuentaUsuario = new ModeloPersonas();
            CuentaUsuario.idUsuario = idUsuario;
            CuentaUsuario.HabilitarCuentaUsuario();
        }
        public static void ModificarCuenta(string email, string emailNuevo, string nombre, string apellido, string telefono)
        {
            ModeloPersonas modCuenta = new ModeloPersonas();
            modCuenta.email = email;
            modCuenta.emailNuevo = emailNuevo;
            modCuenta.nombre = nombre;
            modCuenta.apellido = apellido;
            modCuenta.telefono = telefono;

            modCuenta.ModificarCuentaUsuario();
        }
        public static void ModificarPerfil(string email, string apodo, string idFotoPerfil, string idioma, bool suscripcion,  string contrasena)
        {
            ModeloPersonas ModPerf = new ModeloPersonas();

            ModPerf.email = email;
            ModPerf.apodo = apodo;
            ModPerf.idFotoPerfil = idFotoPerfil;
            ModPerf.idioma = idioma;
            ModPerf.suscripcion = suscripcion;
            ModPerf.contrasena = contrasena;
            ModPerf.ModificarPerfilUsuario();
        }
        public static DataTable Listar()
        {
            DataTable tabla = new DataTable();
            tabla.Columns.Add("ID perfil", typeof(int));
            tabla.Columns.Add("apodo", typeof(string));
            tabla.Columns.Add("Email", typeof(string));
            tabla.Columns.Add("Telefono", typeof(string));
            tabla.Columns.Add("Habilitado", typeof(bool));
            tabla.Columns.Add("ID usuario", typeof(int));
            tabla.Columns.Add("Nombre", typeof(string));
            tabla.Columns.Add("Apellido", typeof(string));
            tabla.Columns.Add("Contrasena", typeof(string));
            tabla.Columns.Add("Fecha Nacimiento", typeof(DateTime));
            tabla.Columns.Add("Idioma", typeof(string));
            tabla.Columns.Add("suscripcion", typeof(bool));

            ModeloPersonas ListarPersonas = new ModeloPersonas();

            foreach (ModeloPersonas p in ListarPersonas.ObtenerTodos())
            {
                DataRow fila = tabla.NewRow();
                fila["ID perfil"] = p.idPerfil;
                fila["apodo"] = p.apodo;
                fila["Email"] = p.email;
                fila["Telefono"] = p.telefono;
                fila["Habilitado"] = p.habilitacion;
                fila["ID usuario"] = p.idUsuario;
                fila["Nombre"] = p.nombre;
                fila["Apellido"] = p.apellido;
                fila["Contrasena"] = p.contrasena;
                fila["Fecha Nacimiento"] = p.fechaNacimiento;
                fila["Idioma"] = p.idioma;
                fila["suscripcion"] = p.suscripcion;

                tabla.Rows.Add(fila);
            }

            return tabla;
        }
        public static Dictionary<string, string> ObtenerPerfilPorMail(string mail)
        {
            Dictionary<string, string> perfil = new Dictionary<string, string>();
            ModeloPersonas persona = new ModeloPersonas();

            if (persona.ObtenerPerfilPorEmail(mail))
            {
                perfil.Add("resultado", "true");
                perfil.Add("apodo", persona.apodo);
                perfil.Add("id_perfil", persona.idPerfil.ToString());
                perfil.Add("email", persona.email);
                perfil.Add("contrasena", persona.contrasena);
                perfil.Add("telefono", persona.telefono);
                perfil.Add("nombre", persona.nombre);
                perfil.Add("apellido", persona.apellido);
                perfil.Add("fecha_nacimiento", persona.fechaNacimiento);
                perfil.Add("idFotoPerfil", persona.idFotoPerfil);
                perfil.Add("idioma", persona.idioma);
                perfil.Add("suscripcion", persona.suscripcion.ToString());

                return perfil;
            }

            perfil.Add("resultado", "false");
            return perfil;
        }
        public static Dictionary<string, string> ObtenerPerfilPorApodo(string apodo)
        {
            Dictionary<string, string> perfil = new Dictionary<string, string>();
            ModeloPersonas persona = new ModeloPersonas();

            if (persona.ObtenerPerfilPorApodo(apodo))
            {
                perfil.Add("resultado", "true");
                perfil.Add("apodo", persona.apodo);
                perfil.Add("id_perfil", persona.idPerfil.ToString());
                perfil.Add("email", persona.email);
                perfil.Add("contrasena", persona.contrasena);
                perfil.Add("telefono", persona.telefono);
                perfil.Add("nombre", persona.nombre);
                perfil.Add("apellido", persona.apellido);
                perfil.Add("fecha_nacimiento", persona.fechaNacimiento);
                perfil.Add("idFotoPerfil", persona.idFotoPerfil);
                perfil.Add("idioma", persona.idioma);
                perfil.Add("suscripcion", persona.suscripcion.ToString());

                return perfil;
            }

            perfil.Add("resultado", "false");
            return perfil;
        }

        public static PerfilSecundario ObtenerPerfilSecundario(string apodo)
        {
            ModeloPersonas perfil = new ModeloPersonas();
            perfil.ObtenerIdPerfilPorApodo(apodo);

            PerfilSecundario pf = new PerfilSecundario
            {
                apodo = perfil.apodo,
                idPerfil = perfil.idPerfil,
                email = perfil.email,
                telefono = perfil.telefono,
                nombre = perfil.nombre,
                apellido = perfil.apellido,
                fechaNacimiento = perfil.fechaNacimiento,
                idFotoPerfil = perfil.idFotoPerfil,
                idioma = perfil.idioma,
                atributo1 = perfil.suscripcion.ToString()
            };

            return pf;

        }
        public static PerfilPrincipal ObtenerPerfilPrincipal(string email)
        {
            ModeloPersonas perfil = new ModeloPersonas();
            perfil.ObtenerIdPerfilPorEmail(email);

            PerfilPrincipal pf = new PerfilPrincipal
            {
                apodo = perfil.apodo,
                idPerfil = perfil.idPerfil,
                email = perfil.email,
                telefono = perfil.telefono,
                nombre = perfil.nombre,
                apellido = perfil.apellido,
                fechaNacimiento = perfil.fechaNacimiento,
                idFotoPerfil = perfil.idFotoPerfil,
                idioma = perfil.idioma,
                atributo1 = perfil.suscripcion.ToString()
            };

            return pf;
        }
        public class PerfilPrincipal
        {
            public int idPerfil { get; set; }
            public string nombre { get; set; }
            public string apellido { get; set; }
            public string fechaNacimiento { get; set; }
            public string email { get; set; }
            public string telefono { get; set; }
            public string apodo { get; set; }
            public string idFotoPerfil { get; set; }
            public string idioma { get; set; }
            public string atributo1 { get; set; }
            public string atributo2 { get; set; }
        }
        public class PerfilSecundario
        {
            public int idPerfil { get; set; }
            public string nombre { get; set; }
            public string apellido { get; set; }
            public string fechaNacimiento { get; set; }
            public string email { get; set; }
            public string telefono { get; set; }
            public string apodo { get; set; }
            public string idFotoPerfil { get; set; }
            public string idioma { get; set; }
            public string atributo1 { get; set; }
            public string atributo2 { get; set; }
        }
        public static class PerfilManager
        {
            public static PerfilPrincipal PerfilActual { get; set; }
        }





    }
}


