using System;
using System.IO;
using System.Windows.Forms;
using Controladores;
using System.Data;
using System.Collections.Generic;

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
            if (textBoxId_cuenta.Text == "" || textBoxNombreEvento.Text == "" || richTextBox1.Text == "" || textBoxLugar.Text == "" || textBoxFecha.Text == "")
            {
                MessageBox.Show("Debe completar todos los campos");
            }
            else
            {
                ControladorEventos.CrearEvento(Int32.Parse(textBoxId_cuenta.Text), textBoxNombreEvento.Text, richTextBox1.Text, textBoxLugar.Text, textBoxFecha.Text);
                MessageBox.Show("Evento creado con exito");
                textBoxId_cuenta.Text = "";
                textBoxNombreEvento.Text = "";
                richTextBox1.Text = "";
                textBoxLugar.Text = "";
                textBoxFecha.Text = "";
            }
        }        
    }        
}
