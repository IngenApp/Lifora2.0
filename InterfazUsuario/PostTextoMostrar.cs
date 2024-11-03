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
    public partial class PostTextoMostrar : Form
    {
        public PostTextoMostrar(string Apodo, string contenido, string cantidadLikes, string cantidadComentarios)
        {
            InitializeComponent();
            richTextBox1.SelectionChanged += (s, e) => richTextBox1.SelectionLength = 0;
            this.ControlBox = false;
            this.Text = "";
            labelApodo.Text = Apodo;
            

        }
     
        private void PostTextoMostrar_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PerfilSecundario perfil = new PerfilSecundario();
            perfil.Show();

            //if (el eprfil es el mio, actualiza; si es distinto al mio)
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //cantidad de likes
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            VerComentarPost comentar = new VerComentarPost();
            comentar.Show();


            // pasarle id_post al form para poder comentarlo
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
    }
}
