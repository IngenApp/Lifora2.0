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
    public partial class PerfilPrincipal : Form
    {
        public Form inicio;
        string rutaImagen;
        public PerfilPrincipal()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            inicio.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AbrirPost();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            // cambiar foto de perfil
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //cantidad de gente que me sigo
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // cantidad de gente que sigo
        }

        private void PerfilPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            inicio.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            InformacionUsuario info = new InformacionUsuario();
            info.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AbrirMensajes();
        }
        private void AbrirMensajes()
        {
            if (Mensajes.MensajeInstancia == null || Mensajes.MensajeInstancia.IsDisposed)
            {
                Mensajes.MensajeInstancia = new Mensajes();
                Mensajes.MensajeInstancia.Show();
            }
            else
            {
                Mensajes.MensajeInstancia.WindowState = FormWindowState.Normal;
                Mensajes.MensajeInstancia.BringToFront();
            }
        }
        private void AbrirPost()
        {
            if (CrearPost.PostInstancia == null || CrearPost.PostInstancia.IsDisposed)
            {
                CrearPost.PostInstancia = new CrearPost();
                CrearPost.PostInstancia.Show();
            }
            else
            {
                CrearPost.PostInstancia.WindowState = FormWindowState.Normal; 
                CrearPost.PostInstancia.BringToFront();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AbrirEvento();
        }
        private void AbrirEvento()
        {
            if (CrearEvento.eventoInstancia == null || CrearEvento.eventoInstancia.IsDisposed)
            {
                CrearEvento.eventoInstancia = new CrearEvento();
                CrearEvento.eventoInstancia.Show();
            }
            else
            {
                CrearEvento.eventoInstancia.WindowState = FormWindowState.Normal;
                CrearEvento.eventoInstancia.BringToFront();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (GruposMenu.menuGruposInstancia == null || GruposMenu.menuGruposInstancia.IsDisposed)
            {
                GruposMenu.menuGruposInstancia = new GruposMenu();
                GruposMenu.menuGruposInstancia.Show();
            }
            else
            {
                GruposMenu.menuGruposInstancia.WindowState = FormWindowState.Normal;
                GruposMenu.menuGruposInstancia.BringToFront();
            }
        }
    }
}
