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
using Newtonsoft.Json;
using RestSharp;
using Controladores;


namespace InterfazUsuario
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            CargarIdioma();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Registrarse1 Registrarse1 = new Registrarse1();
            Registrarse1.Show();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
          Dictionary<string, string> loginData = new Dictionary<string, string>()
            {
                { "email", txtBoxEmail.Text },
                { "contrasena", txtBoxPass.Text }
            };

            string requestBody = JsonConvert.SerializeObject(loginData);

            RestClient client = new RestClient("https://localhost:44331/");
            RestRequest request = new RestRequest("/api/Usuario/Login", Method.Post);
           
            request.RequestFormat = DataFormat.Json;
            request.AddBody(requestBody);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");

            try
            {
                RestResponse response = client.Execute(request);

                if (response.IsSuccessStatusCode)
                {
                    Inicio inicio = new Inicio();
                    inicio.Show();
                    inicio.Login = this;
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Credenciales incorrectas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        /*  if (ControladorCuentaUsuario.Login(txtBoxMail.Text, txtBoxPassword.Text) == true)
            {
           
                Inicio Inicio = new Inicio();
            Inicio.Show();
            Inicio.Login = this;
            this.Hide();

               
            
            }
            else
            {
                MessageBox.Show("Credenciales incorrectas");
            }
            */
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
        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Settings.Default.Idioma = "es-UY";
            CargarIdioma();
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Settings.Default.Idioma = "en-US";
            CargarIdioma();
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Settings.Default.Save();
        }
    }
}
