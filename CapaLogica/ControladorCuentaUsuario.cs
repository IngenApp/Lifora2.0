using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Modelo;
using System.Data;

namespace Controladores
{
    public class ControladorCuentaUsuario
    {
        public string TextoPost { get; set; }
        public bool EstaHabilitado { get; set; }
        public static void AltaCuentaUsuario(String nombre, string apellido, int telefono, string email, string fecha_nac, string contrasena)
        {
            ModeloPersonas CuentaUsuario = new ModeloPersonas();
            CuentaUsuario.nombre = nombre;
            CuentaUsuario.apellido = apellido;
            CuentaUsuario.telefono = telefono;
            CuentaUsuario.email = email;
            CuentaUsuario.fecha_nac = fecha_nac;
            CuentaUsuario.contrasena = contrasena;

            CuentaUsuario.GuardarCuentaUsuario();
        }
       public static void DeshabilitaCuentaUsuario(int id)
        {
            ModeloPersonas CuentaUsuario = new ModeloPersonas();
            CuentaUsuario.id_cuenta = id;
            CuentaUsuario.DeshabilitarCuentaUsuario();
        }
        public static void HabilitaCuentaUsuario(int id)
        {
            ModeloPersonas CuentaUsuario = new ModeloPersonas();
            CuentaUsuario.id_cuenta = id;
            CuentaUsuario.HabilitarCuentaUsuario();
        }
        public static void ModificarNombreUsuario(string id, string nombre)
        {
            ModeloPersonas CuentaUsuario = new ModeloPersonas();
            CuentaUsuario.id_cuenta = Int32.Parse(id);
            CuentaUsuario.nombre = nombre;
            CuentaUsuario.ModificarNombreUsuario();
        }
        public static void ModificarApellidoUsuario(string id, string apellido)
        {
            ModeloPersonas CuentaUsuario = new ModeloPersonas();
            CuentaUsuario.id_cuenta = Int32.Parse(id);
            CuentaUsuario.apellido = apellido;
            CuentaUsuario.ModificarApellidoUsuario();
        }
        public static void ModificarContrasenaUsuario(string id, string contrasena)
        {
            ModeloPersonas CuentaUsuario = new ModeloPersonas();
            CuentaUsuario.id_cuenta = Int32.Parse(id);
            CuentaUsuario.contrasena = contrasena;
            CuentaUsuario.ModificarContrasenaUsuario();
        }
        public static void ModificarFechaNacimientoUsuario(string id, string fech_nac)
        {
            ModeloPersonas CuentaUsuario = new ModeloPersonas();
            CuentaUsuario.id_cuenta = Int32.Parse(id);
            CuentaUsuario.fecha_nac = fech_nac;
            CuentaUsuario.ModificarFechaNacimientoUsuario();
        }
        public static void ModificarCuentaDesdeBackoffice(string id, string nombre, string apellido, string email, string telefono, string fecha_nac)
        {
            ModeloPersonas CuentaUsuario = new ModeloPersonas();
            CuentaUsuario.id_cuenta = Int32.Parse(id);
            CuentaUsuario.telefono = Int32.Parse(telefono);
            CuentaUsuario.nombre = nombre;
            CuentaUsuario.apellido = apellido;
            CuentaUsuario.email = email;
            CuentaUsuario.fecha_nac = fecha_nac;
            CuentaUsuario.ModificarCuentaUsuarioBackoffice();
        }
        public static int BuscarId(string email)
        {
            ModeloPersonas CuentaId = new ModeloPersonas();
            CuentaId.email = email;
            return CuentaId.ObtenerIdUsuario();
        }
        public static DataTable Listar()
        {
            DataTable tabla = new DataTable();
            tabla.Columns.Add("id_cuenta", typeof(int));
            tabla.Columns.Add("nombre", typeof(string));
            tabla.Columns.Add("apellido", typeof(string));
            tabla.Columns.Add("telefono", typeof(int));
            tabla.Columns.Add("email", typeof(string));
            tabla.Columns.Add("fecha_nacimiento", typeof(string));
            tabla.Columns.Add("habilitado", typeof(Boolean));
            ModeloPersonas ListarPersonas = new ModeloPersonas();
            foreach (ModeloPersonas p in ListarPersonas.ObtenerTodos())
            {
                DataRow fila = tabla.NewRow();
                fila["id_cuenta"] = p.id_cuenta;
                fila["nombre"] = p.nombre;
                fila["apellido"] = p.apellido;
                fila["telefono"] = p.telefono;
                fila["email"] = p.email;
                fila["fecha_nacimiento"] = p.fecha_nac; 
                fila["habilitado"] = p.habilitacion;
                tabla.Rows.Add(fila);
            }
            return tabla;
        }
        public static List<string> ListarPost(int idUsuario)
        {
            List<string> listaPosts = new List<string>();
            ModeloPersonas ListarPost = new ModeloPersonas();
            foreach (ModeloPersonas p in ListarPost.ObtenerPostUsuario(idUsuario))
            {
                string itemText = $"ID Post: {p.idPost}, Texto: {p.post}, Likes: {p.like}";
                listaPosts.Add(itemText);
            }

            return listaPosts;
        }

        public static void DeshabilitarPost(int id)
        {
            ModeloPersonas Post = new ModeloPersonas();
            Post.idCuenta = id;
            Post.DeshabilitarPost();
        }
        public static void HabilitarPost(int id)
        {
            ModeloPersonas Post = new ModeloPersonas();
            Post.idCuenta = id;
            Post.HabilitarPost();
        }
        public static int ExtraerIdPost(string textoItem)
        {
            try
            {
                string[] partes = textoItem.Split(',');
                string idParte = partes[0];
                string idString = idParte.Split(':')[1].Trim();

                return int.Parse(idString);
            }
            catch (Exception ex)
            {
               Console.Write("Error al extraer el ID del post. Verifique el formato del texto.", "Error");
                return -1;
            }
        }
        public static List<ControladorCuentaUsuario> EstadoPost(int idUsuario)
        {
            List<ControladorCuentaUsuario> estadoPosts = new List<ControladorCuentaUsuario>();
            ModeloPersonas listarPost = new ModeloPersonas();

            foreach (ModeloPersonas p in listarPost.ObtenerPostUsuario(idUsuario))
            {
                string itemText = $"ID Post: {p.idPost}, Texto: {p.post}";
                bool estaHabilitado = p.habilitado == "true";
                estadoPosts.Add(new ControladorCuentaUsuario { TextoPost = itemText, EstaHabilitado = estaHabilitado });
            }

            return estadoPosts;
        }


    }
}

/*
id_post  
id_usuario 
id_cuenta  
texto_post
contador_like 
contador_comentarios 
habilitado

 */

