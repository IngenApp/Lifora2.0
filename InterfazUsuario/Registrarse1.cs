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
            Form Registrarse2 = new Registrarse2();
            this.Enabled = false;
            Registrarse2.Show();
            Registrarse2.FormClosed += (s, args) => this.Enabled = true;
        }
    }
}
