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
using Newtonsoft.Json;

namespace InterfazUsuario
{
    public partial class CrearGrupo : Form
    {
        public static CrearGrupo grupoInstancia = null;
        string rutaImagen;

        public CrearGrupo()
        {
            InitializeComponent();
            CargarIdioma();
            MakeCircularPictureBox(pictureBox2);
        }
        private void MakeCircularPictureBox(PictureBox pictureBox2)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, pictureBox2.Width, pictureBox2.Height);
            pictureBox2.Region = new Region(path);
        }
        public static string CrearNuevoGrupo(int idPerfil, string nombre, string informacion) 
        {
            RestClient client = new RestClient("https://localhost:44325/"); 
            RestRequest request = new RestRequest("api/Grupo/CrearGrupo", Method.Post);
            request.AddHeader("Accept", "application/json");
            
            var grupo = new
            {
                idPerfil = idPerfil,
                nombre = nombre,
                informacion = informacion
            };
            request.AddJsonBody(grupo);

            RestResponse response = client.Execute(request);

            if (!response.IsSuccessful)
                throw new Exception("Error al crear el grupo.");

            var result = JsonConvert.DeserializeObject<Dictionary<string, string>>(response.Content);
            return result.ContainsKey("mensaje") ? result["mensaje"] : "Error desconocido";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CrearNuevoGrupo(DatosDePerfil.idPerfil, textBox1.Text,richTextBox1.Text);

            if (string.IsNullOrEmpty(richTextBox1.Text) || string.IsNullOrEmpty(textBox1.Text))
            {
                if (Settings.Default.Idioma == "es-UY")
                {
                    MessageBox.Show("Ingrese el nombre y la descripcion del grupo");

                }
                if (Settings.Default.Idioma == "en-US")
                {
                    MessageBox.Show("Enter the name and description of the group");
                }
               
            }
            else
            {
                if (string.IsNullOrEmpty(rutaImagen))
                {
                    if (Settings.Default.Idioma == "es-UY")
                    {
                        MessageBox.Show("Selecciona una imagen");

                    }
                    if (Settings.Default.Idioma == "en-US")
                    {
                        MessageBox.Show("Select an image");
                    }
                }
                else
                {
                    //Api crear Post Audio
                    this.Close();

                }
            }

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos de imagen (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
            if (Settings.Default.Idioma == "es-UY")
            {
                openFileDialog.Title = "Selecciona una imagen";

            }
            if (Settings.Default.Idioma == "en-US")
            {
                openFileDialog.Title = "Select an image";
            }


            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                rutaImagen = openFileDialog.FileName;
                pictureBox1.Image = new Bitmap(rutaImagen);
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
    }
}
