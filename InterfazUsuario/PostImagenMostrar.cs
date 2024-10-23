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
        public PostImagenMostrar(string Apodo)
        {
            InitializeComponent();
            this.ControlBox = false;
            this.Text = "";
            linkLabel1.Text = Apodo;
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
    }
}
