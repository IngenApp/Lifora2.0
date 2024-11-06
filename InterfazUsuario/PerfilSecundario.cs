using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;
using InterfazUsuario.Lenguas;
using InterfazUsuario.Properties;
using System.Drawing.Drawing2D;

namespace InterfazUsuario
{
    public partial class PerfilSecundario : Form
    {
        public Form inicio;
        private GestorDePosts gestorDePosts;
        public PerfilSecundario()
        {
            InitializeComponent();
            CargarIdioma();
            MakeCircularPictureBox(pictureBox2);
            MakeCircularPictureBox(pictureBox1);
            gestorDePosts = new GestorDePosts(panel1, panel2, panel3, panel4);

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
        private void MakeCircularPictureBox(PictureBox pictureBox2)
        {
            // Crear un objeto GraphicsPath para definir la forma circular
            GraphicsPath path = new GraphicsPath();

            // Añadir una elipse al path con el tamaño del PictureBox
            path.AddEllipse(0, 0, pictureBox2.Width, pictureBox2.Height);

            // Asignar la región circular al PictureBox
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {      
                this.Close();
        }


        private void Information_Click(object sender, EventArgs e)
        {
            InformacionUsuario info = new InformacionUsuario();
            info.Show();
        }

        private void MuroTextos(object sender, EventArgs e)
        {
            panel2.Hide();
            panel1.Show();
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

        private void btnMessages_Click(object sender, EventArgs e)
        {
            //Obtener ID para abrir chat con ese usuario
            AbrirMensajes();
        }

        private void Report_Click(object sender, EventArgs e)
        {
            Reportar reportar = new Reportar();
            //reportar.Apodo = Apodo;
            reportar.Show();
        }

        private void PerfilSecundario_Load(object sender, EventArgs e)
        {
            MuroTextos(this, EventArgs.Empty);
            ReproductorPublicidad.URL = @"C:\Users\stive\OneDrive\Escritorio\MEGUSTA.mp4";
            ReproductorPublicidad.uiMode = "none";
            ReproductorPublicidad.settings.mute = true;
        }

        private void btnSeguidores_Click(object sender, EventArgs e)
        {

        }

        private void btnSeguidos_Click(object sender, EventArgs e)
        {

        }
    }
}
