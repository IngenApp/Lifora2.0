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
    public partial class CrearPostAudio : Form
    {
        public Form crearPost;
        string rutaAudio;
        public CrearPostAudio()
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
                if (Settings.Default.Idioma == "es-UY")
                {
                    MessageBox.Show("Ingrese lo que desea compartir");

                }
                if (Settings.Default.Idioma == "en-US")
                {
                    MessageBox.Show("Enter what you want to share");
                }
            }
            else
            {
                if (string.IsNullOrEmpty(rutaAudio))
                {
                    if (Settings.Default.Idioma == "es-UY")
                    {
                        MessageBox.Show("Selecciona un audio");

                    }
                    if (Settings.Default.Idioma == "en-US")
                    {
                        MessageBox.Show("Select a audio");
                    }
                }
                else
                {
                    //Api crear Post Audio
                    this.Close();

                    if (crearPost != null && !crearPost.IsDisposed)
                    {
                        crearPost.Close();
                    }
                    rutaAudio = string.Empty;
                    richTextBox1.Text = string.Empty;
                }
            }
        }

        private void CrearPostAudio_FormClosing(object sender, FormClosingEventArgs e)
        {
            crearPost.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Archivos de audio (*.mp3;*.wav;*.wma)|*.mp3;*.wav;*.wma";

            if(Settings.Default.Idioma == "es-UY")
            {
                openFileDialog.Title = "Selecciona un audio";

            }
            if (Settings.Default.Idioma == "en-US")
            {
                openFileDialog.Title = "Select a audio";
            }

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {

                rutaAudio = openFileDialog.FileName;

                axWindowsMediaPlayer1.URL = rutaAudio;
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

