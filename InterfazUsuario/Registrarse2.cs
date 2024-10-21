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
            if (!txtBoxName.Text.Equals("") && !txtBoxSurName.Text.Equals("") && !txtBoxDateOfBirth.Text.Equals("") && !txtBoxNickName.Text.Equals(""))
            {

                // se conecta con api usuario para crear cuenta, falta detallar el codigo verificador al mail y al telefono
                this.Close();
                Registrarse1.Close();

            }
            else
            {
                MessageBox.Show("Complete los campos");
            }
        }

        private void Registrarse2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Registrarse1.Show();
        }
    }
}
