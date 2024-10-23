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
            this.ControlBox = false;
            this.Text = "";
            linkLabel4.Text = Apodo;
            label1.Text = contenido;
            linkLabel1.Text = cantidadLikes;
            linkLabel2.Text = cantidadComentarios;

        }
     
        private void PostTextoMostrar_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //if (el eprfil es el mio, actualiza; si es distinto al mio)
            PerfilSecundario perfilSecundario = new PerfilSecundario();
            perfilSecundario.Show();
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
    }
}
