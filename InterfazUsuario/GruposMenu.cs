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
    public partial class GruposMenu : Form
    {
        public static GruposMenu menuGruposInstancia = null;
        public GruposMenu()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AbrirCrearGrupo();
        }
        private void AbrirCrearGrupo()
        {
            if (CrearGrupo.grupoInstancia == null || CrearGrupo.grupoInstancia.IsDisposed)
            {
                CrearGrupo.grupoInstancia = new CrearGrupo();
                CrearGrupo.grupoInstancia.Show();
            }
            else
            {
                CrearGrupo.grupoInstancia.WindowState = FormWindowState.Normal;
                CrearGrupo.grupoInstancia.BringToFront();
            }
        }
    }
}
