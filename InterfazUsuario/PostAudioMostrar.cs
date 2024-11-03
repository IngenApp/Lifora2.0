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
    public partial class PostAudioMostrar : Form
    {
        public PostAudioMostrar(string Apodo)
        {
            InitializeComponent();
            richTextBox1.SelectionChanged += (s, e) => richTextBox1.SelectionLength = 0;
            this.ControlBox = false;
            this.Text = "";
            linkLabel1.Text = Apodo;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //if (el eprfil es el mio, actualiza; si es distinto al mio)
            PerfilSecundario perfilSecundario = new PerfilSecundario();
            perfilSecundario.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            VerComentarPost comentar = new VerComentarPost();
            comentar.Show();

            // Pasarle id_post para comentar
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Deseas compartir?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Verifica la respuesta del usuario
            if (resultado == DialogResult.Yes)
            {
                // Compartir
                
            }
            
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
    }
}
