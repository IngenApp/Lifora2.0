using ApiPost.Models;
using Newtonsoft.Json;
using RestSharp;
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
    public partial class PostTextoMostrar : Form
    {
        public PostTextoMostrar(string Apodo, string contenido, string cantidadLikes, string cantidadComentarios)
        {
            InitializeComponent();
            richTextBox1.SelectionChanged += (s, e) => richTextBox1.SelectionLength = 0;
            this.ControlBox = false;
            this.Text = "";
            labelApodo.Text = Apodo;
            lblLikes.Text = cantidadLikes;
            lblComentarios.Text = cantidadComentarios;
            

        }
     
        private void PostTextoMostrar_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PerfilSecundario perfil = new PerfilSecundario();
            perfil.Show();

            ObtenerPostTexto(DatosDePerfil.idPerfil);
            //if (el eprfil es el mio, actualiza; si es distinto al mio, abre)

        }
        private static List<ModeloApiPost> ObtenerPostTexto(int idPerfil)
        {
            RestClient client = new RestClient("https://localhost:44358/");
            RestRequest request = new RestRequest($"api/Post/ObtenerTexto/{idPerfil}", Method.Get);
            request.AddHeader("Accept", "application/json");
            RestResponse response = client.Execute(request);
            List<ModeloApiPost> posts;
            posts = JsonConvert.DeserializeObject<List<ModeloApiPost>>(response.Content);

            return posts;
        }
        /*2*/
       
        private static DataTable generarDataTable(List<ModeloApiPost> posts)
        {
            DataTable tabla = new DataTable();
            tabla.Columns.Add("idPerfil", typeof(int));
            tabla.Columns.Add("descripcion", typeof(string));

            foreach (ModeloApiPost p in posts)
            {
                DataRow fila = tabla.NewRow();
                fila["idPerfil"] = p.idPerfil;
                fila["descripcion"] = p.descripcion;
                tabla.Rows.Add(fila);
            }

            return tabla;
        }
        /*3*/
        private void listar()
        {
            List<ModeloApiPost> posts = ObtenerPostTexto(DatosDePerfil.idPerfil);
            DataTable tabla = generarDataTable(posts);
            richTextBox1.Text = DataTableToString(tabla);
        }
        private string DataTableToString(DataTable tabla)
        {
            StringBuilder sb = new StringBuilder();

            foreach (DataColumn columna in tabla.Columns)
            {
                sb.Append(columna.ColumnName + "\t");
            }
            sb.AppendLine();

            foreach (DataRow fila in tabla.Rows)
            {
                foreach (var item in fila.ItemArray)
                {
                    sb.Append(item.ToString() + "\t");
                }
                sb.AppendLine();
            }

            return sb.ToString();
        }
        public int ContarLikes(int idPost)
        {
            RestClient client = new RestClient("https://localhost:44358/");
            RestRequest request = new RestRequest($"api/Post/ContarLikes/{idPost}", Method.Get);
            var response = client.Execute(request);

            if (!response.IsSuccessful)
                throw new Exception("Error al contar los likes.");

            var result = JsonConvert.DeserializeObject<Dictionary<string, int>>(response.Content);
            return result.ContainsKey("cantidad") ? result["cantidad"] : 0;
        }
        public int ContarComentarios(int idPost)
        {
            RestClient client = new RestClient("https://localhost:44358/");
            RestRequest request = new RestRequest($"api/Post/ContarComentarios/{idPost}", Method.Get);
            var response = client.Execute(request);

            if (!response.IsSuccessful)
                throw new Exception("Error al contar los comentarios.");

            var result = JsonConvert.DeserializeObject<Dictionary<string, int>>(response.Content);
            return result.ContainsKey("cantidad") ? result["cantidad"] : 0;
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            VerComentarPost comentar = new VerComentarPost();
            comentar.Show();

            // Pasarle id_post para comentar
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

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (EditarPost.eventoInstancia == null || EditarPost.eventoInstancia.IsDisposed)
            {
                EditarPost.eventoInstancia = new EditarPost();
                EditarPost.eventoInstancia.Show();
            }
            else
            {
                EditarPost.eventoInstancia.Close();
                EditarPost.eventoInstancia = new EditarPost();
                EditarPost.eventoInstancia.Show();
            }
        }
    }
}
