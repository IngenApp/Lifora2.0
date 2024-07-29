using System;
using System.IO;
using System.Windows.Forms;
using Controladores;
using System.Data;

namespace Lifora
{
    public partial class backoffice : Form
    {

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
            
        }

        private void dataGridViewInfoUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtBoxSearch_TextChanged(object sender, EventArgs e)
        {
            (dataGridViewInfoUser.DataSource as DataTable).DefaultView.RowFilter = string.Format("email LIKE '%{0}%'", txtBoxSearch.Text);
        }

        
    }
}
