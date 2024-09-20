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
                string id = seleccion.Cells[0].Value?.ToString();
                dataGridViewGrupos.DataSource = ControladorGrupos.ListarGrupos();
                dataGridViewEventos.DataSource = ControladorEventos.ListarEventos();
                dataGridViewPost.DataSource = ControladorPost.ListarPost();
                if (dataGridViewGrupos.SelectedRows.Count > 0)
                    (dataGridViewGrupos.DataSource as DataTable).DefaultView.RowFilter = string.Format("idCuenta LIKE '%{0}%'", id);
                if (dataGridViewEventos.SelectedRows.Count > 0)
                    (dataGridViewEventos.DataSource as DataTable).DefaultView.RowFilter = string.Format("id_cuenta LIKE '%{0}%'", id);
                if (dataGridViewPost.SelectedRows.Count > 0)
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
                    dataGridViewPost.DataSource = ControladorPost.ListarPost();
                }
                if (dataGridViewPost.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Debes seleccionar un Post");
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
                    dataGridViewPost.DataSource = ControladorPost.ListarPost();
                }
                if (dataGridViewPost.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Debes seleccionar un Post");
                }
            }
            if (pregunta == DialogResult.No)
            {
                MessageBox.Show("No se ah bloqueado el Post");
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
            CrearPostBackoffice cpb = new CrearPostBackoffice();
            cpb.Show();
        }
        private void btnModificarPost_Click(object sender, EventArgs e)
        {
            DialogResult pregunta = MessageBox.Show("Aplicar cambios?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (pregunta != DialogResult.Yes)
            {
                MessageBox.Show("No se han realizado los cambios");
                return;
            }
                DataGridViewRow seleccion = dataGridViewPost.SelectedRows[0];
                int columna = 0;
                var CellValue = seleccion.Cells[columna].Value;
                string id_post = CellValue.ToString();
                ControladorPost.ModificarPostBackoffice(textBoxPost.Text, textBoxIdPost.Text, textBoxIdCuenta.Text, textBoxFecha.Text, textBoxLike.Text);
                MessageBox.Show("Cambios realizados con exito");           
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
                int idPost = Convert.ToInt32(seleccion.Cells[0].Value);
                dataGridViewComentarios.DataSource = ControladorPost.ListarComentarios(idPost);
            }
        }
        private void btnComentarPost_Click(object sender, EventArgs e)
        {
            if (dataGridViewPost.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un post para comentar");
                return;
            }
            DataGridViewRow seleccion = dataGridViewPost.SelectedRows[0];
            int idPost = Convert.ToInt32(seleccion.Cells["id"].Value);
            int idCuenta = Convert.ToInt32(seleccion.Cells["cuenta"].Value);
            ComentarPost cp = new ComentarPost(idPost, idCuenta);
            cp.Show();
        }
        private void btnLike_Click(object sender, EventArgs e)
        {
            if (dataGridViewPost.SelectedRows.Count > 0)
            {
                DataGridViewRow seleccion = dataGridViewPost.SelectedRows[0];
                int idPost = Convert.ToInt32(seleccion.Cells[0].Value); 
                int idCuenta = Convert.ToInt32(seleccion.Cells[1].Value);
                ControladorPost.DarLike(idPost, idCuenta);
                dataGridViewComentarios.DataSource = ControladorPost.ListarPost();
            }
        }
        private void btnCrearGrupo_Click(object sender, EventArgs e)
        {
            CrearGrupoBackoffice cgb = new CrearGrupoBackoffice();
            cgb.Show();
        }
        private void btnModificarGrupo_Click(object sender, EventArgs e)
        {

            DialogResult pregunta = MessageBox.Show("Aplicar cambios?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (pregunta != DialogResult.Yes)
            {
                MessageBox.Show("No se han realizado los cambios");
                return;
            }
            DataGridViewRow seleccion = dataGridViewGrupos.SelectedRows[0];
            int columna = 0;
            var CellValue = seleccion.Cells[columna].Value;
            int idGrupo = Int32.Parse(CellValue.ToString());
            string nombre = textBoxNombreGrupo.Text;
            string descripcion = textBoxIDescripcionGrupo.Text;
            ControladorGrupos.ModificarGrupo(idGrupo, nombre, descripcion);
            dataGridViewGrupos.DataSource = ControladorGrupos.ListarGrupos();
        }
        private void btnBloquearGrupo_Click(object sender, EventArgs e)
        {
            DialogResult pregunta = MessageBox.Show("Bloquear este Grupo?", "Estas seguro?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (pregunta == DialogResult.Yes)
            {
                if (dataGridViewGrupos.SelectedRows.Count > 0)
                {
                    DataGridViewRow seleccion = dataGridViewGrupos.SelectedRows[0];
                    int columna = 0;
                    var CellValue = seleccion.Cells[columna].Value;
                    string Id = CellValue.ToString();
                    int idGrupo = int.Parse(Id);
                    ControladorGrupos.BloquearGrupo(idGrupo);
                    dataGridViewGrupos.DataSource = ControladorGrupos.ListarGrupos();
                }
                if (dataGridViewGrupos.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Debes seleccionar un Grupo");
                }
            }
            if (pregunta == DialogResult.No)
            {
                MessageBox.Show("No se ah bloqueado el Grupos");
            }
            dataGridViewGrupos.DataSource = ControladorGrupos.ListarGrupos();
        }
        private void btnHabilitarGrupo_Click(object sender, EventArgs e)
        {
            DialogResult pregunta = MessageBox.Show("Desbloquear este Grupo?", "Estas seguro?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (pregunta == DialogResult.Yes)
            {
                if (dataGridViewGrupos.SelectedRows.Count > 0)
                {
                    DataGridViewRow seleccion = dataGridViewGrupos.SelectedRows[0];
                    int columna = 0;
                    var CellValue = seleccion.Cells[columna].Value;
                    string Id = CellValue.ToString();
                    int idGrupo = int.Parse(Id);
                    ControladorGrupos.HabilitarGrupo(idGrupo);
                    dataGridViewGrupos.DataSource = ControladorGrupos.ListarGrupos();
                }
                if (dataGridViewGrupos.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Debes seleccionar un Grupo");
                }
            }
            if (pregunta == DialogResult.No)
            {
                MessageBox.Show("No se ah bloqueado el Grupo");
            }
            dataGridViewGrupos.DataSource = ControladorGrupos.ListarGrupos();
        }
    }
}

