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
    public partial class PostImagenMostrar : Form
    {
        public PostImagenMostrar(string apodo, string descripcion, string idImagen,  string likes, string comentarios)
        {
            InitializeComponent();
            richTextBox1.SelectionChanged += (s, e) => richTextBox1.SelectionLength = 0;
            
            linkLabel1.Text = apodo;
            pictureBox1.Image = Image.FromFile(idImagen);
            richTextBox1.Text = descripcion;
            //labelFecha.Text = fecha;
            ContLikes.Text = likes;
            contComentarios.Text = comentarios;

        }

        private void PostImagenMostrar_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //if (el eprfil es el mio, actualiza; si es distinto al mio)
            PerfilSecundario perfilSecundario = new PerfilSecundario();
            perfilSecundario.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //cantidad de likes
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //cantidad de comentarios
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //like
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //comentar
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //compartir
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            VerComentarPost comentar = new VerComentarPost();
            comentar.Show();

            // Pasarle id_post para comentar
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Deseas compartir?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Verifica la respuesta del usuario
            if (resultado == DialogResult.Yes)
            {
                // Compartir

            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Reportar reportar = new Reportar();
            //reportar.id_post = id_post;
            reportar.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PostImagenAmpliar imagenForm = new PostImagenAmpliar(pictureBox1.Image);
            imagenForm.ShowDialog();
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
