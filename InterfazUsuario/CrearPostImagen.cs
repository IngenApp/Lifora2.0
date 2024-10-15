using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InterfazUsuario
{
    public partial class CrearPostImagen : Form
    {
        public Form crearPost;


        public CrearPostImagen()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Filtrar para mostrar solo archivos de imagen
            openFileDialog.Filter = "Archivos de imagen (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
            openFileDialog.Title = "Selecciona una imagen";

            // Mostrar el diálogo y verificar si el usuario selecciona un archivo
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Obtener la ruta del archivo de imagen seleccionado
                string rutaImagen = openFileDialog.FileName;

                // Ejemplo: mostrar la imagen en un PictureBox
                pictureBox1.Image = new Bitmap(rutaImagen);
            }
        }

        private void CrearPostImagen_FormClosing(object sender, FormClosingEventArgs e)
        {
            crearPost.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // api crear post imagen
            this.Close();
            crearPost.Close();

        }
    }
}
