using System;
using System.IO;
using System.Windows.Forms;
using Controladores;
using System.Data;
using System.Collections.Generic;

namespace Lifora
{
    public partial class backoffice : Form
    {
        public string id;
        public backoffice()
        {
            InitializeComponent();
        }
        private void btnSearchUser_Click(object sender, EventArgs e)
        {
            dataGridViewInfoUser.DataSource = ControladorCuentaUsuario.Listar();
        }
        private void btnBlockTheUser_Click(object sender, EventArgs e)
        {
            DialogResult pregunta = MessageBox.Show("Bloquear este usuario?", "Estas seguro?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (pregunta == DialogResult.Yes)
            {
                if (dataGridViewInfoUser.SelectedRows.Count > 0)
                {
                    DataGridViewRow seleccion = dataGridViewInfoUser.SelectedRows[0];
                    int columna = 0;
                    var CellValue = seleccion.Cells[columna].Value;
                    string Id = CellValue.ToString();
                    int id = int.Parse(Id);
                    ControladorCuentaUsuario.DeshabilitaCuentaUsuario(id);
                    dataGridViewInfoUser.DataSource = ControladorCuentaUsuario.Listar();
                }
                if (dataGridViewInfoUser.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Debes seleccionar un usuario");
                }
            }
            if (pregunta == DialogResult.No)
            {
                MessageBox.Show("No se ah bloqueado el usuario");
            }
        }
        private void txtBoxSearch_TextChanged(object sender, EventArgs e)
        {
            if (dataGridViewInfoUser.SelectedRows.Count > 0)
                (dataGridViewInfoUser.DataSource as DataTable).DefaultView.RowFilter = string.Format("email LIKE '%{0}%'", txtBoxSearch.Text);
        }
        private void btnUnlockTheUser_Click(object sender, EventArgs e)
        {
            DialogResult pregunta = MessageBox.Show("Habilitar este usuario?", "Estas seguro?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (pregunta == DialogResult.Yes)
            {
                if (dataGridViewInfoUser.SelectedRows.Count > 0)
                {
                    DataGridViewRow seleccion = dataGridViewInfoUser.SelectedRows[0];
                    int columna = 0;
                    var CellValue = seleccion.Cells[columna].Value;
                    string Id = CellValue.ToString();
                    int id = int.Parse(Id);
                    ControladorCuentaUsuario.HabilitaCuentaUsuario(id);
                    dataGridViewInfoUser.DataSource = ControladorCuentaUsuario.Listar();
                }
                if (dataGridViewInfoUser.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Debes seleccionar un usuario");
                }
            }
            if (pregunta == DialogResult.No)
            {
                MessageBox.Show("No se ah habilitado el usuario");
            }
        }
        private void BtnModificar_Click(object sender, EventArgs e)
        {
            DialogResult pregunta = MessageBox.Show("Aplicar cambios?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (pregunta == DialogResult.Yes)
            {
                ControladorCuentaUsuario.ModificarCuentaDesdeBackoffice(id, textBoxCambiarNombre.Text, textBoxCambiarApellido.Text, textBoxCambiarEmail.Text, textBoxCambiarTelefono.Text, textBoxFechaDeNacimiento.Text);
                MessageBox.Show("Cambios realizados con exito");
            }
            if (pregunta == DialogResult.No)
            {
                MessageBox.Show("No se han realizado los cambios");
            }
            dataGridViewInfoUser.DataSource = ControladorCuentaUsuario.Listar();
        }
        private void dataGridViewInfoUser_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewInfoUser.SelectedRows.Count > 0)
            {
                DataGridViewRow seleccion = dataGridViewInfoUser.SelectedRows[0];
                textBoxCambiarNombre.Text = seleccion.Cells[1].Value?.ToString();
                textBoxCambiarApellido.Text = seleccion.Cells[2].Value?.ToString();
                textBoxCambiarTelefono.Text = seleccion.Cells[3].Value?.ToString();
                textBoxCambiarEmail.Text = seleccion.Cells[4].Value?.ToString();
                textBoxFechaDeNacimiento.Text = seleccion.Cells[5].Value?.ToString();
                id = seleccion.Cells[0].Value?.ToString();
                
            }
        }
        
        
        

        private void button1_Click(object sender, EventArgs e)
        {
            VisualPost post = new VisualPost();
            post.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            VisualEventos veb = new VisualEventos();
            veb.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            VisualGrupos vgb = new VisualGrupos();
            vgb.Show();
        }
    }
}

