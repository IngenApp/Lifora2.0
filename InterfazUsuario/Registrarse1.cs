using System;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;
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
                    if (Settings.Default.Idioma == "es-UY")
                    {
                        MessageBox.Show("Las contrasenas no cohinciden");
                    }
                     if(Settings.Default.Idioma == "en-US")
                    {
                        MessageBox.Show("Passwords don't match");
                    } 
                    }
                
                
            }
            else
            {
                if (Settings.Default.Idioma == "es-UY")
                {
                    MessageBox.Show("Los campos no pueden estar vacios, el mail debe ser correcto y la contrasena cumplir con los requisitos de seguridad");
                }
                if (Settings.Default.Idioma == "en-US")
                {
                    MessageBox.Show("The fields cannot be empty, the email must be correct and the password must meet the security requirements");
                }
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
