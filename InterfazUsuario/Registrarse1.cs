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
    public partial class Registrarse1 : Form
    {
        public Registrarse1()
        {
            InitializeComponent();
            CargarIdioma();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form Registrarse2 = new Registrarse2();
            this.Enabled = false;
            Registrarse2.Show();
            Registrarse2.FormClosed += (s, args) => this.Enabled = true;
        }
        public void CargarIdioma()
        {
            try
            {
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Settings.Default.Idioma);

                Idioma.CambiarTexto(this.Controls);
                this.Text = Strings.titulo;
            }
            catch (CultureNotFoundException)
            {
                Console.WriteLine("El idioma seleccionado no es válido. Por favor, selecciona otro.");
            }
        }
    }
}
