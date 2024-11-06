using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;
using InterfazUsuario.Lenguas;
using InterfazUsuario.Properties;

namespace InterfazUsuario
{
    public partial class Eventos : Form
    {

        public Eventos(int idEvento, string nombreEvento, string lugarEvento, string infoEvento, string fechaEvento, string idFotoEvento)
        {
            InitializeComponent();
            CargarIdioma();
            labelNombreEvento.Text = nombreEvento;
            txtLugarEvento.Text = lugarEvento;
            txtInfoEvento.Text = infoEvento;
            txtFechaEvento.Text = fechaEvento;
            fotoEvento.Image = Image.FromFile(idFotoEvento);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // sigo evento
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            // dejo de seguir evento

        }

        private void fotoEvento_Click(object sender, EventArgs e)
        {
            PostImagenAmpliar imagenForm = new PostImagenAmpliar(fotoEvento.Image);
            imagenForm.ShowDialog();
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
    }
}