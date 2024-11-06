using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;
using InterfazUsuario.Properties;
using Newtonsoft.Json;
using RestSharp;


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
            try
            {
                RestResponse response = HacerSolicitudLogin();

                if (response.IsSuccessful)
                {
                    ProcesarLoginExitoso();
                    return;
                }

                MostrarMensajeCredencialesIncorrectas();
            }
            catch (Exception ex)
            {
                MostrarError(ex.Message);
            }
        }
        private Dictionary<string, string> CrearDatosLogin()
        {
            return new Dictionary<string, string>
            {
                { "email", txtBoxEmail.Text },
                { "contrasena", txtBoxPass.Text }
            };
        }

        private RestResponse HacerSolicitudLogin()
        {
            string requestBody = JsonConvert.SerializeObject(CrearDatosLogin());

            RestClient client = new RestClient("https://localhost:44331/");
            RestRequest request = new RestRequest("/api/Usuario/Login", Method.Post);

            request.AddJsonBody(requestBody);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");

            return client.Execute(request);
        }

        private void ProcesarLoginExitoso()
        {
            string email = txtBoxEmail.Text;
            Dictionary<string, string> perfil = ObtenerPerfilUsuario(email);

            if (perfil != null)
            {
                AsignarDatosDePerfil(perfil);
                AbrirInicio();
            }
        }

        private void MostrarMensajeCredencialesIncorrectas()
        {
            if (Settings.Default.Idioma == "es-UY")
            {
                MessageBox.Show("Credenciales incorrectas");
            }
            else if (Settings.Default.Idioma == "en-US")
            {
                MessageBox.Show("Incorrect credentials");
            }
        }
        private void MostrarError(string mensaje)
        {
            MessageBox.Show($"Ocurrió un error: {mensaje}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private Dictionary<string, string> ObtenerPerfilUsuario(string email)
        {
            RestClient client = new RestClient("http://localhost:44331/");
            RestRequest request = new RestRequest($"/api/Usuario/{email}", Method.Get);
            request.AddHeader("Accept", "application/json");

            RestResponse response = client.Execute(request);
            return JsonConvert.DeserializeObject<Dictionary<string, string>>(response.Content);
        }

        private void AsignarDatosDePerfil(Dictionary<string, string> perfil)
        {
            DatosDePerfil.idPerfil = int.Parse(perfil["idPerfil"]);
            DatosDePerfil.nombre = perfil["nombre"];
            DatosDePerfil.apellido = perfil["apellido"];
            DatosDePerfil.fechaNacimiento = perfil["fechaNacimiento"];
            DatosDePerfil.email = perfil["email"];
            DatosDePerfil.telefono = perfil["telefono"];
            DatosDePerfil.apodo = perfil["apodo"];
            DatosDePerfil.idFotoPerfil = string.IsNullOrEmpty(perfil["idFotoPerfil"]) ? (int?)null : int.Parse(perfil["idFotoPerfil"]);
            DatosDePerfil.idioma = perfil["idioma"];
            DatosDePerfil.atributo1 = perfil["atributo1"];
            DatosDePerfil.atributo2 = perfil["atributo2"];
        }

        private void AbrirInicio()
        {
            Inicio inicio = new Inicio();
            inicio.Show();
            inicio.Login = this;
            this.Hide();
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

        private void txtBoxPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e);

                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
    }
}
