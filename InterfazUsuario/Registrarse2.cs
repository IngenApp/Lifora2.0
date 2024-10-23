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
using RestSharp;
using Newtonsoft.Json;


namespace InterfazUsuario
{
    public partial class Registrarse2 : Form
    {
        public Registrarse1 Registrarse1;
        public String email, telefono, contrasena;

        public Registrarse2()

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

        private void Registrarse2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Settings.Default.Save();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtBoxName.Text.Equals("") || txtBoxSurName.Text.Equals("") || txtBoxDateOfBirth.Text.Equals("") || txtBoxNickName.Text.Equals(""))
            {
                MessageBox.Show("Complete los campos");
                return;
            }

            try
            {
                Dictionary<string, string> loginData = new Dictionary<string, string>()
        {
            { "email", email },
            { "nombre", txtBoxName.Text },
            { "apellido", txtBoxSurName.Text },
            { "telefono", telefono },
            { "contrasena", contrasena },
            { "fechaNacimiento", txtBoxDateOfBirth.Text },
            { "apodo", txtBoxNickName.Text },
            { "idioma", "espanol" }
        };
                string requestBody = JsonConvert.SerializeObject(loginData);

                RestClient client = new RestClient("https://localhost:44331/");
                RestRequest request = new RestRequest("/api/Usuario/CrearUsuario", Method.Post);

                request.AddJsonBody(requestBody);
                request.AddHeader("Accept", "application/json");
                request.AddHeader("Content-Type", "application/json");

                RestResponse response = client.Execute(request);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Usuario creado correctamente");
                    this.Close();
                    if (Registrarse1 != null)
                    {
                        Registrarse1.Close();
                    }
                    return;
                }
                MessageBox.Show("Error al crear el usuario: " + response.Content);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message);
            }
        }

        private void Registrarse2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Registrarse1.Show();
        }
    }
}
