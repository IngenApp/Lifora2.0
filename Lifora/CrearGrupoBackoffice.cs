using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controladores;

namespace Lifora
{
    public partial class CrearGrupoBackoffice : Form
    {
        public CrearGrupoBackoffice()
        {
            InitializeComponent();
        }

        private void btnCrearGrupo_Click(object sender, EventArgs e)
        {

            if (textBoxIdUsuario.Text != "" || textBoxNombreGrupo.Text != "" || richTextBox1.Text != "")
            {
                ControladorGrupos.CrearGrupo(Int32.Parse(textBoxIdUsuario.Text), textBoxNombreGrupo.Text, richTextBox1.Text);
                MessageBox.Show("Grupo creado con exito");
                textBoxIdUsuario.Text = "";
                textBoxNombreGrupo.Text = "";
                richTextBox1.Text = "";
                return;
            }
            MessageBox.Show("Debe completar todos los campos");
        }

        
    }
}
