using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controladores;

namespace Lifora
{
    public partial class VisualCrearCuentaBackoffice : Form
    {
        public VisualCrearCuentaBackoffice()
        {
            InitializeComponent();
        }

        private void BotonCrearUsuario_Click(object sender, EventArgs e)
        {
            if (!txtBoxMail.Text.Equals("") && !txtBoxName.Text.Equals("") && !txtBoxSurname.Text.Equals("") && !txtBoxPhone.Text.Equals("") && !txtBoxPassword.Text.Equals("") && !txtBoxBirthday.Text.Equals(""))
            {
                if (txtBoxPassword.Text.Equals(txtBoxConfirmPassword.Text))
                {
                    ControladorCuentaUsuario.AltaCuentaUsuario(txtBoxName.Text, txtBoxSurname.Text, txtBoxBirthday.Text, txtBoxMail.Text, txtBoxPhone.Text, txtBoxPassword.Text);
                    MessageBox.Show("Cuenta creada con exito");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Las contrasenas no cohinciden");
                }
            }
            else
            {
                MessageBox.Show("Complete los campos");
            }
            txtBoxBirthday.Text = ("");
            txtBoxConfirmPassword.Text = ("");
            txtBoxMail.Text = ("");
            txtBoxPassword.Text = ("");
            txtBoxPhone.Text = ("");
            txtBoxSurname.Text = ("");
            txtBoxName.Text = ("");
        }
    }
}
