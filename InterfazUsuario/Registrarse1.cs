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
    public partial class Registrarse1 : Form
    {
        public Registrarse1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!textBox1.Text.Equals("") && !textBox2.Text.Equals("") && !textBox3.Text.Equals(""))
            {
                if (textBox3.Text.Equals(textBox4.Text)) 
                {
                    Registrarse2 Registrarse2 = new Registrarse2();
                    Registrarse2.email = textBox1.Text;
                    Registrarse2.Text = textBox2.Text;
                    Registrarse2.contrasena = textBox3.Text;
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

   
    }
}
