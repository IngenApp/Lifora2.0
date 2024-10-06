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
    public partial class VisualGrupos : Form
    {
        public VisualGrupos()
        {
            InitializeComponent();
            dataGridGrupos.DataSource = ControladorGrupos.ListarGrupos();
        }

        

        private void btnModificarGrupo_Click(object sender, EventArgs e)
        {
            DialogResult pregunta = MessageBox.Show("Aplicar cambios?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (pregunta != DialogResult.Yes)
            {
                MessageBox.Show("No se han realizado los cambios");
                return;
            }
            DataGridViewRow seleccion = dataGridGrupos.SelectedRows[0];
            int columna = 0;
            var CellValue = seleccion.Cells[columna].Value;
            int idGrupo = Int32.Parse(CellValue.ToString());
            string nombre = textBoxNombreGrupo.Text;
            string descripcion = richTextBoxGrupo.Text;
            ControladorGrupos.ModificarGrupo(idGrupo, nombre, descripcion);
            dataGridGrupos.DataSource = ControladorGrupos.ListarGrupos();
        }

        private void btnBloquearGrupo_Click(object sender, EventArgs e)
        {
            DialogResult pregunta = MessageBox.Show("Bloquear este Grupo?", "Estas seguro?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (pregunta == DialogResult.Yes)
            {
                if (dataGridGrupos.SelectedRows.Count > 0)
                {
                    DataGridViewRow seleccion = dataGridGrupos.SelectedRows[0];
                    int columna = 0;
                    var CellValue = seleccion.Cells[columna].Value;
                    string Id = CellValue.ToString();
                    int idGrupo = int.Parse(Id);
                    ControladorGrupos.BloquearGrupo(idGrupo);
                    dataGridGrupos.DataSource = ControladorGrupos.ListarGrupos();
                }
                if (dataGridGrupos.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Debes seleccionar un Grupo");
                }
            }
            if (pregunta == DialogResult.No)
            {
                MessageBox.Show("No se ah bloqueado el Grupos");
            }
            dataGridGrupos.DataSource = ControladorGrupos.ListarGrupos();
        }

        private void btnHabilitarGrupo_Click(object sender, EventArgs e)
        {
            DialogResult pregunta = MessageBox.Show("Desbloquear este Grupo?", "Estas seguro?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (pregunta == DialogResult.Yes)
            {
                if (dataGridGrupos.SelectedRows.Count > 0)
                {
                    DataGridViewRow seleccion = dataGridGrupos.SelectedRows[0];
                    int columna = 0;
                    var CellValue = seleccion.Cells[columna].Value;
                    string Id = CellValue.ToString();
                    int idGrupo = int.Parse(Id);
                    ControladorGrupos.HabilitarGrupo(idGrupo);
                    dataGridGrupos.DataSource = ControladorGrupos.ListarGrupos();
                }
                if (dataGridGrupos.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Debes seleccionar un Grupo");
                }
            }
            if (pregunta == DialogResult.No)
            {
                MessageBox.Show("No se ah bloqueado el Grupo");
            }
            dataGridGrupos.DataSource = ControladorGrupos.ListarGrupos();
        }

        private void dataGridGrupos_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridGrupos.SelectedRows.Count > 0)
            {
                DataGridViewRow seleccion = dataGridGrupos.SelectedRows[0];
                textBoxNombreGrupo.Text = seleccion.Cells[1].Value?.ToString();
                richTextBoxGrupo.Text = seleccion.Cells[2].Value?.ToString();
               
                
            }
        }

        private void btnCrearPost_Click(object sender, EventArgs e)
        {
            CrearGrupoBackoffice cgb = new CrearGrupoBackoffice();
            cgb.Show();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (dataGridGrupos.SelectedRows.Count > 0)
                (dataGridGrupos.DataSource as DataTable).DefaultView.RowFilter = string.Format("Convert(ID, 'System.String') LIKE '%{0}%'", textBox3.Text);
            if (dataGridGrupos.SelectedRows.Count == 0)
                dataGridGrupos.DataSource = ControladorGrupos.ListarGrupos();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (dataGridGrupos.SelectedRows.Count > 0)
                (dataGridGrupos.DataSource as DataTable).DefaultView.RowFilter = string.Format("Convert(IDCuenta, 'System.String') LIKE '%{0}%'", textBox2.Text);
            if (dataGridGrupos.SelectedRows.Count == 0)
                dataGridGrupos.DataSource = ControladorGrupos.ListarGrupos();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (dataGridGrupos.SelectedRows.Count > 0)
                (dataGridGrupos.DataSource as DataTable).DefaultView.RowFilter = string.Format("Nombre LIKE '%{0}%'", textBox1.Text);
            if (dataGridGrupos.SelectedRows.Count == 0)
                dataGridGrupos.DataSource = ControladorGrupos.ListarGrupos();
        }
    }
}
