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
            CargarIdioma();
            
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
            // Crear un objeto GraphicsPath para definir la forma circular
            GraphicsPath path = new GraphicsPath();

            // Añadir una elipse al path con el tamaño del PictureBox
            path.AddEllipse(0, 0, pictureBox2.Width, pictureBox2.Height);

            // Asignar la región circular al PictureBox
            pictureBox2.Region = new Region(path);
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

        private void btnGrupo_Click(object sender, EventArgs e)
        {
            // verificar en el datagrid q grupo esta seleccionado
            Grupos grupos = new Grupos();
            grupos.Show();
        }
    }
}
