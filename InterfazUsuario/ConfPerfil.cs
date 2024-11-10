using System;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;
using InterfazUsuario.Properties;
using RestSharp;

namespace InterfazUsuario
{
    public partial class ConfPerfil : Form
    {
        public static ConfPerfil PostInstancia = null;
        public ConfPerfil()
        {
            InitializeComponent();
            CargarIdioma();
           
        }
        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Settings.Default.Idioma = "es-UY";
            CargarIdioma();
        }
        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Settings.Default.Idioma = "en-US";
            CargarIdioma();
        }
        public void CargarIdioma()
        {
            try
            {
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Settings.Default.Idioma);

                Idioma.CambiarTexto(this.Controls);
            }
            catch (CultureNotFoundException)
            {
                Console.WriteLine("El idioma seleccionado no es válido. Por favor, selecciona otro.");
            }
        }

        private void btnCambiar_Click(object sender, EventArgs e)
        {
            try
            {
                int idPerfil = DatosDePerfil.idPerfil;
                string email = DatosDePerfil.email;
                string emailNuevo = DatosDePerfil.emailNuevo;
                string nombre = textBox1.Text;
                string apellido = textBox2.Text;
                string telefono = DatosDePerfil.telefono;
                string apodo = textBox3.Text;
                string idFotoPerfil = DatosDePerfil.idFotoPerfil;
                string idioma = DatosDePerfil.idioma;
                string atributo1 = DatosDePerfil.atributo1;
                string atributo2 = DatosDePerfil.atributo2;
                string contrasena = DatosDePerfil.contrasena;
                ModificarUsuario(idPerfil, email, emailNuevo, nombre, apellido, telefono, apodo, idFotoPerfil, idioma, atributo1, atributo2, contrasena);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar los datos del perfil: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void lblCambiarContrasena_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (CambiarPass.PostInstancia == null || CambiarPass.PostInstancia.IsDisposed)
            {
                CambiarPass.PostInstancia = new CambiarPass();
                CambiarPass.PostInstancia.Show();
            }
            else
            {
                CambiarPass.PostInstancia.WindowState = FormWindowState.Normal;
                CambiarPass.PostInstancia.BringToFront();
            }
        }

        public static void ModificarPerfil(int id, string email, string apodo, string idFotoPerfil, string idioma, string atributo1, string atributo2, string contrasena)
        {
            try
            {
                RestClient client = new RestClient("https://localhost:44331/");
                RestRequest request = new RestRequest($"api/Usuario/ModificarPerfil/{id}/", Method.Put);
                request.AddHeader("Accept", "application/json");

                var usuarioData = new
                {
                    email,apodo,idFotoPerfil,idioma = string.IsNullOrEmpty(idioma) ? "espanol" : idioma,atributo1,atributo2,contrasena
                };
                request.AddJsonBody(usuarioData);
                RestResponse response = client.Execute(request);
                if (!response.IsSuccessful)
                {
                    MessageBox.Show("Error al modificar el perfil del usuario: " + response.Content, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Console.Write("Usuario modificado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un problema al intentar modificar el perfil del usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void ModificarCuenta(int id, string email, string emailNuevo, string nombre, string apellido, string telefono)
        {
            try
            {
                RestClient client = new RestClient("https://localhost:44331/");
                RestRequest request = new RestRequest($"api/Usuario/ModificarCuenta/{id}/", Method.Put);
                request.AddHeader("Accept", "application/json");

                var usuarioData = new
                {
                    email, emailNuevo = string.IsNullOrEmpty(emailNuevo) ? email : emailNuevo, nombre, apellido, telefono };
                request.AddJsonBody(usuarioData);

                RestResponse response = client.Execute(request);

                if (!response.IsSuccessful)
                {
                    MessageBox.Show("Error al modificar el usuario: " + response.Content, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Console.Write("Usuario modificado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un problema al intentar modificar el usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void ModificarUsuario(int id, string email, string emailNuevo, string nombre, string apellido, string telefono, string apodo, string idFotoPerfil, string idioma, string atributo1, string atributo2, string contrasena)
        {
            try
            {
                ModificarCuenta(id, email, emailNuevo, nombre, apellido, telefono);
                ModificarPerfil(id, email, apodo, idFotoPerfil, idioma, atributo1, atributo2, contrasena);

                MessageBox.Show("Datos de perfil modificados exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un problema al intentar modificar el usuario o su perfil: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}

/*
                
        private void CrearPostTexto(int idPerfil, string descripcion)
                {
                    var client = new RestClient("https://localhost:44358/");
                    var request = new RestRequest("api/Post/CrearPostTexto/", Method.Post);
                    request.AddJsonBody(new { idPerfil, descripcion });

                    var response = client.Execute(request);
                    if (!response.IsSuccessful)
                        throw new Exception("Error al crear el post de texto.");
                }
        private void CrearPostImagen(int idPerfil, string descripcion, string idImagen)
                {
                    var client = new RestClient("https://localhost:44358/");
                    var request = new RestRequest("api/Post/CrearPostImagen/", Method.Post);
                    request.AddJsonBody(new { idPerfil, descripcion, idImagen });

                    var response = client.Execute(request);
                    if (!response.IsSuccessful)
                        throw new Exception("Error al crear el post con imagen.");
                }
        private void CrearPostVideo(int idPerfil, string descripcion, string idVideo)
                {
                    var client = new RestClient("https://localhost:44358/");
                    var request = new RestRequest("api/Post/CrearPostVideo/", Method.Post);
                    request.AddJsonBody(new { idPerfil, descripcion, idVideo });

                    var response = client.Execute(request);
                    if (!response.IsSuccessful)
                        throw new Exception("Error al crear el post con video.");
                }
        private void CrearPostAudio(int idPerfil, string descripcion, string idAudio)
                {
                    var client = new RestClient("https://localhost:44358/");
                    var request = new RestRequest("api/Post/CrearPostAudio/", Method.Post);
                    request.AddJsonBody(new { idPerfil, descripcion, idAudio });

                    var response = client.Execute(request);
                    if (!response.IsSuccessful)
                        throw new Exception("Error al crear el post con audio.");
                }
        private void ModificarPost(int id, string nuevaDescripcion)
                {
                    var client = new RestClient("https://localhost:44358/");
                    var request = new RestRequest($"api/Post/ModificarPost/{id}/", Method.Put);
                    request.AddJsonBody(new { descripcion = nuevaDescripcion });

                    var response = client.Execute(request);

                    if (!response.IsSuccessful)
                        MessageBox.Show($"Error al modificar el post: {response.Content}");
                    else
                        MessageBox.Show("Post modificado exitosamente.");
                }
        private void DeshabilitarPost(int id)
                {
                    var client = new RestClient("https://localhost:44358/");
                    var request = new RestRequest($"api/Post/DeshabilitarPost/{id}/", Method.Delete);

                    var response = client.Execute(request);

                    if (!response.IsSuccessful)
                        MessageBox.Show($"Error al deshabilitar el post: {response.Content}");
                    else
                        MessageBox.Show("Post deshabilitado exitosamente.");
                }
        private void HabilitarPost(int id)
                {
                    var client = new RestClient("https://localhost:44358/");
                    var request = new RestRequest($"api/Post/HabilitarPost/{id}/", Method.Put);

                    var response = client.Execute(request);

                    if (!response.IsSuccessful)
                        MessageBox.Show($"Error al habilitar el post: {response.Content}");
                    else
                        MessageBox.Show("Post habilitado exitosamente.");
                }
       
        public int ContarComentarios(int idPost)
        {
            RestClient client = new RestClient("https://localhost:44358/");
            RestRequest request = new RestRequest($"api/Post/ContarComentarios/{idPost}", Method.Get);
            var response = client.Execute(request);

            if (!response.IsSuccessful)
                throw new Exception("Error al contar los comentarios.");

            var result = JsonConvert.DeserializeObject<Dictionary<string, int>>(response.Content);
            return result.ContainsKey("cantidad") ? result["cantidad"] : 0;
        }
        public string DeshabilitarComentario(int idComentario)
        {
            RestClient client = new RestClient("https://localhost:44358/");
            RestRequest request = new RestRequest($"api/Post/DeshabilitarComentario/{idComentario}", Method.Put);
            var response = client.Execute(request);

            if (!response.IsSuccessful)
                throw new Exception("Error al deshabilitar el comentario.");

            var result = JsonConvert.DeserializeObject<Dictionary<string, string>>(response.Content);
            return result.ContainsKey("mensaje") ? result["mensaje"] : "Error desconocido";
        }
        public string HabilitarComentario(int idComentario)
        {
            RestClient client = new RestClient("https://localhost:44358/");
            RestRequest request = new RestRequest($"api/Post/HabilitarComentario/{idComentario}", Method.Put);
            var response = client.Execute(request);

            if (!response.IsSuccessful)
                throw new Exception("Error al habilitar el comentario.");

            var result = JsonConvert.DeserializeObject<Dictionary<string, string>>(response.Content);
            return result.ContainsKey("mensaje") ? result["mensaje"] : "Error desconocido";
        }
        public string ModificarComentario(int idComentario, string nuevoComentario)
        {
            RestClient client = new RestClient("https://localhost:44358/");
            RestRequest request = new RestRequest("api/Post/ModificarComentario", Method.Put);
            request.AddJsonBody(new { idComentario = idComentario, comentario = nuevoComentario });
            var response = client.Execute(request);

            if (!response.IsSuccessful)
                throw new Exception("Error al modificar el comentario.");

            var result = JsonConvert.DeserializeObject<Dictionary<string, string>>(response.Content);
            return result.ContainsKey("mensaje") ? result["mensaje"] : "Error desconocido";
        }
        public string CompartirPost(int idPost, int idPerfil)
        {
            RestClient client = new RestClient("https://localhost:44358/");
            RestRequest request = new RestRequest($"api/Post/CompartirPost/{idPost}/{idPerfil}", Method.Post);
            var response = client.Execute(request);

            if (!response.IsSuccessful)
                throw new Exception("Error al compartir el post.");

            var result = JsonConvert.DeserializeObject<Dictionary<string, string>>(response.Content);
            return result.ContainsKey("mensaje") ? result["mensaje"] : "Error desconocido";
        }
        public string DarLike(int idPost, int idPerfil)
        {
            RestClient client = new RestClient("https://localhost:44358/");
            RestRequest request = new RestRequest("api/Post/DarLike", Method.Post);
            request.AddJsonBody(new { idPost = idPost, idPerfil = idPerfil });
            var response = client.Execute(request);

            if (!response.IsSuccessful)
                throw new Exception("Error al dar like.");

            var result = JsonConvert.DeserializeObject<Dictionary<string, string>>(response.Content);
            return result.ContainsKey("mensaje") ? result["mensaje"] : "Error desconocido";
        }
        public string EliminarLike(int idPost, int idPerfil)
        {
            RestClient client = new RestClient("https://localhost:44358/");
            RestRequest request = new RestRequest("api/Post/EliminarLike", Method.Post);
            request.AddJsonBody(new { idPost = idPost, idPerfil = idPerfil });
            var response = client.Execute(request);

            if (!response.IsSuccessful)
                throw new Exception("Error al eliminar like.");

            var result = JsonConvert.DeserializeObject<Dictionary<string, string>>(response.Content);
            return result.ContainsKey("mensaje") ? result["mensaje"] : "Error desconocido";
        }
        public int ContarLikes(int idPost)
        {
            RestClient client = new RestClient("https://localhost:44358/");
            RestRequest request = new RestRequest($"api/Post/ContarLikes/{idPost}", Method.Get);
            var response = client.Execute(request);

            if (!response.IsSuccessful)
                throw new Exception("Error al contar los likes.");

            var result = JsonConvert.DeserializeObject<Dictionary<string, int>>(response.Content);
            return result.ContainsKey("cantidad") ? result["cantidad"] : 0;
        }
        public string ComentarPost(int idPost, int idPerfil, string comentario)
        {
            RestClient client = new RestClient("https://localhost:44358/");
            RestRequest request = new RestRequest("api/Post/ComentarPost", Method.Post);
            request.AddJsonBody(new { idPost = idPost, idPerfil = idPerfil, comentario = comentario });
            var response = client.Execute(request);

            if (!response.IsSuccessful)
                throw new Exception("Error al comentar el post.");

            var result = JsonConvert.DeserializeObject<Dictionary<string, string>>(response.Content);
            return result.ContainsKey("mensaje") ? result["mensaje"] : "Error desconocido";
        }
        public List<string> ObtenerPostTexto(int idPerfil)
        {
            RestClient client = new RestClient("https://localhost:44358/");
            RestRequest request = new RestRequest($"api/Post/ObtenerTexto/{idPerfil}", Method.Get);
            var response = client.Execute(request);

            if (!response.IsSuccessful)
                throw new Exception("Error al obtener las publicaciones de texto.");

            var posts = JsonConvert.DeserializeObject<List<string>>(response.Content);
            return posts;
        }
        public List<string> ObtenerPostImagen(int idPerfil)
        {
            RestClient client = new RestClient("https://localhost:44358/");
            RestRequest request = new RestRequest($"api/Post/ObtenerImagen/{idPerfil}", Method.Get);
            var response = client.Execute(request);

            if (!response.IsSuccessful)
                throw new Exception("Error al obtener las publicaciones con imágenes.");

            var posts = JsonConvert.DeserializeObject<List<string>>(response.Content);
            return posts;
        }
        public List<string> ObtenerPostVideo(int idPerfil)
        {
            RestClient client = new RestClient("https://localhost:44358/");
            RestRequest request = new RestRequest($"api/Post/ObtenerVideo/{idPerfil}", Method.Get);
            var response = client.Execute(request);

            if (!response.IsSuccessful)
                throw new Exception("Error al obtener las publicaciones con video.");

            var posts = JsonConvert.DeserializeObject<List<string>>(response.Content);
            return posts;
        }
        public List<string> ObtenerPostAudio(int idPerfil)
        {
            RestClient client = new RestClient("https://localhost:44358/");
            RestRequest request = new RestRequest($"api/Post/ObtenerAudio/{idPerfil}", Method.Get);
            var response = client.Execute(request);

            if (!response.IsSuccessful)
                throw new Exception("Error al obtener las publicaciones con audio.");

            var posts = JsonConvert.DeserializeObject<List<string>>(response.Content);
            return posts;
        }
        private List<string> ObtenerPosts()
        {
            RestClient client = new RestClient("https://localhost:44358/");
            RestRequest request = new RestRequest("api/Post/ListarPost/", Method.Get);
            var response = client.Execute(request);

            if (!response.IsSuccessful)
                throw new Exception("Error al obtener los posts desde la API.");

            try
            {
                var posts = JsonConvert.DeserializeObject<List<string>>(response.Content);
                return posts;
            }
            catch (JsonException ex)
            {
                throw new Exception($"Error al deserializar la respuesta JSON: {response.Content}", ex);
            }
        }
        private static void MeSiguen(int idPerfil)
        {
            RestClient client = new RestClient("https://localhost:44331/");
            RestRequest request = new RestRequest($"api/Usuario/MeSiguen/{idPerfil}/", Method.Get);
            request.AddHeader("Accept", "application/json");

            RestResponse response = client.Execute(request);

            if (response.IsSuccessful)
            {
                List<string> meSiguen = JsonConvert.DeserializeObject<List<string>>(response.Content);
                DatosDePerfil.Seguidores = meSiguen;
                return;
            }
            Console.WriteLine($"Error: {response.StatusCode} - {response.ErrorMessage}");
            DatosDePerfil.Seguidores = new List<string>();
            return;

        }
        private static void CantidadMeSiguen(int idPerfil)
        {
            RestClient client = new RestClient("https://localhost:44331/");
            RestRequest request = new RestRequest($"api/Usuario/CantidadSeguidores/{idPerfil}/", Method.Get);
            request.AddHeader("Accept", "application/json");

            RestResponse response = client.Execute(request);

            if (response.IsSuccessful)
            {
                var result = JsonConvert.DeserializeObject<dynamic>(response.Content);
                int cantidadMeSiguen = result?.cantidadSeguidores;

                DatosDePerfil.CantidadSeguidores = cantidadMeSiguen;
                return;
            }

            Console.WriteLine($"Error: {response.StatusCode} - {response.ErrorMessage}");
            DatosDePerfil.CantidadSeguidores = 0;
            return;
        }
        private static void Seguidos(int idPerfil)
        {
            RestClient client = new RestClient("https://localhost:44331/");
            RestRequest request = new RestRequest($"api/Usuario/Sigo/{idPerfil}/", Method.Get);
            request.AddHeader("Accept", "application/json");

            RestResponse response = client.Execute(request);

            if (response.IsSuccessful)
            {
                List<string> seguidos = JsonConvert.DeserializeObject<List<string>>(response.Content);
                DatosDePerfil.Seguidos = seguidos;
                return;
            }
            Console.WriteLine($"Error: {response.StatusCode} - {response.ErrorMessage}");
            DatosDePerfil.Seguidos = new List<string>();
            return;
        }
        private static void CantidadSeguidos(int idPerfil)
        {
            RestClient client = new RestClient("https://localhost:44331/");
            RestRequest request = new RestRequest($"api/Usuario/CantidadSeguidos/{idPerfil}/", Method.Get);
            request.AddHeader("Accept", "application/json");

            RestResponse response = client.Execute(request);

            if (response.IsSuccessful)
            {
                var result = JsonConvert.DeserializeObject<dynamic>(response.Content);
                int cantidadSeguidos = result?.cantidadSeguidos;

                DatosDePerfil.CantidadSeguidos = cantidadSeguidos;
                return;
            }

            Console.WriteLine($"Error: {response.StatusCode} - {response.ErrorMessage}");
            DatosDePerfil.CantidadSeguidos = 0;
            return;
        }

*/