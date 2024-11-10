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
                var datosLogin = new Dictionary<string, string>
            {
            { "email", txtBoxEmail.Text },
            { "contrasena", txtBoxPass.Text }
            };
                string requestBody = JsonConvert.SerializeObject(datosLogin);

                RestClient client = new RestClient("https://localhost:44331/");
                RestRequest request = new RestRequest("/api/Usuario/Login", Method.Post);
                request.AddJsonBody(requestBody);
                request.AddHeader("Accept", "application/json");
                request.AddHeader("Content-Type", "application/json");

                RestResponse response = client.Execute(request);

                if (response.IsSuccessful)
                {
                    string email = txtBoxEmail.Text;
                    Dictionary<string, string> perfil = ObtenerPerfilUsuario(email);
                    if (perfil == null)
                        return;

                    AsignarDatosDePerfil(perfil);
                    Inicio inicio = new Inicio();
                    inicio.Show();
                    inicio.Login = this;
                    this.Hide();
                    return;
                }
                MostrarMensajeCredencialesIncorrectas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
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
        private Dictionary<string, string> ObtenerPerfilUsuario(string email)
        {
            RestClient client = new RestClient("https://localhost:44331/");
            RestRequest request = new RestRequest($"/api/Usuario/{email}/", Method.Get);
            request.AddHeader("Accept", "application/json");

            RestResponse response = client.Execute(request);
            if (!response.IsSuccessful || string.IsNullOrEmpty(response.Content))
            {
                MessageBox.Show("No se encontró el perfil de usuario.");
                return null;
            }

            return JsonConvert.DeserializeObject<Dictionary<string, string>>(response.Content);
        }
        private void AsignarDatosDePerfil(Dictionary<string, string> perfil)
        {


            if (perfil.TryGetValue("id_perfil", out string idPerfilValue) && int.TryParse(idPerfilValue, out int idPerfil))
                DatosDePerfil.idPerfil = idPerfil;

            if (perfil.TryGetValue("apodo", out string apodo))
                DatosDePerfil.apodo = apodo;

            if (perfil.TryGetValue("email", out string email))
                DatosDePerfil.email = email;
            if (perfil.TryGetValue("contrasena", out string contrasena))
                DatosDePerfil.contrasena = contrasena;

            if (perfil.TryGetValue("telefono", out string telefono))
                DatosDePerfil.telefono = telefono;

            if (perfil.TryGetValue("nombre", out string nombre))
                DatosDePerfil.nombre = nombre;

            if (perfil.TryGetValue("apellido", out string apellido))
                DatosDePerfil.apellido = apellido;

            if (perfil.TryGetValue("fecha_nacimiento", out string fechaNacimiento))
                DatosDePerfil.fechaNacimiento = fechaNacimiento;

            if (perfil.TryGetValue("idFotoPerfil", out string idFotoPerfil))
                DatosDePerfil.idFotoPerfil = idFotoPerfil;
            else
                DatosDePerfil.idFotoPerfil = null;

            if (perfil.TryGetValue("idioma", out string idioma))
                DatosDePerfil.idioma = idioma;

            if (perfil.TryGetValue("atributo1", out string atributo1))
                DatosDePerfil.atributo1 = atributo1;

            if (perfil.TryGetValue("atributo2", out string atributo2))
                DatosDePerfil.atributo2 = atributo2;
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
/*
        private RestResponse HacerSolicitudLogin()
        {
            var datosLogin = CrearDatosLogin();
            string requestBody = JsonConvert.SerializeObject(datosLogin);

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
            if (perfil == null)
            {
                MessageBox.Show("El perfil de usuario no existe.");
                return;
            }
            AsignarDatosDePerfil(perfil);
            AbrirInicio();
        }
        private void AbrirInicio()
        {
            Inicio inicio = new Inicio();
            inicio.Show();
            inicio.Login = this;
            this.Hide();
        }
        private Dictionary<string, string> CrearDatosLogin()
        {
            return new Dictionary<string, string>
            {
                { "email", txtBoxEmail.Text },
                { "contrasena", txtBoxPass.Text }
            };
           
        }
 */ 