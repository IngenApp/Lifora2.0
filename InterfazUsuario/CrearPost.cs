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
    public partial class CrearPost : Form
    {
        
        public CrearPost()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CrearPostTexto texto = new CrearPostTexto();
            texto.Show();
            texto.crearPost = this;
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CrearPostImagen imagen = new CrearPostImagen();
            imagen.Show();
            imagen.crearPost = this;
            this.Hide();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            CrearPostVideo video = new CrearPostVideo();
            video.Show();
            video.crearPost = this;
            this.Hide();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            CrearPostAudio video = new CrearPostAudio();
            video.Show();
            video.crearPost = this;
            this.Hide();
        }
    }
}
