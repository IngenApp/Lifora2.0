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
    public partial class CrearPost : Form
    {
        public static CrearPost PostInstancia = null;
        public CrearPost()
        {
            InitializeComponent();
            CargarIdioma();
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

        private void button1_Click(object sender, EventArgs e)
        {
            CrearPostTexto texto = new CrearPostTexto();
            texto.Show();
            texto.crearPost = this;
            this.Hide();
        }
/*        private void CrearPostTexto(int idPerfil, string descripcion)
        {
            var client = new RestClient("https://localhost:44358/");
            var request = new RestRequest("api/Post/CrearPostTexto/", Method.Post);
            request.AddJsonBody(new { idPerfil, descripcion });

            var response = client.Execute(request);
            if (!response.IsSuccessful)
                throw new Exception("Error al crear el post de texto.");
        }
*/
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
