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

namespace InterfazUsuario
{
    public partial class EditarPost : Form
    {
        public static EditarPost eventoInstancia = null;
        public EditarPost()
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

        private void btnCambiar_Click(object sender, EventArgs e)
        {
            //Editar Post
        }
    }
}
