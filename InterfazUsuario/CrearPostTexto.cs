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
using RestSharp;
using ApiPost.Models;
using Newtonsoft.Json;

namespace InterfazUsuario
{
   


    public partial class CrearPostTexto : Form
    {
        public Form crearPost;


        public CrearPostTexto()
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

/*3*/     private void button1_Click(object sender, EventArgs e)
        {
            //api crear post de texto
            if (string.IsNullOrEmpty(richTextBox1.Text))
            {
                if (CrearTextoPost(DatosDePerfil.idPerfil, richTextBox1.Text))
                {
                    MessageBox.Show("Post Creado");
                    if (Settings.Default.Idioma == "es-UY")
                    {
                        MessageBox.Show("Ingrese lo que desea compartir");
                    }
                    else if (Settings.Default.Idioma == "en-US")
                    {
                        MessageBox.Show("Enter what you want to share");

                    }
                }
                return; 
            }
        } 
/*1*/    private bool CrearTextoPost(int idPerfil, string descripcion)
        {
            Dictionary<string, string> data = new Dictionary<string, string>(){
                { "idPerfil", DatosDePerfil.idPerfil.ToString() },
                { "descripcion", richTextBox1.Text }
            };
            string requestBody = JsonConvert.SerializeObject(data);

            var client = new RestClient("https://localhost:44358/");
            var request = new RestRequest("api/Post/CrearPostTexto/", Method.Post);

            request.RequestFormat = DataFormat.Json;
            request.AddBody(requestBody);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");

            RestResponse response = client.Execute(request);

            if (response.IsSuccessStatusCode)
                return true;
            return false;
        }
/*2*/     private static DataTable generarDataTable(List<ModeloApiPost> posts)
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
      
        private void CrearPostTexto_FormClosing(object sender, FormClosingEventArgs e)
        {
            crearPost.Show();
            
        }
    }
}
/* if (CrearTextoPost(DatosDePerfil.idPerfil, richTextBox1.Text))
                    {
                        MessageBox.Show("Post Created");
                    }
   if (CrearTextoPost(DatosDePerfil.idPerfil, richTextBox1.Text))
                        {
                        }
 
 
 */