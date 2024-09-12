using Controladores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lifora
{
    public partial class ComentarPost : Form
    {
        private int idPost;
        private int idCuenta;
        public ComentarPost(int idPost, int idCuenta)
        {
            InitializeComponent();
            this.idPost = idPost;
            this.idCuenta = idCuenta;
        }
        private void btnComentarPost_Click(object sender, EventArgs e)
        {
            if (textBoxComentarPost.Text != "")
            {
                try
                {
                    string comentario = textBoxComentarPost.Text;
                    ControladorPost.ComentarPost(idPost, idCuenta, comentario);
                    MessageBox.Show("Comentario creado con éxito");
                    textBoxComentarPost.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }
    }
}