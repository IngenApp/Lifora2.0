using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;
using InterfazUsuario.Properties;
using RestSharp;
using Newtonsoft.Json;
using ApiPost.Models;
using System.Data;
using System.Text;

namespace InterfazUsuario
{
    public partial class Inicio : Form
    {
        public Form Login;
        public string email;
        private GestorDePosts gestorDePosts;
        public Inicio()
        {
            InitializeComponent();
            CargarIdioma();
            gestorDePosts = new GestorDePosts(panel1, panel2, panel3, panel4);
            MakeCircularPictureBox(pictureBox2);
            Nickname.Text = DatosDePerfil.apodo;

        }
        private void MakeCircularPictureBox(PictureBox pictureBox2)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, pictureBox2.Width, pictureBox2.Height);
            pictureBox2.Region = new Region(path);
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
         private void pictureBox2_Click(object sender, EventArgs e)
        {
            PerfilPrincipal perfil = new PerfilPrincipal();
            perfil.Show();
            perfil.inicio = this;
            this.Hide();

        }
        private void Inicio_FormClosing(object sender, FormClosingEventArgs e)
        {
            Login.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            AbrirPost();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
            // actualizar muro
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PerfilPrincipal perfil = new PerfilPrincipal();
            perfil.Show();
            perfil.inicio = this;
            this.Hide();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            AbrirMensajes();
        }        
        private void AbrirMensajes()
        {
            if (Mensajes.MensajeInstancia == null || Mensajes.MensajeInstancia.IsDisposed)
            {
                Mensajes.MensajeInstancia = new Mensajes();
                Mensajes.MensajeInstancia.Show();
            }
            else
            {
                Mensajes.MensajeInstancia.WindowState = FormWindowState.Normal;
                Mensajes.MensajeInstancia.BringToFront();
            }
        }
        private void AbrirPost()
        {
            if (CrearPost.PostInstancia == null || CrearPost.PostInstancia.IsDisposed)
            {
                CrearPost.PostInstancia = new CrearPost();
                CrearPost.PostInstancia.Show();
            }
            else
            {
                CrearPost.PostInstancia.WindowState = FormWindowState.Normal;
                CrearPost.PostInstancia.BringToFront();
            }
        }
        private void AbrirEventoMenu()
        {
            if (EventosMenu.eventoInstancia == null || EventosMenu.eventoInstancia.IsDisposed)
            {
                EventosMenu.eventoInstancia = new EventosMenu();
                EventosMenu.eventoInstancia.Show();
            }
            else
            {
                EventosMenu.eventoInstancia.WindowState = FormWindowState.Normal;
                EventosMenu.eventoInstancia.BringToFront();
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            AbrirEventoMenu();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (GruposMenu.menuGruposInstancia == null || GruposMenu.menuGruposInstancia.IsDisposed)
            {
                GruposMenu.menuGruposInstancia = new GruposMenu();
                GruposMenu.menuGruposInstancia.Show();
            }
            else
            {
                GruposMenu.menuGruposInstancia.WindowState = FormWindowState.Normal;
                GruposMenu.menuGruposInstancia.BringToFront();
            }
        }
         private void MuroTexto(object sender, EventArgs e)
        {
            panel1.Show();
            panel2.Hide();
            panel3.Hide();
            panel4.Hide();
            List<ModeloApiPost> listaPosts = ListarTodosLosPost();
            List<string> apodo = new List<string>();
            List<string> descripcion = new List<string>();
            List<string> cantidadLikes = new List<string>();
            List<string> cantidadComentarios = new List<string>();
            foreach (var post in listaPosts)
            {
                apodo.Add(post.Apodo);
                descripcion.Add(post.Descripcion);

                int likes = ContarLikes(post.IdPost);
                int comentarios = ContarComentarios(post.IdPost);

                cantidadLikes.Add(likes.ToString());
                cantidadComentarios.Add(comentarios.ToString());
            }
            gestorDePosts.PostTexto(apodo, descripcion, cantidadLikes, cantidadComentarios);

        }
        private static List<ModeloApiPost> ListarTodosLosPost()
        {
            RestClient client = new RestClient("https://localhost:44358/");
            RestRequest request = new RestRequest("api/Post/ListarPost/", Method.Get);
            request.AddHeader("Accept", "application/json");
            RestResponse response = client.Execute(request);

            if (!response.IsSuccessful)
                throw new Exception("Error al obtener los posts.");

            List<ModeloApiPost> posts = JsonConvert.DeserializeObject<List<ModeloApiPost>>(response.Content);

            return posts;
        }
        public static int ContarLikes(int idPost)
        {
            RestClient client = new RestClient("https://localhost:44358/");
            RestRequest request = new RestRequest($"api/Post/ContarLikes/{idPost}", Method.Get);
            request.AddHeader("Accept", "application/json");
            RestResponse response = client.Execute(request);

            if (!response.IsSuccessful)
                throw new Exception("Error al contar los likes.");

            var result = JsonConvert.DeserializeObject<Dictionary<string, int>>(response.Content);
            return result.ContainsKey("cantidad") ? result["cantidad"] : 0;
        }
        public static int ContarComentarios(int idPost)
        {
            RestClient client = new RestClient("https://localhost:44358/");
            RestRequest request = new RestRequest($"api/Post/ContarComentarios/{idPost}", Method.Get);
            request.AddHeader("Accept", "application/json");
            RestResponse response = client.Execute(request);

            if (!response.IsSuccessful)
                throw new Exception("Error al contar los comentarios.");

            var result = JsonConvert.DeserializeObject<Dictionary<string, int>>(response.Content);
            return result.ContainsKey("cantidad") ? result["cantidad"] : 0;
        }



    
        private void MuroImagenes(object sender, EventArgs e)
        {
           
            panel1.Hide();
            panel2.Show();
            panel3.Hide();
            panel4.Hide();
            List<string> apodos = new List<string> { "Apodo1", "Apodo2", "Apodo3", "Apodo4", "Apodo5", "Apodo6", "Apodo7", "Apodo8" };
            List<string> descripcion = new List<string> { "post1", "post2", "post3", "post1", "post2", "post3", "post2", "post3" };
            List<string> idImagenes = new List<string> { @"D:\Azir Cosp\1.jpg", @"D:\Azir Cosp\3.jpg", @"D:\Azir Cosp\6.jpg", @"D:\Azir Cosp\7.jpg", @"D:\Azir Cosp\8.jpg", @"D:\Azir Cosp\11.jpg", @"D:\Azir Cosp\9.jpg", @"D:\Azir Cosp\12.jpg" };
            List<string> cantidadLikes = new List<string> { "10", "15", "20", "10", "15", "20", "15", "20" };
            List<string> cantidadComentarios = new List<string> { "15", "20", "30", "15", "20", "30", "15", "20" };

            gestorDePosts.CargarImagenes(apodos, descripcion, idImagenes, cantidadLikes, cantidadComentarios);
        }
        private void MuroVideos(object sender, EventArgs e)
        {
            
            panel1.Hide();
            panel2.Hide();
            panel3.Show();
            panel4.Hide();
            List<string> apodo = new List<string> { "Apodo1", "Apodo2", "Apodo3", "Apodo4" };
            List<string> descripcion = new List<string> { "post1", "post2", "post3", "post1", "post2", "post3" };
            List<string> idVideo = new List<string> { @"C:\Users\stive\OneDrive\Escritorio\MEGUSTA.mp4", @"D:\Azir Cosp\Azir.mp4", @"C:\Users\stive\OneDrive\Escritorio\MEGUSTA.mp4", @"D:\Azir Cosp\Azir.mp4" };
            List<string> cantidadLikes = new List<string> { "10", "15", "20", "10", "15", "20" };
            List<string> cantidadComentarios = new List<string> { "15", "20", "30", "15", "20", "30" };
            gestorDePosts.CargarVideos(apodo, descripcion, idVideo, cantidadLikes, cantidadComentarios);
        } 
        private void MuroAudios(object sender, EventArgs e)
        {
       

            panel1.Hide();
            panel2.Hide();
            panel3.Hide();
            panel4.Show();
            List<string> apodos = new List<string> { "Apodo1", "Apodo2", "Apodo3", "Apodo4" };
            List<string> descripcion = new List<string> { "post1", "post2", "post3", "post1", "post2", "post3" };
            List<string> idAudios= new List<string> { @"C:\Users\stive\OneDrive\Escritorio\Silent Hill Original Soundtrack\01 - Silent Hill.mp3", @"C:\Users\stive\OneDrive\Escritorio\Silent Hill Original Soundtrack\02 - All.mp3", @"C:\Users\stive\OneDrive\Escritorio\Silent Hill Original Soundtrack\03 - The Wait.mp3", @"C:\Users\stive\OneDrive\Escritorio\Silent Hill Original Soundtrack\04 - Until Death.mp3" };
            List<string> cantidadLikes = new List<string> { "10", "15", "20", "10", "15", "20" };
            List<string> cantidadComentarios = new List<string> { "15", "20", "30", "15", "20", "30" };
            gestorDePosts.CargarAudios(apodos, descripcion, idAudios, cantidadLikes, cantidadComentarios);
        }
        private void Inicio_FormClosed(object sender, FormClosedEventArgs e)
        {
            Settings.Default.Save();
        }
        private void Inicio_Load(object sender, EventArgs e)
        {
            MuroTexto(this, EventArgs.Empty);
            ReproductorPublicidad.URL = @"C:\Users\stive\OneDrive\Escritorio\MEGUSTA.mp4";
            ReproductorPublicidad.uiMode = "none";
            ReproductorPublicidad.settings.mute = true;
        }
        private void pictureBox8_Click(object sender, EventArgs e)
        {
            if (ConfPerfil.PostInstancia == null || ConfPerfil.PostInstancia.IsDisposed)
            {
                ConfPerfil.PostInstancia = new ConfPerfil();
                ConfPerfil.PostInstancia.Show();
            }
            else
            {
                ConfPerfil.PostInstancia.WindowState = FormWindowState.Normal;
                ConfPerfil.PostInstancia.BringToFront();
            }
        }

  
    }
}

/*
            private static List<ModeloApiPost> ListarTodosLosPost()
            {
                RestClient client = new RestClient("https://localhost:44358/");
                RestRequest request = new RestRequest("api/Post/ListarPost/", Method.Get);
                request.AddHeader("Accept", "application/json");
                RestResponse response = client.Execute(request);

                List<ModeloApiPost> posts = JsonConvert.DeserializeObject<List<ModeloApiPost>>(response.Content);

                return posts;
            }
            private static List<ModeloApiPost> ObtenerPostTexto(int idPerfil)
            {
                RestClient client = new RestClient("https://localhost:44358/");
                RestRequest request = new RestRequest($"api/Post/ObtenerTexto/{idPerfil}", Method.Get);
                request.AddHeader("Accept", "application/json");
                RestResponse response = client.Execute(request);

                List<ModeloApiPost> posts = JsonConvert.DeserializeObject<List<ModeloApiPost>>(response.Content);

                return posts;
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
            private static DataTable generarDataTable(List<ModeloApiPost> posts)
            {
                DataTable tabla = new DataTable();
                tabla.Columns.Add("idPerfil", typeof(int));
                tabla.Columns.Add("descripcion", typeof(string));

                foreach (ModeloApiPost p in posts)
                {
                    DataRow fila = tabla.NewRow();
                    fila["idPerfil"] = p.idPerfil;
                    fila["descripcion"] = p.descripcion;
                    tabla.Rows.Add(fila);
                }

                return tabla;
            }
    */

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

/*
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
            inicio.Login = this;
            this.Hide();
        }
        private Dictionary<string, string> CrearDatosLogin()
        {
            return new Dictionary<string, string>
            {
                { "email", txtBoxEmail.Text },
                { "contrasena", txtBoxPass.Text }
            };
           
        }
 */


/* if (CrearTextoPost(DatosDePerfil.idPerfil, richTextBox1.Text))
                    {
                        MessageBox.Show("Post Created");
                    }





  //api crear post de texto
            if (string.IsNullOrEmpty(richTextBox1.Text))
            {
                if (CrearTextoPost(DatosDePerfil.idPerfil, richTextBox1.Text))
                {
                    MessageBox.Show("Post Creado");
                    if (Settings.Default.Idioma == "es-UY")
                    {
                        MessageBox.Show("Ingrese lo que desea compartir");
                    }
                    else if (Settings.Default.Idioma == "en-US")
                    {
                        MessageBox.Show("Enter what you want to share");

                    }
                }
                return; 
            }





private bool CrearTextoPost(int idPerfil, string descripcion)
{
    Dictionary<string, string> data = new Dictionary<string, string>(){
                { "idPerfil", DatosDePerfil.idPerfil.ToString() },
                { "descripcion", richTextBox1.Text }
            };
    string requestBody = JsonConvert.SerializeObject(data);

    var client = new RestClient("https://localhost:44358/");
    var request = new RestRequest("api/Post/CrearPostTexto/", Method.Post);

    request.RequestFormat = DataFormat.Json;
    request.AddBody(requestBody);
    request.AddHeader("Accept", "application/json");
    request.AddHeader("Content-Type", "application/json");

    RestResponse response = client.Execute(request);

    if (response.IsSuccessStatusCode)
        return true;
    return false;
}

private static DataTable generarDataTable(List<ModeloApiPost> posts)
{
    DataTable tabla = new DataTable();
    tabla.Columns.Add("idPerfil", typeof(int));
    tabla.Columns.Add("descripcion", typeof(string));

    foreach (ModeloApiPost p in posts)
    {
        DataRow fila = tabla.NewRow();
        fila["idPerfil"] = p.idPerfil;
        fila["descripcion"] = p.descripcion;
        tabla.Rows.Add(fila);
    }

    return tabla;
}



if (CrearTextoPost(DatosDePerfil.idPerfil, richTextBox1.Text))
                        {
                        }
 
 
 */

/*   
         private string DataTableToString(DataTable tabla)
         {
             StringBuilder sb = new StringBuilder();
             foreach (DataColumn columna in tabla.Columns)
             {
                 sb.Append(columna.ColumnName + "\t");
             }
      private void listar()
                   {
                       list<modeloapipost> posts = obtenerposttexto(datosdeperfil.idperfil);
                       datatable tabla = generardatatable(posts);
                       richtextbox1.text = datatabletostring(tabla);
                   }


             sb.AppendLine();
             foreach (DataRow fila in tabla.Rows)
             {
                 foreach (var item in fila.ItemArray)
                 {
                     sb.Append(item.ToString() + "\t");
                 }
                 sb.AppendLine();
             }

             return sb.ToString();
         }

            private string datatabletostring(datatable tabla)
            {
                stringbuilder sb = new stringbuilder();

                foreach (datacolumn columna in tabla.columns)
                {
                    sb.append(columna.columnname + "\t");
                }
                sb.appendline();

                foreach (datarow fila in tabla.rows)
                {
                    foreach (var item in fila.itemarray)
                    {
                        sb.append(item.tostring() + "\t");
                    }
                    sb.appendline();
                }

                return sb.tostring();
            }
            2

            private static list<modeloapipost> listartodoslospost()
            {
                restclient client = new restclient("https://localhost:44358/");
                restrequest request = new restrequest($"api/post/listarpost/", method.get);
                request.addheader("accept", "application/json");
                restresponse response = client.execute(request);
                list<modeloapipost> posts;
                posts = jsonconvert.deserializeobject<list<modeloapipost>>(response.content);

                return posts;
            }
            private static list<modeloapipost> obtenerposttexto(int idperfil)
            {
                restclient client = new restclient("https://localhost:44358/");
                restrequest request = new restrequest($"api/post/obtenertexto/{idperfil}", method.get);
                request.addheader("accept", "application/json");
                restresponse response = client.execute(request);
                list<modeloapipost> posts;
                posts = jsonconvert.deserializeobject<list<modeloapipost>>(response.content);

                return posts;
            }
            2
            private static datatable generardatatable(list<modeloapipost> posts)
            {
                datatable tabla = new datatable();
                tabla.columns.add("idperfil", typeof(int));
                tabla.columns.add("descripcion", typeof(string));

                foreach (modeloapipost p in posts)
                {
                    datarow fila = tabla.newrow();
                    fila["idperfil"] = p.idperfil;
                    fila["descripcion"] = p.descripcion;
                    tabla.rows.add(fila);
                }

                return tabla;
            }
            3
            private void listar()
            {
                list<modeloapipost> posts = obtenerposttexto(datosdeperfil.idperfil);
                datatable tabla = generardatatable(posts);
                richtextbox1.text = datatabletostring(tabla);
            }
            private string datatabletostring(datatable tabla)
            {
                stringbuilder sb = new stringbuilder();

                foreach (datacolumn columna in tabla.columns)
                {
                    sb.append(columna.columnname + "\t");
                }
                sb.appendline();

                foreach (datarow fila in tabla.rows)
                {
                    foreach (var item in fila.itemarray)
                    {
                        sb.append(item.tostring() + "\t");
                    }
                    sb.appendline();
                }

                return sb.tostring();
            }

            public int contarlikes(int idpost)
            {
                restclient client = new restclient("https://localhost:44358/");
                restrequest request = new restrequest($"api/post/contarlikes/{idpost}", method.get);
                var response = client.execute(request);

                if (!response.issuccessful)
                    throw new exception("error al contar los likes.");

                var result = jsonconvert.deserializeobject<dictionary<string, int>>(response.content);
                return result.containskey("cantidad") ? result["cantidad"] : 0;
            }
            public int contarcomentarios(int idpost)
            {
                restclient client = new restclient("https://localhost:44358/");
                restrequest request = new restrequest($"api/post/contarcomentarios/{idpost}", method.get);
                var response = client.execute(request);

                if (!response.issuccessful)
                    throw new exception("error al contar los comentarios.");

                var result = jsonconvert.deserializeobject<dictionary<string, int>>(response.content);
                return result.containskey("cantidad") ? result["cantidad"] : 0;
            }
    */