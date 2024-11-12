using Newtonsoft.Json;
using RestSharp;
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
            lblLikes.Text = cantidadLikes;
            lblComentarios.Text = cantidadComentarios;
        }   
        private void PostTextoMostrar_Load(object sender, EventArgs e)
        {

        }
        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PerfilSecundario perfil = new PerfilSecundario();
            perfil.Show();
            //if (el eprfil es el mio, actualiza; si es distinto al mio, abre)
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
