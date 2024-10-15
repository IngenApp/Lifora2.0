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
    public partial class Registrarse2 : Form
    {
        public Registrarse1 Registrarse1;
        public String email, telefono, contrasena;

        public Registrarse2()

        {
            InitializeComponent();
        }

        private void Registrarse2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Registrarse1.Show();
        }

      

        private void Registrarse2_Load(object sender, EventArgs e)
        {
            if (!textBox1.Text.Equals("") && !textBox2.Text.Equals("") && !textBox3.Text.Equals("") && !textBox4.Text.Equals(""))
            {
            
                // se conecta con api usuario para crear cuenta, falta detallar el codigo verificador al mail y al telefono


            }
            else
            {
                MessageBox.Show("Complete los campos");
            }
        } 
    }
}
