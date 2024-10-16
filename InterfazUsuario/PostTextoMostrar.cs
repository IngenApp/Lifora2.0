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
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void PostTextoMostrar_Load(object sender, EventArgs e)
        {

        }
    }
}
