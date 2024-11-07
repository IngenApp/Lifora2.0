using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;
using InterfazUsuario.Properties;
using Newtonsoft.Json;
using RestSharp;


namespace InterfazUsuario
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            CargarIdioma();
        }

        
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
                public static void ModificarUsuario(int id, string email, string apodo, string atributo1, string atributo2, string contrasena, string idioma, int idFotoPerfil)
                {
                    try
                    {
                        RestClient client = new RestClient("https://localhost:44331/");
                        RestRequest request = new RestRequest($"api/Usuario/ModificarUsuario/{id}/", Method.Put);
                        request.AddHeader("Accept", "application/json");

                        var usuarioData = new
                        {
                            email,
                            apodo,
                            atributo1,
                            atributo2,
                            idioma = string.IsNullOrEmpty(idioma) ? "espanol" : idioma,
                            idFotoPerfil
                        };
                        request.AddJsonBody(usuarioData);

                        RestResponse response = client.Execute(request);

                        if (!response.IsSuccessful)
                        {
                            MessageBox.Show("Error al modificar el usuario: " + response.Content, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show("Usuario modificado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hubo un problema al intentar modificar el usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                private RestResponse HacerSolicitudLogin()
                {
                    var datosLogin = CrearDatosLogin();
                    string requestBody = JsonConvert.SerializeObject(datosLogin);

                    RestClient client = new RestClient("https://localhost:44331/");
                    RestRequest request = new RestRequest("/api/Usuario/Login", Method.Post);

                    request.AddJsonBody(requestBody);
                    request.AddHeader("Accept", "application/json");
                    request.AddHeader("Content-Type", "application/json");

                    return client.Execute(request);
                }

                private void ProcesarLoginExitoso()
                {
                    string email = txtBoxEmail.Text;
                    Dictionary<string, string> perfil = ObtenerPerfilUsuario(email);
                    if (perfil == null)
                    {
                    MessageBox.Show("El perfil de usuario no existe.");
                    return;
                    }
                    AsignarDatosDePerfil(perfil);
                    AbrirInicio();
                }

                private void AbrirInicio()
                {
                    Inicio inicio = new Inicio();
                    inicio.Show();
                    this.Hide();
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
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Registrarse1 Registrarse1 = new Registrarse1();
            Registrarse1.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                RestResponse response = HacerSolicitudLogin();

                if (response.IsSuccessful)
                {
                    ProcesarLoginExitoso();
                    return;
                }
                MostrarMensajeCredencialesIncorrectas();
            }
            catch (Exception ex)
            {
                MostrarError(ex.Message);
            }
        }


        private Dictionary<string, string> CrearDatosLogin()
        {
            return new Dictionary<string, string>
            {
                { "email", txtBoxEmail.Text },
                { "contrasena", txtBoxPass.Text }
            };
           
        }

        private void MostrarMensajeCredencialesIncorrectas()
        {
            if (Settings.Default.Idioma == "es-UY")
            {
                MessageBox.Show("Credenciales incorrectas");
            }
            else if (Settings.Default.Idioma == "en-US")
            {
                MessageBox.Show("Incorrect credentials");
            }
        }

        private void MostrarError(string mensaje)
        {
            MessageBox.Show($"Ocurrió un error: {mensaje}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private Dictionary<string, string> ObtenerPerfilUsuario(string email)
        {
            RestClient client = new RestClient("https://localhost:44331/");
            RestRequest request = new RestRequest($"/api/Usuario/{email}/", Method.Get);
            request.AddHeader("Accept", "application/json");

            RestResponse response = client.Execute(request);
            if (!response.IsSuccessful || string.IsNullOrEmpty(response.Content))
            {
                MessageBox.Show("No se encontró el perfil de usuario.");
                return null;
            }

            return JsonConvert.DeserializeObject<Dictionary<string, string>>(response.Content);
        }

        private void AsignarDatosDePerfil(Dictionary<string, string> perfil)
        {
            DatosDePerfil.Seguidores = DatosDePerfil.Seguidores ?? new List<string>();
            DatosDePerfil.Seguidos = DatosDePerfil.Seguidos ?? new List<string>();

            if (perfil.TryGetValue("id_perfil", out string idPerfilValue) && int.TryParse(idPerfilValue, out int idPerfil))
                DatosDePerfil.idPerfil = idPerfil;

            if (perfil.TryGetValue("apodo", out string apodo))
                DatosDePerfil.apodo = apodo;

            if (perfil.TryGetValue("email", out string email))
                DatosDePerfil.email = email;

            if (perfil.TryGetValue("telefono", out string telefono))
                DatosDePerfil.telefono = telefono;

            if (perfil.TryGetValue("nombre", out string nombre))
                DatosDePerfil.nombre = nombre;

            if (perfil.TryGetValue("apellido", out string apellido))
                DatosDePerfil.apellido = apellido;

            if (perfil.TryGetValue("fecha_nacimiento", out string fechaNacimiento))
                DatosDePerfil.fechaNacimiento = fechaNacimiento;

            if (perfil.TryGetValue("id_foto_perfil", out string idFotoPerfilValue) && int.TryParse(idFotoPerfilValue, out int idFotoPerfil))
                DatosDePerfil.idFotoPerfil = idFotoPerfil;
            else
                DatosDePerfil.idFotoPerfil = null;

            if (perfil.TryGetValue("idioma", out string idioma))
                DatosDePerfil.idioma = idioma;

            if (perfil.TryGetValue("atributo1", out string atributo1))
                DatosDePerfil.atributo1 = atributo1;

            if (perfil.TryGetValue("atributo2", out string atributo2))
                DatosDePerfil.atributo2 = atributo2;
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

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Settings.Default.Save();
        }

        private void txtBoxPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e);

                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
    }
}
