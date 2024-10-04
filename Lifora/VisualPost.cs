using System;
using System.IO;
using System.Windows.Forms;
using Controladores;
using System.Data;
using System.Collections.Generic;

namespace Lifora
{
    public partial class VisualPost : Form
    {
        

        public VisualPost()
        {
            InitializeComponent();        
            dataGridViewPost.DataSource = ControladorPost.ListarPost();
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

        private void btnCrearPost_Click(object sender, EventArgs e)
        {
            CrearPostBackoffice cpb = new CrearPostBackoffice();
            cpb.Show();
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

        private void txtBoxSearch_TextChanged(object sender, EventArgs e)
        {
            {
                if (dataGridViewPost.SelectedRows.Count > 0)
                    (dataGridViewPost.DataSource as DataTable).DefaultView.RowFilter = string.Format("cuenta LIKE '%{0}%'", txtBoxSearchIDCuenta.Text);
            }
        }

        private void textBuscarPostId_TextChanged(object sender, EventArgs e)
        {
            if (dataGridViewPost.SelectedRows.Count > 0)
                (dataGridViewPost.DataSource as DataTable).DefaultView.RowFilter = string.Format("id LIKE '%{0}%'", textBuscarPostId.Text);

        }

        private void textBuscarContenidoPost_TextChanged(object sender, EventArgs e)
        {
            if (dataGridViewPost.SelectedRows.Count > 0)
                (dataGridViewPost.DataSource as DataTable).DefaultView.RowFilter = string.Format("post LIKE '%{0}%'", textBuscarContenidoPost.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
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

        private void buttonHabilitarComentario_Click(object sender, EventArgs e)
        {
            DialogResult pregunta = MessageBox.Show("Desbloquear este comentario?", "Estas seguro?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (pregunta == DialogResult.Yes)
            {
                if (dataGridViewPost.SelectedRows.Count > 0)
                {
                    DataGridViewRow seleccion = dataGridViewComentarios.SelectedRows[0];
                    int columna = 0;
                    var CellValue = seleccion.Cells[columna].Value;
                    string Id = CellValue.ToString();
                    int idComentario = int.Parse(Id);
                    ControladorPost.HabilitarComentario(idComentario);
                    dataGridViewPost.DataSource = ControladorPost.ListarPost();
                }
                if (dataGridViewComentarios.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Debes seleccionar un comentario");
                }
            }
            if (pregunta == DialogResult.No)
            {
                MessageBox.Show("No se ah desbloqueado el comentario");
            }
        }

        private void ButtonDeshabilitarComentario_Click(object sender, EventArgs e)
        {
            DialogResult pregunta = MessageBox.Show("Bloquear este comentario?", "Estas seguro?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (pregunta == DialogResult.Yes)
            {
                if (dataGridViewComentarios.SelectedRows.Count > 0)
                {
                    DataGridViewRow seleccion = dataGridViewComentarios.SelectedRows[0];
                    int columna = 0;
                    var CellValue = seleccion.Cells[columna].Value;
                    string Id = CellValue.ToString();
                    int idComentario = int.Parse(Id);
                    ControladorPost.DeshabilitarComentario(idComentario);
                    dataGridViewPost.DataSource = ControladorPost.ListarPost();
                }
                if (dataGridViewComentarios.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Debes seleccionar un comentario");
                }
            }
            if (pregunta == DialogResult.No)
            {
                MessageBox.Show("No se ah bloqueado el comentario");
            }

        }
    }
}
