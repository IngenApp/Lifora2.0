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
    public partial class PostVideoMostrar : Form
    {
        public string videoPath;
        public PostVideoMostrar(string apodo, string descripcion, string idVideo, string likes, string comentarios)
        {
            InitializeComponent();
            richTextBox1.SelectionChanged += (s, e) => richTextBox1.SelectionLength = 0;

            axWindowsMediaPlayer1.URL = idVideo;
            NickName.Text = apodo;
            richTextBox1.Text = descripcion;
            //labelFecha.Text = fecha;
            ContLikes.Text = likes.ToString();
            contComentarios.Text = comentarios.ToString();

            videoPath = idVideo;


            this.ControlBox = false;
            this.Text = "";
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //if (el eprfil es el mio, actualiza; si es distinto al mio)
            PerfilSecundario perfilSecundario = new PerfilSecundario();
            perfilSecundario.Show();
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            VerComentarPost comentar = new VerComentarPost();
            comentar.Show();
            // Pasarle id_post para comentar
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            // darle like
        }

        private void Report_Click(object sender, EventArgs e)
        {
            Reportar reportar = new Reportar();
            //reportar.id_post = id_post;
            reportar.Show();
        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {

        }

        private void axWindowsMediaPlayer1_DoubleClickEvent(object sender, AxWMPLib._WMPOCXEvents_DoubleClickEvent e)
        {
            PostVideoAmpliar fullscreenForm = new PostVideoAmpliar(videoPath);
            fullscreenForm.Show();
            axWindowsMediaPlayer1.Ctlcontrols.pause();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (EditarPost.eventoInstancia == null || EditarPost.eventoInstancia.IsDisposed)
            {
                EditarPost.eventoInstancia = new EditarPost();
                EditarPost.eventoInstancia.Show();
            }
            else
            {
                EditarPost.eventoInstancia.Close();
                EditarPost.eventoInstancia = new EditarPost();
                EditarPost.eventoInstancia.Show();
            }
        }
    }
}