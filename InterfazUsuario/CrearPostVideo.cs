using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;
using InterfazUsuario.Lenguas;
using InterfazUsuario.Properties;

namespace InterfazUsuario
{
    public partial class CrearPostVideo : Form
    {
        public Form crearPost;
        string rutaVideo;
        public CrearPostVideo()
        {
            InitializeComponent();
            CargarIdioma();
            MakeCircularPictureBox(pictureBox2);
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(richTextBox1.Text))
            {
                MessageBox.Show("Ingrese lo que desea compartir");
            }
            else
            {
                if (string.IsNullOrEmpty(rutaVideo))
                {
                    MessageBox.Show("Selecciona un Audio");
                }
                else
                {
                    //Api crear Post Video
                    this.Close();

                    if (crearPost != null && !crearPost.IsDisposed)
                    {
                        crearPost.Close();
                    }
                    rutaVideo = string.Empty;
                    richTextBox1.Text = string.Empty;
                }
            }
        }

        private void CrearPostVideo_FormClosing(object sender, FormClosingEventArgs e)
        {
            crearPost.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Archivos de video (*.mp4;*.avi;*.mov;*.mkv)|*.mp4;*.avi;*.mov;*.mkv";
            openFileDialog.Title = "Selecciona un video";


            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {

                rutaVideo = openFileDialog.FileName;

                axWindowsMediaPlayer1.URL = rutaVideo;
                axWindowsMediaPlayer1.Ctlcontrols.play();
            }
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
    }
}
