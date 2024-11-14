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
using System.Drawing.Drawing2D;

namespace InterfazUsuario
{
    public partial class GruposMenu : Form
    {
     
        public static GruposMenu menuGruposInstancia = null;
        public GruposMenu()
        {
            InitializeComponent();
            MakeCircularPictureBox(pictureBox1);
            
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
        private void MakeCircularPictureBox(PictureBox pictureBox2)
        {
            GraphicsPath path = new GraphicsPath();

            path.AddEllipse(0, 0, pictureBox2.Width, pictureBox2.Height);

            pictureBox2.Region = new Region(path);
        }
        private void btnGrupo_Click(object sender, EventArgs e)
        {
            Grupos grupos = new Grupos();
            grupos.Show();
        }
       
       
    }
}
