using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;
using InterfazUsuario.Lenguas;
using InterfazUsuario.Properties;
using System.Drawing.Drawing2D;

namespace InterfazUsuario
{
    public partial class PerfilSecundario : Form
    {
        public Form inicio;
        public PerfilSecundario()
        {
            InitializeComponent();
            CargarIdioma();
            MakeCircularPictureBox(pictureBox2);
            MakeCircularPictureBox(pictureBox1);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
        private void MakeCircularPictureBox(PictureBox pictureBox2)
        {
            // Crear un objeto GraphicsPath para definir la forma circular
            GraphicsPath path = new GraphicsPath();

            // Añadir una elipse al path con el tamaño del PictureBox
            path.AddEllipse(0, 0, pictureBox2.Width, pictureBox2.Height);

            // Asignar la región circular al PictureBox
            pictureBox2.Region = new Region(path);
        }
        public void CargarIdioma()
        {
            try
            {
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Settings.Default.Idioma);

                Idioma.CambiarTexto(this.Controls);
            }
            catch (CultureNotFoundException)
            {
                Console.WriteLine("El idioma seleccionado no es válido. Por favor, selecciona otro.");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
                inicio.Show();
                this.Close();
            
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            InformacionUsuario info = new InformacionUsuario();
            info.Show();
        }
    }
}
