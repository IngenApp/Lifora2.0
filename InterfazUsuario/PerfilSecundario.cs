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
        public PerfilSecundario()
        {
            InitializeComponent();
            CargarIdioma();
            MakeCircularPictureBox(pictureBox2);
            MakeCircularPictureBox(pictureBox1);

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
        private void AgregarPostTexto(Form PostTextoMostrar)
        {
            PostTextoMostrar.TopLevel = false;
            PostTextoMostrar.Dock = DockStyle.Top;

            panel1.Controls.Add(PostTextoMostrar);
            panel1.Tag = PostTextoMostrar;
            PostTextoMostrar.Show();
        }

        private void btnWriting_Click(object sender, EventArgs e)
        {
            panel2.Hide();
            panel1.Show();
            panel3.Hide();
            panel4.Hide();
            //con los post del PERFIL
            List<String> Apodo = new List<string> { "Apodo", "Apodo", "Apodo" };
            List<String> contenido = new List<string> { "post1", "post2", "post3" };
            List<String> cantidadLikes = new List<string> { "10", "15", "20" };
            List<String> cantidadComentarios = new List<string> { "15", "20", "30" };
            for (int i = 0; i < Apodo.Count; i++)
            {
                PostTextoMostrar form = new PostTextoMostrar(Apodo[i], contenido[i], cantidadLikes[i], cantidadComentarios[i]);
                AgregarPostTexto(form);

            }
        }
        private void AgregarPostImagen(Form PostImagenMostrar)
        {
            PostImagenMostrar.TopLevel = false;
            PostImagenMostrar.Dock = DockStyle.None;

            int count = panel2.Controls.Count;
            int x = (count % 2) * PostImagenMostrar.Width;
            int y = (count / 2) * PostImagenMostrar.Height;

            PostImagenMostrar.Location = new Point(x, y);
            panel2.Controls.Add(PostImagenMostrar);
            panel2.Tag = PostImagenMostrar;

            PostImagenMostrar.Show();
        }

        private void btnPhotos_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            panel2.Show();
            panel3.Hide();
            panel4.Hide();
            //post del perfil
            List<String> Apodo = new List<string> { "Apodo", "Apodo", "Apodo", "Apodo" };
            List<String> idImagen = new List<string> { @"D:\Azir Cosp\1.jpg", @"D:\Azir Cosp\3.jpg", @"D:\Azir Cosp\6.jpg", @"D:\Azir Cosp\7.jpg", @"D:\Azir Cosp\8.jpg", @"D:\Azir Cosp\11.jpg", @"D:\Azir Cosp\9.jpg", @"D:\Azir Cosp\1.jpg12" };

            panel2.Controls.Clear();

            for (int i = 0; i < Apodo.Count; i++)
            {
                PostImagenMostrar form = new PostImagenMostrar(Apodo[i], idImagen[i]);
                AgregarPostImagen(form);
            }
        }
        private void AgregarPostVideo(Form PostVideoMostrar)
        {
            PostVideoMostrar.TopLevel = false;
            PostVideoMostrar.Dock = DockStyle.None;

            int count = panel3.Controls.Count;
            int x = (count % 2) * PostVideoMostrar.Width;
            int y = (count / 2) * PostVideoMostrar.Height;

            PostVideoMostrar.Location = new Point(x, y);
            panel3.Controls.Add(PostVideoMostrar);
            panel3.Tag = PostVideoMostrar;

            PostVideoMostrar.Show();
        }

        private void btnVideo_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            panel2.Hide();
            panel3.Show();
            panel4.Hide();
            List<String> Apodo = new List<string> { "Apodo", "Apodo", "Apodo", "Apodo" };
            panel3.Controls.Clear();

            for (int i = 0; i < Apodo.Count; i++)
            {
                PostVideoMostrar form = new PostVideoMostrar(Apodo[i]);
                AgregarPostVideo(form);
            }
        }
        private void AgregarPostAudio(Form PostAudioMostrar)
        {
            PostAudioMostrar.TopLevel = false;
            PostAudioMostrar.Dock = DockStyle.None;

            int count = panel4.Controls.Count;
            int x = (count % 2) * PostAudioMostrar.Width;
            int y = (count / 2) * PostAudioMostrar.Height;

            PostAudioMostrar.Location = new Point(x, y);
            panel4.Controls.Add(PostAudioMostrar);
            panel4.Tag = PostAudioMostrar;

            PostAudioMostrar.Show();
        }

        private void btnMusic_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            panel2.Hide();
            panel3.Hide();
            panel4.Show();
            List<String> Apodo = new List<string> { "Apodo1", "Apodo2", "Apodo3", "Apodo4" };
            List<string> idAudios = new List<string> { @"C:\Users\stive\OneDrive\Escritorio\Silent Hill Original Soundtrack\01 - Silent Hill.mp3", @"C:\Users\stive\OneDrive\Escritorio\Silent Hill Original Soundtrack\02 - All.mp3", @"C:\Users\stive\OneDrive\Escritorio\Silent Hill Original Soundtrack\03 - The Wait.mp3", @"DC:\Users\stive\OneDrive\Escritorio\Silent Hill Original Soundtrack\04 - Until Death.mp3" };

            panel4.Controls.Clear();

            for (int i = 0; i < Apodo.Count; i++)
            {
                PostAudioMostrar form = new PostAudioMostrar(Apodo[i],idAudios[i]);
                AgregarPostAudio(form);
            }
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
    }
}
