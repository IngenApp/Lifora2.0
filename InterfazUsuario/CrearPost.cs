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
    public partial class CrearPost : Form
    {
        
        public CrearPost()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Metodo Api crear post
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CrearPostTexto texto = new CrearPostTexto();
            texto.Show();
            texto.crearPost = this;
            this.Hide();
        }
    }
}
