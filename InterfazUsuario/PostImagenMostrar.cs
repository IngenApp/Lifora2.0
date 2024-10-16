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
            //if (el eprfil es el mio, nada; si es distinto al mio)
            PerfilSecundario perfilSecundario = new PerfilSecundario();
            perfilSecundario.Show();
        }
    }
}
