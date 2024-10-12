using System;
using System.IO;
using System.Windows.Forms;
using Controladores;
using InterfazUsuario;
using System.Data;



namespace Lifora
{
    public partial class login : Form
    {
       
        
        public login()
        {
            InitializeComponent();
        }

        private void buttonBackOffice_Click(object sender, EventArgs e)
        {
            if(ControladorCuentaUsuario.Login(textBoxMail.Text, textBoxPassword.Text) == true)
            {
                backoffice backoff = new backoffice();
                backoff.Show();
                textBoxMail.Text = "";
                textBoxPassword.Text = "";
                this.Hide();
                
            }
            else
            {
                MessageBox.Show("Credenciales incorrectas o usuario bloqueado");
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Login Login = new Login();
            this.Enabled = false;
            Login.Show();
        }
    }
    
}

