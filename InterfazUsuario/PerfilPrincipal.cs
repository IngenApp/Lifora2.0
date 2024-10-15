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
        public PerfilPrincipal()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Inicio inicio=new Inicio();
            inicio.Show();
            this.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CrearPost post = new CrearPost();
            post.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //actualizar el muro
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
    }
}
