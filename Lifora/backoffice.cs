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
        string id;

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
                string id = seleccion.Cells[0].Value?.ToString();
                dataGridViewEventos.DataSource = ControladorEventos.ListarEventos();
                buscarPost();
                if (dataGridViewEventos.SelectedRows.Count > 0)
                    (dataGridViewEventos.DataSource as DataTable).DefaultView.RowFilter = string.Format("id_cuenta LIKE '%{0}%'", id);
               
            }         
        }

        private void buscarPost()
        {
            try
            {

                if (dataGridViewInfoUser.SelectedRows.Count > 0)
            {
                DataGridViewRow seleccion = dataGridViewInfoUser.SelectedRows[0];
                int columna = 0;
                var CellValue = seleccion.Cells[columna].Value;
                string Id = CellValue.ToString();
                int id = int.Parse(Id);
                dataGridViewInfoUser.DataSource = ControladorPost.ListarPost(id);
            }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al buscar posts del usuario: {ex.Message}");
            }
        }
        private void btnBlockThePost_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult pregunta = MessageBox.Show("¿Bloquear este Post?", "¿Estás seguro?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (pregunta == DialogResult.No)
                {
                    Console.WriteLine("No se ha bloqueado el Post.");
                    return;
                }
                if (dataGridViewPost.SelectedRows.Count == 0)
                {
                    Console.WriteLine("Debes seleccionar un Post.");
                    return;
                }

                DataGridViewRow seleccion = dataGridViewPost.SelectedRows[0];
                int id = Convert.ToInt32(seleccion.Cells[0].Value);
                ControladorPost.DeshabilitarPost(id);
                int idUsuario = Convert.ToInt32(dataGridViewInfoUser.SelectedRows[0].Cells[0].Value);
                dataGridViewPost.DataSource = ControladorPost.ListarPost(idUsuario);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al bloquear el post: {ex.Message}");
            }
        }
        private void btnUnlockThePost_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult pregunta = MessageBox.Show("¿Habilitar este Post?", "¿Estás seguro?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (pregunta == DialogResult.No)
                {
                    MessageBox.Show("No se ha habilitado el Post.");
                    return;
                }
                if (dataGridViewPost.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Debes seleccionar un Post.");
                    return;
                }

                DataGridViewRow seleccion = dataGridViewPost.SelectedRows[0];
                int id = Convert.ToInt32(seleccion.Cells[0].Value);
                ControladorPost.HabilitarPost(id);
                int idUsuario = Convert.ToInt32(dataGridViewInfoUser.SelectedRows[0].Cells[0].Value);
                dataGridViewPost.DataSource = ControladorPost.ListarPost(idUsuario);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al habilitar el post: {ex.Message}");
            }
        }


        private void button1_Click(object sender, EventArgs e)
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
                textBoxNuevaInfoEvento.Text = seleccion.Cells[2].Value?.ToString();
                textBoxNuevoLugarEvento.Text = seleccion.Cells[3].Value?.ToString();
                textBoxNuevaFechaEvento.Text = seleccion.Cells[4].Value?.ToString();

            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult pregunta = MessageBox.Show("Aplicar cambios?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (pregunta == DialogResult.Yes)
            {
                DataGridViewRow seleccion = dataGridViewEventos.SelectedRows[0];
                int columna = 0;
                var CellValue = seleccion.Cells[columna].Value;
                string id_evento = CellValue.ToString();
                ControladorEventos.ModificarEventoBackoffice(id_evento, textBoxNuevoNombreEvento.Text, textBoxNuevaInfoEvento.Text, textBoxNuevoLugarEvento.Text, textBoxNuevaFechaEvento.Text);
                MessageBox.Show("Cambios realizados con exito");
            }
            if (pregunta == DialogResult.No)
            {
                MessageBox.Show("No se han realizado los cambios");
            }
            dataGridViewInfoUser.DataSource = ControladorCuentaUsuario.Listar();
        }
        private void button2_Click(object sender, EventArgs e)
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
                    dataGridViewInfoUser.DataSource = ControladorCuentaUsuario.Listar();
                }
                if (dataGridViewInfoUser.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Debes seleccionar un evento");
                }
            }
            if (pregunta == DialogResult.No)
            {
                MessageBox.Show("No se ah bloqueado el evento");
            }
        }
        private void button4_Click(object sender, EventArgs e)
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
                    dataGridViewInfoUser.DataSource = ControladorCuentaUsuario.Listar();
                }
                if (dataGridViewInfoUser.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Debes seleccionar un evento");
                }
            }
            if (pregunta == DialogResult.No)
            {
                MessageBox.Show("No se ah Habilitado el evento");
            }
        }

      
    }
}