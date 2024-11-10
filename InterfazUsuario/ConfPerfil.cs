using System;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;
using InterfazUsuario.Properties;


namespace InterfazUsuario
{
    public partial class ConfPerfil : Form
    {
        public static ConfPerfil PostInstancia = null;
        public ConfPerfil()
        {
            InitializeComponent();
            CargarIdioma();
           
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
            this.Close();
        }

        private void lblCambiarContrasena_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (CambiarPass.PostInstancia == null || CambiarPass.PostInstancia.IsDisposed)
            {
                CambiarPass.PostInstancia = new CambiarPass();
                CambiarPass.PostInstancia.Show();
            }
            else
            {
                CambiarPass.PostInstancia.WindowState = FormWindowState.Normal;
                CambiarPass.PostInstancia.BringToFront();
            }
        }
    }
}
