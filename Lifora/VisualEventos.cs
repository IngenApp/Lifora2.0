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
    public partial class VisualEventos : Form
    {
        public VisualEventos()
        {
            InitializeComponent();
            dataGridViewEventos.DataSource = ControladorEventos.ListarEventos();
        }

        private void BtnCrearEvento_Click(object sender, EventArgs e)
        {
            CrearEventoBackoffice ceb = new CrearEventoBackoffice();
            ceb.Show();
        }

        private void dataGridViewEventos_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewEventos.SelectedRows.Count > 0)
            {
                DataGridViewRow seleccion = dataGridViewEventos.SelectedRows[0];
                textBoxNuevoNombreEvento.Text = seleccion.Cells[1].Value?.ToString();
                richTextBoxEvento.Text = seleccion.Cells[2].Value?.ToString();
                textBoxNuevoLugarEvento.Text = seleccion.Cells[3].Value?.ToString();
                textBoxNuevaFechaEvento.Text = seleccion.Cells[4].Value?.ToString();
            }
        }

        private void BtnBloquearEvento_Click(object sender, EventArgs e)
        {
            DialogResult pregunta = MessageBox.Show("Bloquear este Evento?", "Estas seguro?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (pregunta == DialogResult.Yes)
            {
                if (dataGridViewEventos.SelectedRows.Count > 0)
                {
                    DataGridViewRow seleccion = dataGridViewEventos.SelectedRows[0];
                    int columna = 0;
                    var CellValue = seleccion.Cells[columna].Value;
                    string Id = CellValue.ToString();
                    int id_evento = int.Parse(Id);
                    ControladorEventos.DeshabilitarEvento(id_evento);
                    dataGridViewEventos.DataSource = ControladorEventos.ListarEventos();

                }
                if (dataGridViewEventos.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Debes seleccionar un evento");
                }
            }
            if (pregunta == DialogResult.No)
            {
                MessageBox.Show("No se ah bloqueado el evento");
            }
        }

        private void BtnModificarEvento_Click(object sender, EventArgs e)
        {
            DialogResult pregunta = MessageBox.Show("Aplicar cambios?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (pregunta == DialogResult.Yes)
            {
                DataGridViewRow seleccion = dataGridViewEventos.SelectedRows[0];
                int columna = 0;
                var CellValue = seleccion.Cells[columna].Value;
                string id_evento = CellValue.ToString();
                ControladorEventos.ModificarEventoBackoffice(id_evento, textBoxNuevoNombreEvento.Text, richTextBoxEvento.Text, textBoxNuevoLugarEvento.Text, textBoxNuevaFechaEvento.Text);
                MessageBox.Show("Cambios realizados con exito");
                dataGridViewEventos.DataSource = ControladorEventos.ListarEventos();
            }
            if (pregunta == DialogResult.No)
            {
                MessageBox.Show("No se han realizado los cambios");
            }
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (dataGridViewEventos.SelectedRows.Count > 0)
                (dataGridViewEventos.DataSource as DataTable).DefaultView.RowFilter = string.Format("Convert(ID, 'System.String') LIKE '%{0}%'", textBox3.Text);
            if (dataGridViewEventos.SelectedRows.Count == 0)
                dataGridViewEventos.DataSource = ControladorEventos.ListarEventos();
        }

        private void btnUnlockThePost_Click(object sender, EventArgs e)
        {
            DialogResult pregunta = MessageBox.Show("Desbloquear este Evento?", "Estas seguro?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (pregunta == DialogResult.Yes)
            {
                if (dataGridViewEventos.SelectedRows.Count > 0)
                {
                    DataGridViewRow seleccion = dataGridViewEventos.SelectedRows[0];
                    int columna = 0;
                    var CellValue = seleccion.Cells[columna].Value;
                    string Id = CellValue.ToString();
                    int id_evento = int.Parse(Id);
                    ControladorEventos.HabilitarEvento(id_evento);
                    dataGridViewEventos.DataSource = ControladorEventos.ListarEventos();

                }
                if (dataGridViewEventos.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Debes seleccionar un evento");
                }
            }
            if (pregunta == DialogResult.No)
            {
                MessageBox.Show("No se ah Habilitado el evento");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (dataGridViewEventos.SelectedRows.Count > 0)
                (dataGridViewEventos.DataSource as DataTable).DefaultView.RowFilter = string.Format("IDCuenta LIKE '%{0}%'", textBox2.Text);
            if (dataGridViewEventos.SelectedRows.Count == 0)
                dataGridViewEventos.DataSource = ControladorEventos.ListarEventos();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (dataGridViewEventos.SelectedRows.Count > 0)
                (dataGridViewEventos.DataSource as DataTable).DefaultView.RowFilter = string.Format("Nombre LIKE '%{0}%'", textBox1.Text);
            if (dataGridViewEventos.SelectedRows.Count == 0)
                dataGridViewEventos.DataSource = ControladorEventos.ListarEventos();
        }
    }
}
