using System;
using System.IO;
using System.Windows.Forms;
using Controladores;
using System.Data;
using System.Collections.Generic;



namespace Lifora
{
    public partial class Mensajes : Form
    {
        public Mensajes()
        {
            InitializeComponent();
            dataGridView1.DataSource = ControladorMensajes.MostrarChat(1);
            dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView2.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dataGridView1.Rows[e.RowIndex];
                string apodoPerfil2 = row.Cells["Apodo"].Value.ToString(); 

                int idPerfil2 = ControladorCuentaUsuario.ObtenerIdApodo(apodoPerfil2); 

                if (idPerfil2 != -1) // Si se encontró el perfil
                {

                   
                    dataGridView2.DataSource = ControladorMensajes.MostrarMensajes(1, idPerfil2);
                    if (dataGridView2.Rows.Count > 0)
                    {
                        // Desplaza hacia la última fila
                        dataGridView2.FirstDisplayedScrollingRowIndex = dataGridView2.Rows.Count - 1;
                    }
                }
                else
                {
                    MessageBox.Show("No se encontró el perfil con el apodo: " + apodoPerfil2);
                }
            }
        }
    }
}
