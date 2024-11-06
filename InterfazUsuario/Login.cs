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
            int idPerfil = DatosDePerfil.idPerfil;

            if (perfil != null)
            {
                AsignarDatosDePerfil(perfil);
                MeSiguen(idPerfil);
                Seguidos(idPerfil);
                //  CantidadMeSiguen(idPerfil);
                // CantidadSeguidos(idPerfil);
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
            RestClient client = new RestClient("https://localhost:44331/");
            RestRequest request = new RestRequest($"/api/Usuario/{email}/", Method.Get);
            request.AddHeader("Accept", "application/json");

            RestResponse response = client.Execute(request);
            return JsonConvert.DeserializeObject<Dictionary<string, string>>(response.Content);
        }

        private void AsignarDatosDePerfil(Dictionary<string, string> perfil)
        {
            DatosDePerfil.idPerfil = int.Parse(perfil["id_perfil"]);
            DatosDePerfil.apodo = perfil["apodo"];
            DatosDePerfil.email = perfil["email"];
            DatosDePerfil.telefono = perfil["telefono"];
            DatosDePerfil.nombre = perfil["nombre"];
            DatosDePerfil.apellido = perfil["apellido"];
            DatosDePerfil.fechaNacimiento = perfil["fecha_nacimiento"];
            DatosDePerfil.idFotoPerfil = string.IsNullOrEmpty(perfil["id_foto_perfil"]) ? (int?)null : int.Parse(perfil["id_foto_perfil"]);
            DatosDePerfil.idioma = perfil["idioma"];
            DatosDePerfil.atributo1 = perfil["atributo1"];
            DatosDePerfil.atributo2 = perfil["atributo2"];

        }

        private static void MeSiguen(int idPerfil)
        {
            RestClient client = new RestClient("https://localhost:44331/");
            RestRequest request = new RestRequest($"api/Usuario/MeSiguen/{idPerfil}/", Method.Get);
            request.AddHeader("Accept", "application/json");

            RestResponse response = client.Execute(request);

            if (response.IsSuccessful)
            {
                List<string> meSiguen = JsonConvert.DeserializeObject<List<string>>(response.Content);
                DatosDePerfil.Seguidores = meSiguen;
                return;
            }
            Console.WriteLine($"Error: {response.StatusCode} - {response.ErrorMessage}");
            DatosDePerfil.Seguidores = new List<string>();
            return;

        }

        /*        private static void CantidadMeSiguen(int idPerfil)
                {
                    RestClient client = new RestClient("https://localhost:44331/");
                    RestRequest request = new RestRequest($"api/Usuario/CantidadSeguidores/{idPerfil}/", Method.Get);
                    request.AddHeader("Accept", "application/json");

                    RestResponse response = client.Execute(request);

                    if (response.IsSuccessful)
                    {
                        var result = JsonConvert.DeserializeObject<dynamic>(response.Content);
                        int cantidadMeSiguen = result?.cantidadSeguidores;

                        DatosDePerfil.CantidadSeguidores = cantidadMeSiguen;
                        return;
                    }

                    Console.WriteLine($"Error: {response.StatusCode} - {response.ErrorMessage}");
                    DatosDePerfil.CantidadSeguidores = 0; 
                    return;
                }
        */
        private static void Seguidos(int idPerfil)
        {
            RestClient client = new RestClient("https://localhost:44331/");
            RestRequest request = new RestRequest($"api/Usuario/Sigo/{idPerfil}/", Method.Get);
            request.AddHeader("Accept", "application/json");

            RestResponse response = client.Execute(request);

            if (response.IsSuccessful)
            {
                List<string> seguidos = JsonConvert.DeserializeObject<List<string>>(response.Content);
                DatosDePerfil.Seguidos = seguidos;
                return;
            }
            Console.WriteLine($"Error: {response.StatusCode} - {response.ErrorMessage}");
            DatosDePerfil.Seguidos = new List<string>();
            return;
        }

        /*       private static void CantidadSeguidos(int idPerfil)
               {
                   RestClient client = new RestClient("https://localhost:44331/");
                   RestRequest request = new RestRequest($"api/Usuario/CantidadSeguidos/{idPerfil}/", Method.Get);
                   request.AddHeader("Accept", "application/json");

                   RestResponse response = client.Execute(request);

                   if (response.IsSuccessful)
                   {
                       var result = JsonConvert.DeserializeObject<dynamic>(response.Content);
                       int cantidadSeguidos = result?.cantidadSeguidos;

                       DatosDePerfil.CantidadSeguidos = cantidadSeguidos;
                       return;
                   }

                   Console.WriteLine($"Error: {response.StatusCode} - {response.ErrorMessage}");
                   DatosDePerfil.CantidadSeguidos = 0; 
                   return;
               }
       */

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
