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
    public partial class EventosMenu : Form
    {
        public static EventosMenu eventoInstancia = null;

        public EventosMenu()
        {
            InitializeComponent();
            CargarIdioma();
            MakeCircularPictureBox(pictureBox1);

        }

        private void btnCrearEvento_Click(object sender, EventArgs e)
        {
            AbrirEventoCrear();
        }
        private void AbrirEventoCrear()
        {
            if (CrearEvento.eventoInstancia == null || CrearEvento.eventoInstancia.IsDisposed)
            {
                CrearEvento.eventoInstancia = new CrearEvento();
                CrearEvento.eventoInstancia.Show();
            }
            else
            {
                CrearEvento.eventoInstancia.WindowState = FormWindowState.Normal;
                CrearEvento.eventoInstancia.BringToFront();
            }
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
        private void MakeCircularPictureBox(PictureBox pictureBox2)
        {
            // Crear un objeto GraphicsPath para definir la forma circular
            GraphicsPath path = new GraphicsPath();

            // Añadir una elipse al path con el tamaño del PictureBox
            path.AddEllipse(0, 0, pictureBox2.Width, pictureBox2.Height);

            // Asignar la región circular al PictureBox
            pictureBox2.Region = new Region(path);
        }

        private void btnEvento_Click(object sender, EventArgs e)
        {
            // if(datagridview.Selection != null)
            // valores de ejemplo apra abrir un grupo
            int idEvento = 1;
            string nombreEvento = "Proyecto de la Utu";
            string lugarEvento = "UTU Buceo";
            string infoEvento = "proyecto relaizado por IngenApp";
            string fechaEvento = "15 noviembre 2024";
            string idFotoEvento = @"D:\IngenApp\Logo\logo.png";
            Eventos eventos = new Eventos(idEvento, nombreEvento, lugarEvento, infoEvento, fechaEvento, idFotoEvento);
            eventos.Show();
            //else(mensaje)
        }
    }
}
