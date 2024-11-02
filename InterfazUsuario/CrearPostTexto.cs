using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;
using InterfazUsuario.Lenguas;
using InterfazUsuario.Properties;

namespace InterfazUsuario
{
   


    public partial class CrearPostTexto : Form
    {
        public Form crearPost;


        public CrearPostTexto()
        {
            InitializeComponent();
            CargarIdioma();
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

        private void button1_Click(object sender, EventArgs e)
        {
            //api crear post de texto
            if (string.IsNullOrEmpty(richTextBox1.Text))
            {
                MessageBox.Show("Ingrese lo que desea compartir");
            }
            else
            {
                this.Close();

                if (crearPost != null && !crearPost.IsDisposed)
                {
                    crearPost.Close();
                }
                richTextBox1.Text = string.Empty;
            }
        }

        private void CrearPostTexto_FormClosing(object sender, FormClosingEventArgs e)
        {
            crearPost.Show();
            
        }
    }
}
