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
using Newtonsoft.Json;
using RestSharp;

namespace InterfazUsuario
{
    public partial class Grupos : Form
    {
        public Grupos()
        {
            InitializeComponent();
            CargarIdioma();
            richTextBox1.SelectionChanged += (s, e) => richTextBox1.SelectionLength = 0;
            MakeCircularPictureBox(pictureBox2);
            MakeCircularPictureBox(pictureBox1);

            
        }

       
        private void MakeCircularPictureBox(PictureBox pictureBox2)
        {
            GraphicsPath path = new GraphicsPath();

            path.AddEllipse(0, 0, pictureBox2.Width, pictureBox2.Height);

            pictureBox2.Region = new Region(path);
        }

        private void btnCreatePost_Click(object sender, System.EventArgs e)
        {
            // crear post en el Grupo
            AbrirPost();
            
        }
        private void AbrirPost()
        {
            if (CrearPost.PostInstancia == null || CrearPost.PostInstancia.IsDisposed)
            {
                CrearPost.PostInstancia = new CrearPost();
                CrearPost.PostInstancia.Show();
            }
            else
            {
                CrearPost.PostInstancia.WindowState = FormWindowState.Normal;
                CrearPost.PostInstancia.BringToFront();
            }
        }
        public string UnirseAGrupo(int idGrupo, int idPerfil, bool silenciar)
        {
            RestClient client = new RestClient("https://localhost:44325/");
            RestRequest request = new RestRequest("api/Grupo/UnirseAGrupo", Method.Post);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");

            var unirseGrupo = new
            {
                idGrupo = idGrupo,
                idPerfil = idPerfil,
                silenciar = silenciar
            };
            request.AddJsonBody(unirseGrupo);

            RestResponse response = client.Execute(request);

            if (!response.IsSuccessful)
            {
                throw new Exception("Error al unirse al grupo: " + response.ErrorMessage);
            }

            var result = JsonConvert.DeserializeObject<Dictionary<string, string>>(response.Content);
            return result.ContainsKey("mensaje") ? result["mensaje"] : "Error desconocido";
        }
        // UnirseAGrupo(int idGrupo, DatosDePerfil.idPerfil, silenciar);
        private void btnSeguir_Click(object sender, System.EventArgs e)
        {
            //Seguir grupo
           
        }

        private void btnDejarSeguir_Click(object sender, System.EventArgs e)
        {
            //Dejar de seguir grupo
        }

        private void btnWriting_Click(object sender, System.EventArgs e)
        {
            //mostrar post texto
        }

        private void btnPhotos_Click(object sender, System.EventArgs e)
        {
            // mostrar post imagen

        }

        private void btnVideo_Click(object sender, System.EventArgs e)
        {
            // mostrar post video
        }

        private void btnMusic_Click(object sender, System.EventArgs e)
        {
            //mostrar post audio
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

        private void btnMessages_Click(object sender, EventArgs e)
        {
            AbrirMensajes();
        }
        private void AbrirMensajes()
        {
            if (Mensajes.MensajeInstancia == null || Mensajes.MensajeInstancia.IsDisposed)
            {
                Mensajes.MensajeInstancia = new Mensajes();
                Mensajes.MensajeInstancia.Show();
            }
            else
            {
                Mensajes.MensajeInstancia.WindowState = FormWindowState.Normal;
                Mensajes.MensajeInstancia.BringToFront();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Report_Click(object sender, EventArgs e)
        {
            Reportar reportar = new Reportar();
            //reportar.NombreGrupo= NombreGrupo;
            reportar.Show();
        }

        private void Grupos_Load(object sender, EventArgs e)
        {
           
        }
    }
}
