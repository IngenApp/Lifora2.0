using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InterfazUsuario
{
    public partial class PerfilPrincipal : Form
    {
        public Form inicio;
        string rutaImagen;
        public PerfilPrincipal()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            inicio.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AbrirPost();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                rutaImagen = openFileDialog.FileName;
                DialogResult result = MessageBox.Show("Esta seguro que desea cambiar su foto de perfil?", "Confirmar?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {

                    MessageBox.Show("Imagen confirmada: " + rutaImagen);
                    //guardar foto perfil
                }
                else
                {
                    MessageBox.Show("Selección cancelada.");
                }

            }
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //cantidad de gente que me sigo
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // cantidad de gente que sigo
        }

        private void PerfilPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            inicio.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            InformacionUsuario info = new InformacionUsuario();
            info.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AbrirMensajes();
        }
        private void AbrirMensajes()
        {
            if (Mensajes.MensajeInstancia == null || Mensajes.MensajeInstancia.IsDisposed)
            {
                Mensajes.MensajeInstancia = new Mensajes();
                Mensajes.MensajeInstancia.Show();
            }
            else
            {
                Mensajes.MensajeInstancia.WindowState = FormWindowState.Normal;
                Mensajes.MensajeInstancia.BringToFront();
            }
        }
        private void AbrirPost()
        {
            if (CrearPost.PostInstancia == null || CrearPost.PostInstancia.IsDisposed)
            {
                CrearPost.PostInstancia = new CrearPost();
                CrearPost.PostInstancia.Show();
            }
            else
            {
                CrearPost.PostInstancia.WindowState = FormWindowState.Normal; 
                CrearPost.PostInstancia.BringToFront();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AbrirEvento();
        }
        private void AbrirEvento()
        {
            if (CrearEvento.eventoInstancia == null || CrearEvento.eventoInstancia.IsDisposed)
            {
                CrearEvento.eventoInstancia = new CrearEvento();
                CrearEvento.eventoInstancia.Show();
            }
            else
            {
                CrearEvento.eventoInstancia.WindowState = FormWindowState.Normal;
                CrearEvento.eventoInstancia.BringToFront();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (GruposMenu.menuGruposInstancia == null || GruposMenu.menuGruposInstancia.IsDisposed)
            {
                GruposMenu.menuGruposInstancia = new GruposMenu();
                GruposMenu.menuGruposInstancia.Show();
            }
            else
            {
                GruposMenu.menuGruposInstancia.WindowState = FormWindowState.Normal;
                GruposMenu.menuGruposInstancia.BringToFront();
            }
        }
        private void AgregarPostTexto(Form PostTextoMostrar)
        {
            PostTextoMostrar.TopLevel = false;
            PostTextoMostrar.Dock = DockStyle.Top;

            panel1.Controls.Add(PostTextoMostrar);
            panel1.Tag = PostTextoMostrar;
            PostTextoMostrar.Show();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            panel2.Hide();
            panel1.Show();
            panel3.Hide();
            panel4.Hide();
            //con los post de MI PERFIL
            List<String> Apodo = new List<string> { "Apodo", "Apodo", "Apodo" };
            List<String> contenido = new List<string> { "post1", "post2", "post3" };
            List<String> cantidadLikes = new List<string> { "10", "15", "20" };
            List<String> cantidadComentarios = new List<string> { "15", "20", "30" };
            for (int i = 0; i < Apodo.Count; i++)
            {
                PostTextoMostrar form = new PostTextoMostrar(Apodo[i], contenido[i], cantidadLikes[i], cantidadComentarios[i]);
                AgregarPostTexto(form);

            }
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Apodo Actualizar
        }
        private void AgregarPostImagen(Form PostImagenMostrar)
        {
            PostImagenMostrar.TopLevel = false;
            PostImagenMostrar.Dock = DockStyle.None;

            int count = panel2.Controls.Count;
            int x = (count % 2) * PostImagenMostrar.Width;
            int y = (count / 2) * PostImagenMostrar.Height;

            PostImagenMostrar.Location = new Point(x, y);
            panel2.Controls.Add(PostImagenMostrar);
            panel2.Tag = PostImagenMostrar;

            PostImagenMostrar.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            panel2.Show();
            panel3.Hide();
            panel4.Hide();
            //post de MI perfil
            List<String> Apodo = new List<string> { "Apodo", "Apodo", "Apodo", "Apodo" };
            panel2.Controls.Clear();

            for (int i = 0; i < Apodo.Count; i++)
            {
                PostImagenMostrar form = new PostImagenMostrar(Apodo[i]);
                AgregarPostImagen(form);
            }
        }
        private void AgregarPostVideo(Form PostVideoMostrar)
        {
            PostVideoMostrar.TopLevel = false;
            PostVideoMostrar.Dock = DockStyle.None;

            int count = panel3.Controls.Count;
            int x = (count % 2) * PostVideoMostrar.Width;
            int y = (count / 2) * PostVideoMostrar.Height;

            PostVideoMostrar.Location = new Point(x, y);
            panel3.Controls.Add(PostVideoMostrar);
            panel3.Tag = PostVideoMostrar;

            PostVideoMostrar.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            panel2.Hide();
            panel3.Show();
            panel4.Hide();
            List<String> Apodo = new List<string> { "Apodo1", "Apodo2", "Apodo3", "Apodo4" };
            panel3.Controls.Clear();

            for (int i = 0; i < Apodo.Count; i++)
            {
                PostVideoMostrar form = new PostVideoMostrar(Apodo[i]);
                AgregarPostVideo(form);
            }
        }
        private void AgregarPostAudio(Form PostAudioMostrar)
        {
            PostAudioMostrar.TopLevel = false;
            PostAudioMostrar.Dock = DockStyle.None;

            int count = panel4.Controls.Count;
            int x = (count % 2) * PostAudioMostrar.Width;
            int y = (count / 2) * PostAudioMostrar.Height;

            PostAudioMostrar.Location = new Point(x, y);
            panel4.Controls.Add(PostAudioMostrar);
            panel4.Tag = PostAudioMostrar;

            PostAudioMostrar.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            panel2.Hide();
            panel3.Hide();
            panel4.Show();
            List<String> Apodo = new List<string> { "Apodo1", "Apodo2", "Apodo3", "Apodo4" };
            panel4.Controls.Clear();

            for (int i = 0; i < Apodo.Count; i++)
            {
                PostAudioMostrar form = new PostAudioMostrar(Apodo[i]);
                AgregarPostAudio(form);
            }
        }
    }
}
