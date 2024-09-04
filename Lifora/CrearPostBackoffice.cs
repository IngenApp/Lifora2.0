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
    public partial class CrearPostBackoffice : Form
    {
        public CrearPostBackoffice()
        {
            InitializeComponent();
        }

        private void btnCrearPost_Click(object sender, EventArgs e)
        {
            if (textBoxIdUsuario.Text == "" || textBoxPostear.Text == "" || textBoxFecha.Text == "")
            {
                MessageBox.Show("Debe completar todos los campos");
            }
            else
            {
                ControladorPost.CrearPost(Int32.Parse(textBoxIdUsuario.Text), textBoxPostear.Text, textBoxFecha.Text);
                MessageBox.Show("Post creado con exito");
                textBoxIdUsuario.Text = "";
                textBoxPostear.Text = "";
                textBoxFecha.Text = "";
            }
        }
    }
}
