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
    public partial class Inicio : Form
    {
        public Form Login;
        public string email;


        public Inicio()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            PerfilPrincipal perfil = new PerfilPrincipal();
            perfil.Show();
            perfil.inicio = this;
            this.Hide();
      
        }

        private void Inicio_FormClosing(object sender, FormClosingEventArgs e)
        {
            Login.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CrearPost post = new CrearPost();
            post.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // actualizar muro
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PerfilPrincipal perfil = new PerfilPrincipal();
            perfil.Show();
            perfil.inicio = this;
            this.Hide();
        }
    }
}
