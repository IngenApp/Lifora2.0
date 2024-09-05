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
                dataGridViewPost.DataSource = ControladorPost.ListarPost();

                if (dataGridViewEventos.SelectedRows.Count > 0)
                    (dataGridViewEventos.DataSource as DataTable).DefaultView.RowFilter = string.Format("id_cuenta LIKE '%{0}%'", id);
                (dataGridViewPost.DataSource as DataTable).DefaultView.RowFilter = string.Format("cuenta LIKE '%{0}%'", id);


            }
        }

        private void btnBlockThePost_Click(object sender, EventArgs e)
        {
            DialogResult pregunta = MessageBox.Show("Bloquear este Post?", "Estas seguro?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (pregunta == DialogResult.Yes)
            {
                if (dataGridViewPost.SelectedRows.Count > 0)
                {
                    DataGridViewRow seleccion = dataGridViewPost.SelectedRows[0];
                    int columna = 0;
                    var CellValue = seleccion.Cells[columna].Value;
                    string Id = CellValue.ToString();
                    int idPost = int.Parse(Id);
                    ControladorPost.DeshabilitarPost(idPost);
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
        private void btnUnlockThePost_Click(object sender, EventArgs e)
        {
            DialogResult pregunta = MessageBox.Show("Desbloquear este Post?", "Estas seguro?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (pregunta == DialogResult.Yes)
            {
                if (dataGridViewPost.SelectedRows.Count > 0)
                {
                    DataGridViewRow seleccion = dataGridViewPost.SelectedRows[0];
                    int columna = 0;
                    var CellValue = seleccion.Cells[columna].Value;
                    string Id = CellValue.ToString();
                    int idPost = int.Parse(Id);
                    ControladorPost.HabilitarPost(idPost);
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
                textBoxNuevaInfoEvento.Text = seleccion.Cells[2].Value?.ToString();
                textBoxNuevoLugarEvento.Text = seleccion.Cells[3].Value?.ToString();
                textBoxNuevaFechaEvento.Text = seleccion.Cells[4].Value?.ToString();

            }
        }
        private void BtnBloquearEvento_click(object sender, EventArgs e)
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
        private void BtnDesbloquearEvento_click(object sender, EventArgs e)
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
        private void BtnModificarEvento_Click_1(object sender, EventArgs e)
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
        private void btnCrearPost_Click(object sender, EventArgs e)
        {
            CrearPostBackoffice ceb = new CrearPostBackoffice();
            ceb.Show();
        }
        private void btnModificarPost_Click(object sender, EventArgs e)
        {
            DialogResult pregunta = MessageBox.Show("Aplicar cambios?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (pregunta == DialogResult.Yes)
            {
                DataGridViewRow seleccion = dataGridViewPost.SelectedRows[0];
                int columna = 0;
                var CellValue = seleccion.Cells[columna].Value;
                string id_post = CellValue.ToString();
                ControladorPost.ModificarPostBackoffice(textBoxPost.Text, textBoxIdPost.Text, textBoxIdCuenta.Text, textBoxFecha.Text, textBoxLike.Text);
                MessageBox.Show("Cambios realizados con exito");
            }
            if (pregunta == DialogResult.No)
            {
                MessageBox.Show("No se han realizado los cambios");
            }
            dataGridViewPost.DataSource = ControladorPost.ListarPost();
        }
        private void dataGridViewPost_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewPost.SelectedRows.Count > 0)
            {
                DataGridViewRow seleccion = dataGridViewPost.SelectedRows[0];
                textBoxPost.Text = seleccion.Cells[2].Value?.ToString();
                textBoxIdPost.Text = seleccion.Cells[0].Value?.ToString();
                textBoxIdCuenta.Text = seleccion.Cells[1].Value?.ToString();
                textBoxFecha.Text = seleccion.Cells[3].Value?.ToString();
                textBoxLike.Text = seleccion.Cells[4].Value?.ToString();
            }
        }
    }
}