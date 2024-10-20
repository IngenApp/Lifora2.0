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
       string idPost;
        public ComentarPost(string idPost)
        {
            InitializeComponent();
            this.idPost = idPost;

        }
        private void btnComentarPost_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text != "")
            {
                try
                {
                    ControladorPost.ComentarPost(idPost, textBox1.Text, richTextBox1.Text);
                    MessageBox.Show("Comentario creado con éxito");
                    richTextBox1.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }
    }
}