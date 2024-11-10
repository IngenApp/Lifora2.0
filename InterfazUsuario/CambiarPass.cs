using System;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;
using InterfazUsuario.Properties;
using RestSharp;

namespace InterfazUsuario
{
    public partial class CambiarPass : Form
    {
        public static CambiarPass PostInstancia = null;
        public CambiarPass()
        {
            InitializeComponent();
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
        private void btnCambiar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!DatosDePerfil.contrasena.Equals(textBoxPass.Text))
                {
                    MostrarMensajeCredencialesIncorrectas();
                    return;
                }

                if (!textBoxPassNuevo.Text.Equals(textBoxPassNuevo2.Text))
                {
                    MostrarMensajeCredencialesIncorrectas();
                    return;
                }

                ModificarPerfil(DatosDePerfil.idPerfil, DatosDePerfil.email, DatosDePerfil.apodo, DatosDePerfil.idFotoPerfil, DatosDePerfil.idioma, DatosDePerfil.atributo1, DatosDePerfil.atributo2, textBoxPassNuevo.Text);
                MostrarMensajeCredencialesCorrectas();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al modificar las credenciales: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void MostrarMensajeCredencialesCorrectas()
        {
            if (Settings.Default.Idioma == "es-UY")
            {
                MessageBox.Show("Cambio de Contraseña exitoso");
            }
            else if (Settings.Default.Idioma == "en-US")
            {
                MessageBox.Show("Successful password change");
            }
        }
        private void CambiarPass_Load(object sender, EventArgs e)
        {
            CargarIdioma();
        }
        public static void ModificarPerfil(int id, string email, string apodo, string idFotoPerfil, string idioma, string atributo1, string atributo2, string contrasena)
        {
            try
            {
                RestClient client = new RestClient("https://localhost:44331/");
                RestRequest request = new RestRequest($"api/Usuario/ModificarPerfil/{id}/", Method.Put);
                request.AddHeader("Accept", "application/json");

                var usuarioData = new
                {
                    email, apodo, idFotoPerfil, idioma = string.IsNullOrEmpty(idioma) ? "espanol" : idioma,  atributo1, atributo2, contrasena
                };
                request.AddJsonBody(usuarioData);
                RestResponse response = client.Execute(request);
                if (!response.IsSuccessful)
                {
                    MessageBox.Show("Error al modificar el perfil del usuario: " + response.Content, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Console.Write("Usuario modificado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un problema al intentar modificar el perfil del usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    
    }
}
