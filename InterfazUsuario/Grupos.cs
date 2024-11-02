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
    public partial class Grupos : Form
    {
        public Grupos()
        {
            InitializeComponent();
            CargarIdioma();
            MakeCircularPictureBox(pictureBox2);
            MakeCircularPictureBox(pictureBox1);

            
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

        private void btnCreatePost_Click(object sender, System.EventArgs e)
        {
            // crear post en el Grupo
            AbrirPost();
            
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

        private void btnSeguir_Click(object sender, System.EventArgs e)
        {
            //Seguir grupo
        }

        private void btnDejarSeguir_Click(object sender, System.EventArgs e)
        {
            //Dejar de seguir grupo
        }

        private void btnWriting_Click(object sender, System.EventArgs e)
        {
            //mostrar post texto
        }

        private void btnPhotos_Click(object sender, System.EventArgs e)
        {
            // mostrar post imagen

        }

        private void btnVideo_Click(object sender, System.EventArgs e)
        {
            // mostrar post video
        }

        private void btnMusic_Click(object sender, System.EventArgs e)
        {
            //mostrar post audio
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

        private void btnMessages_Click(object sender, EventArgs e)
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
