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
    public partial class CrearEvento : Form
    {
        public static CrearEvento eventoInstancia = null;
        string rutaImagen;

        public CrearEvento()
        {
            InitializeComponent();
            CargarIdioma();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //metodo crear evento
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Archivos de imagen (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
            openFileDialog.Title = "Selecciona una imagen";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                rutaImagen = openFileDialog.FileName;
               
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos de imagen (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
            openFileDialog.Title = "Selecciona una imagen";

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
                MessageBox.Show("Ingrese lo que desea el nombre y la descripcion del Evento");
            }
            else
            {
                if (string.IsNullOrEmpty(rutaImagen))
                {
                    MessageBox.Show("Selecciona una imagen");
                }
                else
                {
                    //Api crear Post Audio
                    this.Close();

                }
            }

        }
    }
}
