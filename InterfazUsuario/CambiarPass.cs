using System;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;
using InterfazUsuario.Properties;

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
                this.Close();
                  
        }

        private void CambiarPass_Load(object sender, EventArgs e)
        {
            CargarIdioma();
        }
    }
    
}
