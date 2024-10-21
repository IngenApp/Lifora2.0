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
        private void button1_Click(object sender, EventArgs e)
        {
            if (!txtBoxMail.Text.Equals("") && !txtBoxPhone.Text.Equals("") && !txtBoxPassword.Text.Equals(""))
            {
                if (txtBoxPassword.Text.Equals(txtBoxConfirmPassword.Text)) 
                {
                    Registrarse2 Registrarse2 = new Registrarse2();
                    Registrarse2.email = txtBoxMail.Text;
                    Registrarse2.Text = txtBoxPhone.Text;
                    Registrarse2.contrasena = txtBoxPassword.Text;
                    Registrarse2.Show();
                    Registrarse2.Registrarse1 = this;
                    this.Hide();
            
                    //se debe generar el codigo del mail y al telefono para el siguiente paso
                }
                else
                {
                    MessageBox.Show("Las contrasenas no cohinciden");
                }
            }
            else
            {
                MessageBox.Show("Complete los campos");
            }
        }

        private void Registrarse1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Settings.Default.Save();
        }
    }
}
