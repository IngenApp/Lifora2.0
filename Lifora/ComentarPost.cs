using Controladores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lifora
{
    public partial class ComentarPost : Form
    {
        public ComentarPost()
        {
            InitializeComponent();
        }
        private void btnComentarPost_Click(object sender, EventArgs e)
        {
            if (textBoxComentarPost.Text != "" || textBoxIdPost.Text != "" || textBoxIdCuenta.Text != "")
            {
                ControladorPost.ComentarPost(Int32.Parse(textBoxIdPost.Text), Int32.Parse(textBoxIdCuenta.Text), textBoxComentarPost.Text);
                MessageBox.Show("Comentario creado con exito");
                textBoxIdPost.Text = "";
                textBoxIdCuenta.Text = "";
                textBoxComentarPost.Text = "";
                return;
            }
            MessageBox.Show("Debe completar todos los campos");
        }
    }
}

