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
using ApiGrupo.Models;
using RestSharp;
using Newtonsoft.Json;

namespace InterfazUsuario
{
    public partial class GruposMenu : Form
    {
        private GestorDePosts gestorDePosts;
        public static GruposMenu menuGruposInstancia = null;
        public GruposMenu()
        {
            InitializeComponent();
            MakeCircularPictureBox(pictureBox1);
            CargarIdioma();
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AbrirCrearGrupo();
        }
        private void AbrirCrearGrupo()
        {
            if (CrearGrupo.grupoInstancia == null || CrearGrupo.grupoInstancia.IsDisposed)
            {
                CrearGrupo.grupoInstancia = new CrearGrupo();
                CrearGrupo.grupoInstancia.Show();
            }
            else
            {
                CrearGrupo.grupoInstancia.WindowState = FormWindowState.Normal;
                CrearGrupo.grupoInstancia.BringToFront();
            }
        }
        private void MakeCircularPictureBox(PictureBox pictureBox2)
        {
            GraphicsPath path = new GraphicsPath();

            path.AddEllipse(0, 0, pictureBox2.Width, pictureBox2.Height);

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

        private void btnGrupo_Click(object sender, EventArgs e)
        {
            Grupos grupos = new Grupos();
            grupos.Show();
        }
        public List<ModeloApiGrupo> ListarGrupos()
        {
            RestClient client = new RestClient("https://localhost:44325/");
            RestRequest request = new RestRequest("api/Grupo/ListarGrupos", Method.Get);
            request.AddHeader("Accept", "application/json");
            RestResponse response = client.Execute(request);

            if (!response.IsSuccessful)
            {
                throw new Exception("Error al listar los grupos: " + response.ErrorMessage);
            }
            var grupos = JsonConvert.DeserializeObject<List<ModeloApiGrupo>>(response.Content);

            return grupos ?? new List<ModeloApiGrupo>();
        }
        private void btnTodosGrupos_Click(object sender, EventArgs e)
        {
            List<ModeloApiGrupo> listaDeGrupos = new List<ModeloApiGrupo>();
            List<String> nombre = new List<string>();
            List<string> descripcion = new List<string>();
            List<string> idGrupo = new List<string>();
            List<string> apodo = new List<string>();
            List<string> cantidadLikes = new List<string>();
            List<string> cantidadComentarios = new List<string>();
            List<String> fecha = new List<string>();
            foreach (var grupos in listaDeGrupos)
            {
                nombre.Add(grupos.Nombre);
                descripcion.Add(grupos.Informacion);

            }
            gestorDePosts.PostTexto(apodo, descripcion, cantidadLikes, cantidadComentarios, fecha);


        }

        private void btnMisGrupos_Click(object sender, EventArgs e)
        {

        }
    }
}
