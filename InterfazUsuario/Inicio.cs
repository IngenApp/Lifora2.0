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
           
        }

        private void CargarDatosPerfil()
        {
            string email = DatosDePerfil.email; 
            Dictionary<string, string> perfil = ObtenerDatosPerfilDesdeApi(email);

            if (perfil == null)
            {
                MessageBox.Show("No se pudieron obtener los datos del perfil.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DatosDePerfil.idPerfil = int.Parse(perfil["idPerfil"]);
            DatosDePerfil.nombre = perfil["nombre"];
            DatosDePerfil.apellido = perfil["apellido"];
            DatosDePerfil.fechaNacimiento = perfil["fechaNacimiento"];
            DatosDePerfil.email = perfil["email"];
            DatosDePerfil.telefono = perfil["telefono"];
            DatosDePerfil.apodo = perfil["apodo"];
            DatosDePerfil.idFotoPerfil = string.IsNullOrEmpty(perfil["idFotoPerfil"]) ? (int?)null : int.Parse(perfil["idFotoPerfil"]);
            DatosDePerfil.idioma = perfil["idioma"];
            DatosDePerfil.atributo1 = perfil["atributo1"];
            DatosDePerfil.atributo2 = perfil["atributo2"];
            Nickname.Text = DatosDePerfil.apodo;
        }
        private Dictionary<string, string> ObtenerDatosPerfilDesdeApi(string email)
        {
            RestClient client = new RestClient("http://localhost:44331/");
            RestRequest request = new RestRequest($"/api/Usuario/{email}", Method.Get);
            request.AddHeader("Accept", "application/json");

            RestResponse response = client.Execute(request);
            return JsonConvert.DeserializeObject<Dictionary<string, string>>(response.Content);
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
            List<string> apodo = new List<string> { "Apodo1", "Apodo2", "Apodo3", "Apodo4", "Apodo5", "Apodo6" };
            List<string> descripcion = new List<string> { "post1", "post2", "post3", "post1", "post2", "post3" };
            List<string> cantidadLikes = new List<string> { "10", "15", "20", "10", "15", "20" };
            List<string> cantidadComentarios = new List<string> { "15", "20", "30", "15", "20", "30" };
            //con los post de los que sigo
            gestorDePosts.PostTexto(apodo, descripcion, cantidadLikes, cantidadComentarios);
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
