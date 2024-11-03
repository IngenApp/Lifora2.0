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
    public partial class Reportar : Form
    {
        public int idPost=0, idComentario=0, idEvento=0;
        public string nombreGrupo, Apodo;
        public Reportar()
        {
            InitializeComponent();
            
        }

        private void btnReportarSi_Click(object sender, EventArgs e)
        {
            //Reportar
            if(idPost != 0)
            {
                //ReportarPost
            }
            if(idComentario != 0)
            {
                //ReportarComentario
            }
            if (!string.IsNullOrEmpty(nombreGrupo))
            {
                //ReportarGrupo
            }
            if (!string.IsNullOrEmpty(Apodo))
            {
                //reportarPerfil
            }
                if (idEvento != 0)
            {
                //reportarEvento
            }
        }

        private void btnReportarNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
