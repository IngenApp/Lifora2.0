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
    public partial class CrearGrupo : Form
    {
        public static CrearGrupo grupoInstancia = null;
        string rutaImagen;

        public CrearGrupo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            if (string.IsNullOrEmpty(richTextBox1.Text) || string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Ingrese lo que desea el nombre y la descripcion del grupo");
            }
            else
            {
                if (string.IsNullOrEmpty(rutaImagen))
                {
                    MessageBox.Show("Selecciona una imagen");
                }
                else
                {
                    //Api crear Post Audio
                    this.Close();

                }
            }

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos de imagen (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
            openFileDialog.Title = "Selecciona una imagen";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                rutaImagen = openFileDialog.FileName;
                pictureBox1.Image = new Bitmap(rutaImagen);
            }
        }
    }
}
