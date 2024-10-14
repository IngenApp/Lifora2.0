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

namespace InterfazUsuario
{
    public partial class Registrarse2 : Form
    {
        public Registrarse2()
        {
            InitializeComponent();
            CargarIdioma();
        }
    private void CargarIdioma()
    {
        try
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Settings.Default.Idioma);
            Idioma.CambiarTexto(this.Controls);
            this.Text = Strings.titulo;
        }
        catch (CultureNotFoundException)
        {
            Console.WriteLine("El idioma seleccionado no es válido.");
        }
    }
    }
}
