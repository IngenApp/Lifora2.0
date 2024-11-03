using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;
using InterfazUsuario.Lenguas;
using InterfazUsuario.Properties;

namespace InterfazUsuario
{
    
    public class GestorDePosts
    {
        private readonly Panel _panelTexto;
        private readonly Panel _panelImagen;
        private readonly Panel _panelAudio;
        private readonly Panel _panelVideo;

        public GestorDePosts(Panel panelTexto, Panel panelImagen, Panel panelAudio, Panel panelVideo)
        {
            _panelTexto = panelTexto;
            _panelImagen = panelImagen;
            _panelAudio = panelAudio;
            _panelVideo = panelVideo;
        }

        public void AgregarPostTexto(Form postTextoMostrar)
        {
            postTextoMostrar.TopLevel = false;
            postTextoMostrar.Dock = DockStyle.Top;

            _panelTexto.Controls.Add(postTextoMostrar);
            _panelTexto.Tag = postTextoMostrar;

            postTextoMostrar.Show();
        }

        public void PostTexto(List<string> apodo, List<string> descripcion, List<string> cantidadLikes, List<string> cantidadComentarios)
        {
            _panelTexto.Controls.Clear();
           
            for (int i = 0; i < apodo.Count; i++)
            {
                PostTextoMostrar form = new PostTextoMostrar(apodo[i], descripcion[i], cantidadLikes[i], cantidadComentarios[i]);
                AgregarPostTexto(form);
            }
        }

        public void AgregarPostImagen(Form postImagenMostrar)
        {
            postImagenMostrar.TopLevel = false;
            postImagenMostrar.Dock = DockStyle.None;

            int count = _panelImagen.Controls.Count;
            int x = (count % 2) * postImagenMostrar.Width;
            int y = (count / 2) * postImagenMostrar.Height;

            postImagenMostrar.Location = new Point(x, y);
            _panelImagen.Controls.Add(postImagenMostrar);
            _panelImagen.Tag = postImagenMostrar;

            postImagenMostrar.Show();
        }

        public void CargarImagenes(List<string> apodos, List<string> descripcion, List<string> rutasImagenes, List<string> cantidadLikes, List<string> cantidadComentarios)
        {
            _panelImagen.Controls.Clear();

            for (int i = 0; i < apodos.Count; i++)
            {
                PostImagenMostrar form = new PostImagenMostrar(apodos[i], descripcion[i], rutasImagenes[i], cantidadLikes[i], cantidadComentarios[i]);
                AgregarPostImagen(form);
            }
        }
        public void AgregarPostAudio(Form postAudioMostrar)
        {
            postAudioMostrar.TopLevel = false;
            postAudioMostrar.Dock = DockStyle.None;

            int count = _panelAudio.Controls.Count;
            int x = (count % 2) * postAudioMostrar.Width;
            int y = (count / 2) * postAudioMostrar.Height;

            postAudioMostrar.Location = new Point(x, y);
            _panelAudio.Controls.Add(postAudioMostrar);
            _panelAudio.Tag = postAudioMostrar;

            postAudioMostrar.Show();
        }

        public void CargarAudios(List<string> apodos, List<string> idAudios)
        {
            _panelAudio.Controls.Clear();

            for (int i = 0; i < apodos.Count; i++)
            {
                PostAudioMostrar form = new PostAudioMostrar(apodos[i], idAudios[i]);
                AgregarPostAudio(form);
            }
        }
        public void AgregarPostVideo(Form postVideoMostrar)
        {
            postVideoMostrar.TopLevel = false;
            postVideoMostrar.Dock = DockStyle.None;

            int count = _panelVideo.Controls.Count;
            int x = (count % 2) * postVideoMostrar.Width;
            int y = (count / 2) * postVideoMostrar.Height;

            postVideoMostrar.Location = new Point(x, y);
            _panelVideo.Controls.Add(postVideoMostrar);
            _panelVideo.Tag = postVideoMostrar;

            postVideoMostrar.Show();
        }

        public void CargarVideos(List<string> apodo, List<string> idVideo)
        {
            _panelVideo.Controls.Clear();

            for (int i = 0; i < apodo.Count; i++)
            {
                PostVideoMostrar form = new PostVideoMostrar(apodo[i], idVideo[i]);
                AgregarPostVideo(form);
            }
        }
    }



}


