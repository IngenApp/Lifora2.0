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
    public partial class CrearPostVideo : Form
    {
        public Form crearPost;
        string rutaVideo;
        public CrearPostVideo()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Crear una nueva instancia de OpenFileDialog para seleccionar el video
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Filtrar solo archivos de video
            openFileDialog.Filter = "Archivos de video (*.mp4;*.avi;*.mov;*.mkv)|*.mp4;*.avi;*.mov;*.mkv";
            openFileDialog.Title = "Selecciona un video";

            // Mostrar el cuadro de diálogo
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Obtener la ruta del archivo de video
                rutaVideo = openFileDialog.FileName;

                // Cargar y reproducir el video en el control Windows Media Player
                axWindowsMediaPlayer1.URL = rutaVideo;
                axWindowsMediaPlayer1.Ctlcontrols.play();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //api de creacion de post de video
            if (string.IsNullOrEmpty(rutaVideo))
            {
                MessageBox.Show("Seleccione un video");
            }
            else
            {
                // Cerrar el formulario actual
                this.Close();

                // Verificar si la instancia de crearPost existe y no es nula, y luego cerrarla
                if (crearPost != null && !crearPost.IsDisposed)
                {
                    crearPost.Close();
                }

                // Limpiar la ruta de la imagen seleccionada
                rutaVideo = string.Empty;
            }


        }

        private void CrearPostVideo_FormClosing(object sender, FormClosingEventArgs e)
        {
            crearPost.Show();
        }
    }
}
