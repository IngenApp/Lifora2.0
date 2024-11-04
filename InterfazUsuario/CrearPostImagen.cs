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
    public partial class CrearPostImagen : Form
    {
        public Form crearPost;
        string rutaImagen;


        public CrearPostImagen()
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
        private void CrearPostImagen_FormClosing(object sender, FormClosingEventArgs e)
        {
            crearPost.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(richTextBox1.Text) )
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
                if (string.IsNullOrEmpty(rutaImagen))
                {
                    if (Settings.Default.Idioma == "es-UY")
                    {
                        MessageBox.Show("Selecciona una Imagen");

                    }
                    if (Settings.Default.Idioma == "en-US")
                    {
                        MessageBox.Show("Select an image");
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
                    rutaImagen = string.Empty;
                    richTextBox1.Text = string.Empty;
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Archivos de imagen (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
            if (Settings.Default.Idioma == "es-UY")
            {
                openFileDialog.Title = "Selecciona una imagen";

            }
            if (Settings.Default.Idioma == "en-US")
            {
                openFileDialog.Title = "Select an image";
            }

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                rutaImagen = openFileDialog.FileName;
                pictureBox1.Image = new Bitmap(rutaImagen);
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

