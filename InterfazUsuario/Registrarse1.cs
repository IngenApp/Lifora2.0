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
using System.Text.RegularExpressions;

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
            string input = txtBoxPass.Text;
            string emailInput = txtBoxEmail.Text;
            string passPattern = @"^(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,24}$";
            string emailPattern = @"^[\w\.-]+@[a-zA-Z\d\.-]+\.[a-zA-Z]{2,}$";
            if (!txtBoxEmail.Text.Equals("") && !txtBoxTelefono.Text.Equals("") && !txtBoxPass.Text.Equals("") && Regex.IsMatch(input, passPattern) && Regex.IsMatch(emailInput, emailPattern))
            {
                
                    if (txtBoxPass.Text.Equals(txtBoxConfPass.Text))
                    {
                        Registrarse2 Registrarse2 = new Registrarse2();
                        Registrarse2.email = txtBoxEmail.Text;
                        Registrarse2.telefono = txtBoxTelefono.Text;
                        Registrarse2.contrasena = txtBoxPass.Text;
                        Registrarse2.Show();
                        Registrarse2.Registrarse1 = this;
                        this.Hide();

                    }              
                    else
                    {
                        MessageBox.Show("Las contrasenas no cohinciden");
                    }
                
                
            }
            else
            {
                MessageBox.Show("Los campos no pueden estar vacios, el mail debe ser correcto y la contrasena cumplir con los requisitos de seguridad");
            }
        }

        private void Registrarse1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Settings.Default.Save();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            AvisoPass aviso = new AvisoPass();
            aviso.Show();
        }
    }
}
