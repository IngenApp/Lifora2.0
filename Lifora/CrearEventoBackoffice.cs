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
    public partial class CrearEventoBackoffice : Form
    {
        public CrearEventoBackoffice()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxId_cuenta.Text == "" && textBoxNombreEvento.Text=="" && textBoxInformacion.Text=="" && textBoxLugar.Text=="" && textBoxFecha.Text=="")
                MessageBox.Show("Debe completar todos los campos");
            ControladorEventos.CrearEvento(Int32.Parse(textBoxId_cuenta.Text), textBoxNombreEvento.Text, textBoxInformacion.Text, textBoxLugar.Text, textBoxFecha.Text);
        }
    }
}
