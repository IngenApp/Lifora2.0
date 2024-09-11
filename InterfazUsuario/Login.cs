using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InterfazUsuario
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Registrarse1 Registrarse1 = new Registrarse1();
            this.Enabled = false;
            Registrarse1.Show();
            Registrarse1.FormClosed += (s, args) => this.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*if (ControladorCuentaUsuario.Login(TxtMailLogin.Text, loginPassword.Text) == true)
            {
            */
                Inicio Inicio = new Inicio();
                this.Enabled = false;
                Inicio.Show();
                Inicio.FormClosed += (s, args) => this.Enabled = true;
            /*
            }
            else
            {
                MessageBox.Show("Credenciales incorrectas");
            }*/
        }
    }
}
