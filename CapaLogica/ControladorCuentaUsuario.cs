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
            try
            {
                ModeloPersonas modelo = new ModeloPersonas();
                return modelo.ObtenerSeguidores(idPerfil);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener seguidores: {ex.Message}");
                return new List<string>();
            }
        }

        public static List<string> ObtenerSeguidos(int idPerfil)
        {
            try
            {
                ModeloPersonas modelo = new ModeloPersonas();
                return modelo.ObtenerSeguidos(idPerfil);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener seguidos: {ex.Message}");
                return new List<string>();
            }
        }

        public static void AltaCuentaUsuario(string nombre, string apellido, string fechaNacimiento, string email, string telefono, string contrasena)
        {
            try
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
            catch (Exception ex)
            {
                Console.WriteLine($"Error al dar de alta la cuenta de usuario: {ex.Message}");
            }
        }

        public static void CrearPerfil(string apodo, string email, string idioma)
        {
            try
            {
                ModeloPersonas crearPerfil = new ModeloPersonas();
                crearPerfil.apodo = apodo;
                crearPerfil.email = email;
                crearPerfil.idioma = idioma;
                crearPerfil.CrearPerfil();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear perfil: {ex.Message}");
            }
        }

        public static bool Login(string email, string contrasena)
        {
            try
            {
                ModeloPersonas mp = new ModeloPersonas();
                mp.email = email;
                mp.contrasena = contrasena;
                return mp.Autenticar();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en login: {ex.Message}");
                return false;
            }
        }

        public static bool LoginBackoffice(string email, string contrasena)
        {
            try
            {
                ModeloPersonas lb = new ModeloPersonas();
                lb.email = email;
                lb.contrasena = contrasena;
                return lb.AutenticarBackoffice();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en login backoffice: {ex.Message}");
                return false;
            }
        }

        public static void DeshabilitaCuentaUsuario(int idUsuario)
        {
            try
            {
                ModeloPersonas CuentaUsuario = new ModeloPersonas();
                CuentaUsuario.idUsuario = idUsuario;
                CuentaUsuario.DeshabilitarCuentaUsuario();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al deshabilitar cuenta de usuario: {ex.Message}");
            }
        }

        public static void HabilitaCuentaUsuario(int idUsuario)
        {
            try
            {
                ModeloPersonas CuentaUsuario = new ModeloPersonas();
                CuentaUsuario.idUsuario = idUsuario;
                CuentaUsuario.HabilitarCuentaUsuario();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al habilitar cuenta de usuario: {ex.Message}");
            }
        }

        public static void ModificarCuenta(string email, string emailNuevo, string nombre, string apellido, string telefono)
        {
            try
            {
                ModeloPersonas modCuenta = new ModeloPersonas();
                modCuenta.email = email;
                modCuenta.emailNuevo = emailNuevo;
                modCuenta.nombre = nombre;
                modCuenta.apellido = apellido;
                modCuenta.telefono = telefono;
                modCuenta.ModificarCuentaUsuario();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al modificar cuenta: {ex.Message}");
            }
        }

        public static void ModificarPerfil(string email, string apodo, string idFotoPerfil, string idioma, bool suscripcion, string contrasena)
        {
            try
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
            catch (Exception ex)
            {
                Console.WriteLine($"Error al modificar perfil: {ex.Message}");
            }
        }

        public static DataTable Listar()
        {
            try
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
            catch (Exception ex)
            {
                Console.WriteLine($"Error al listar personas: {ex.Message}");
                return new DataTable();
            }
        }

        public static Dictionary<string, string> ObtenerPerfilPorMail(string mail)
        {
            try
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
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener perfil por email: {ex.Message}");
                return new Dictionary<string, string>();
            }
        }

        public static Dictionary<string, string> ObtenerPerfilPorApodo(string apodo)
        {
            try
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
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener perfil por apodo: {ex.Message}");
                return new Dictionary<string, string>();
            }
        }

        public static PerfilSecundario ObtenerPerfilSecundario(string apodo)
        {
            try
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
                    suscripcion = perfil.suscripcion.ToString()
                };

                return pf;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener perfil secundario: {ex.Message}");
                return null;
            }
        }

        public static PerfilPrincipal ObtenerPerfilPrincipal(string email)
        {
            try
            {
                ModeloPersonas perfil = new ModeloPersonas();
                perfil.ObtenerPerfilPorEmail(email);

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
                    suscripcion = perfil.suscripcion.ToString()
                };

                return pf;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener perfil principal: {ex.Message}");
                return null;
            }
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
            public string suscripcion { get; set; }
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
            public string suscripcion { get; set; }
        }
        public static class PerfilManager
        {
            public static PerfilPrincipal PerfilActual { get; set; }
        }





    }
}


