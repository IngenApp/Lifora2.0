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
            if (textBoxId_cuenta.Text == "" || textBoxNombreEvento.Text=="" || textBoxInformacion.Text=="" || textBoxLugar.Text=="" || textBoxFecha.Text=="")
                MessageBox.Show("Debe completar todos los campos");
            ControladorEventos.CrearEvento(Int32.Parse(textBoxId_cuenta.Text), textBoxNombreEvento.Text, textBoxInformacion.Text, textBoxLugar.Text, textBoxFecha.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ControladorEventos.BuscarIdEvento(textBoxEventoModificar.Text) == 0)
            {
                MessageBox.Show("Ese evento no existe");
            }
            if (textBoxEventoModificar.Text == "" || textBoxNuevoNombreEvento.Text == "") { 
                MessageBox.Show("Complete los campos del evento a modificar y nuevo nombre");
            }
            else
            {
                ControladorEventos.ModificarNombreEvento(ControladorEventos.BuscarIdEvento(textBoxEventoModificar.Text), textBoxNuevoNombreEvento.Text);
                MessageBox.Show("Modificacion efectuada con exito");
                textBoxEventoModificar.Text = "";
                textBoxNuevoNombreEvento.Text = "";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (ControladorEventos.BuscarIdEvento(textBoxEventoModificar.Text) == 0)
            {
                MessageBox.Show("Ese evento no existe");
            }
            if (textBoxEventoModificar.Text == "" || textBoxNuevaInfoEvento.Text == "")
            {
                MessageBox.Show("Complete los campos del evento a modificar y Nueva info");
            }
            else
            {
                ControladorEventos.ModificarInformacionEvento(ControladorEventos.BuscarIdEvento(textBoxEventoModificar.Text), textBoxNuevaInfoEvento.Text);
                MessageBox.Show("Modificacion efectuada con exito");
                textBoxEventoModificar.Text = "";
                textBoxNuevaInfoEvento.Text = "";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (ControladorEventos.BuscarIdEvento(textBoxEventoModificar.Text) == 0)
            {
                MessageBox.Show("Ese evento no existe");
            }
            if (textBoxEventoModificar.Text == "" || textBoxNuevoLugarEvento.Text == "")
            {
                MessageBox.Show("Complete los campos del evento a modificar y Nuevo lugar");
            }
            else
            {
                ControladorEventos.ModificarLugarEvento(ControladorEventos.BuscarIdEvento(textBoxEventoModificar.Text), textBoxNuevoLugarEvento.Text);
                MessageBox.Show("Modificacion efectuada con exito");
                textBoxEventoModificar.Text = "";
                textBoxNuevoLugarEvento.Text = "";
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (ControladorEventos.BuscarIdEvento(textBoxEventoModificar.Text) == 0)
            {
                MessageBox.Show("Ese evento no existe");
            }
            if (textBoxEventoModificar.Text == "" || textBoxNuevaFechaEvento.Text == "")
            {
                MessageBox.Show("Complete los campos del evento a modificar y Nueva fecha evento");
            }
            else
            {
                ControladorEventos.ModificarFechaEvento(ControladorEventos.BuscarIdEvento(textBoxEventoModificar.Text), textBoxNuevaFechaEvento.Text);
                MessageBox.Show("Modificacion efectuada con exito");
                textBoxEventoModificar.Text = "";
                textBoxNuevaFechaEvento.Text = "";
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (ControladorEventos.BuscarIdEvento(textBoxEventoModificar.Text) == 0)
            {
                MessageBox.Show("Ese evento no existe");
            }
            else
            {
                ControladorEventos.DeshabilitarEvento(ControladorEventos.BuscarIdEvento(textBoxEventoModificar.Text));
                MessageBox.Show("Deshabilitacion efectuada con exito");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (ControladorEventos.BuscarIdEvento(textBoxEventoModificar.Text) == 0)
            {
                MessageBox.Show("Ese evento no existe");
            }
            else
            {
                ControladorEventos.HabilitarEvento(ControladorEventos.BuscarIdEvento(textBoxEventoModificar.Text));
                MessageBox.Show("Habilitacion efectuada con exito");
            }
        }
    }
    
}
