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
    public partial class CrearEvento : Form
    {
        public static CrearEvento eventoInstancia = null;
        string rutaImagen;

        public CrearEvento()
        {
            InitializeComponent();
            CargarIdioma();
            MakeCircularPictureBox(pictureBox2);
        }
        private void MakeCircularPictureBox(PictureBox pictureBox2)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, pictureBox2.Width, pictureBox2.Height);
            pictureBox2.Region = new Region(path);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //metodo crear evento
            this.Close();
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

        private void btnCrearEvento_Click(object sender, EventArgs e)
        {
            //Crear Evento
            if (string.IsNullOrEmpty(richTextBox1.Text) || string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
            {
                if (Settings.Default.Idioma == "es-UY")
                {
                    MessageBox.Show("Ingrese el nombre y la descripcion del evento");

                }
                if (Settings.Default.Idioma == "en-US")
                {
                    MessageBox.Show("Enter the name and description of the event");
                }
                
            }
            else
            {
                if (string.IsNullOrEmpty(rutaImagen))
                {
                    if (Settings.Default.Idioma == "es-UY")
                    {
                        MessageBox.Show("Selecciona una imagen");

                    }
                    if (Settings.Default.Idioma == "en-US")
                    {
                        MessageBox.Show("Select an image");
                    }
  
                }
                else
                {
                    //Api crear EVENTO
                    this.Close();

                }
            }

        }
    }
}
