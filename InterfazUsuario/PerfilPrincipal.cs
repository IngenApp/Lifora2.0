using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;
using InterfazUsuario.Properties;
using System.Drawing.Drawing2D;

namespace InterfazUsuario
{
    public partial class PerfilPrincipal : Form
    {
        public Form inicio;
        string rutaImagen;
        private GestorDePosts gestorDePosts;


        public PerfilPrincipal()
        {
            InitializeComponent();
            CargarIdioma();
            gestorDePosts = new GestorDePosts(panel1, panel2, panel3, panel4);
            MakeCircularPictureBox(pictureBox2);
            MakeCircularPictureBox(pictureBox1);
            Nickname.Text = DatosDePerfil.apodo;
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
        private void MakeCircularPictureBox(PictureBox pictureBox2)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, pictureBox2.Width, pictureBox2.Height);
            pictureBox2.Region = new Region(path);
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            inicio.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AbrirPost();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                rutaImagen = openFileDialog.FileName;
                DialogResult result = MessageBox.Show("Esta seguro que desea cambiar su foto de perfil?", "Confirmar?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {

                    MessageBox.Show("Imagen confirmada: " + rutaImagen);
                    //guardar foto perfil
                }
                else
                {
                    MessageBox.Show("Selección cancelada.");
                }

            }
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
        }

        private void PerfilPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            inicio.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            InformacionUsuario info = new InformacionUsuario();
            info.Show();
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

        private void button3_Click(object sender, EventArgs e)
        {
            AbrirEventoMenu();
        }
        private void AbrirEventoMenu()
        {
            if(EventosMenu.eventoInstancia == null || EventosMenu.eventoInstancia.IsDisposed)
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
    
        private void MuroTextos(object sender, EventArgs e)
        {
            panel1.Show();
            panel2.Hide();
            panel3.Hide();
            panel4.Hide();
            List<string> apodo = new List<string> { "Apodo1", "Apodo2", "Apodo3", "Apodo4", "Apodo5", "Apodo6" };
            List<string> descripcion = new List<string> { "post1", "post2", "post3", "post1", "post2", "post3" };
            List<string> cantidadLikes = new List<string> { "10", "15", "20", "10", "15", "20" };
            List<string> cantidadComentarios = new List<string> { "15", "20", "30", "15", "20", "30" };
            List<string> fecha = new List<string>();
            //con los post de los que sigo
            gestorDePosts.PostTexto(apodo, descripcion, cantidadLikes, cantidadComentarios, fecha);
        }
   

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Apodo Actualizar
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
            List<string> idVideo = new List<string> { @"C:\Users\stive\OneDrive\Escritorio\ME GUSTA EL ARTE - Cancion.mp4", @"D:\Azir Cosp\Azir.mp4", @"C:\Users\stive\OneDrive\Escritorio\ME GUSTA EL ARTE - Cancion.mp4", @"D:\Azir Cosp\Azir.mp4" };
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
            List<string> idAudios = new List<string> { @"C:\Users\stive\OneDrive\Escritorio\Silent Hill Original Soundtrack\01 - Silent Hill.mp3", @"C:\Users\stive\OneDrive\Escritorio\Silent Hill Original Soundtrack\02 - All.mp3", @"C:\Users\stive\OneDrive\Escritorio\Silent Hill Original Soundtrack\03 - The Wait.mp3", @"C:\Users\stive\OneDrive\Escritorio\Silent Hill Original Soundtrack\04 - Until Death.mp3" };
            List<string> cantidadLikes = new List<string> { "10", "15", "20", "10", "15", "20" };
            List<string> cantidadComentarios = new List<string> { "15", "20", "30", "15", "20", "30" };
            gestorDePosts.CargarAudios(apodos, descripcion, idAudios, cantidadLikes, cantidadComentarios);
        }

       

        private void PerfilPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Settings.Default.Save();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void PerfilPrincipal_Load(object sender, EventArgs e)
        {
            MuroTextos(this, EventArgs.Empty);
            ReproductorPublicidad.URL = @"C:\Users\stive\OneDrive\Escritorio\MEGUSTA.mp4";
            ReproductorPublicidad.uiMode = "none";
            ReproductorPublicidad.settings.mute = true;
        }

        private void btnSeguidos_Click(object sender, EventArgs e)
        {
        }

        private void btnSeguidores_Click(object sender, EventArgs e)
        {
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
