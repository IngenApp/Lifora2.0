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
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            PerfilPrincipal perfilPrincipal = new PerfilPrincipal();
            this.Enabled = false;
            perfilPrincipal.Show();
            perfilPrincipal.FormClosed += (s, args) => this.Enabled = true;
        }
    }
}
