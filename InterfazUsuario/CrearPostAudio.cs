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
    public partial class CrearPostAudio : Form
    {
        public Form crearPost;
        string rutaAudio;
        public CrearPostAudio()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(richTextBox1.Text))
            {
                MessageBox.Show("Ingrese lo que desea compartir");
            }
            else
            {
                if (string.IsNullOrEmpty(rutaAudio))
                {
                    MessageBox.Show("Selecciona un Audio");
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
            openFileDialog.Title = "Selecciona un archivo de audio";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {

                rutaAudio = openFileDialog.FileName;

                axWindowsMediaPlayer1.URL = rutaAudio;
                axWindowsMediaPlayer1.Ctlcontrols.play();
            }
        }
    }
}

