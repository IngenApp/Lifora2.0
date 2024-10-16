﻿using System;
using System.IO;
using System.Windows.Forms;
using Controladores;
using InterfazUsuario;




namespace Lifora
{
    public partial class login : Form
    {
       
        
        public login()
        {
            InitializeComponent();
        }

        private void BotonCrearUsuario_Click(object sender, EventArgs e)
        {
            //if se soluciona con try y catch por error en insert en base de datos
            if (!txtBoxMail.Text.Equals("")&&!txtBoxName.Text.Equals("")&&!txtBoxSurname.Text.Equals("")&&!txtBoxPhone.Text.Equals("")&&!txtBoxPassword.Text.Equals("")&&!txtBoxBirthday.Text.Equals(""))
            {
                if (txtBoxPassword.Text.Equals(txtBoxConfirmPassword.Text))
                {
                    ControladorCuentaUsuario.AltaCuentaUsuario(txtBoxName.Text, txtBoxSurname.Text, Int32.Parse(txtBoxPhone.Text), txtBoxMail.Text, txtBoxBirthday.Text, txtBoxPassword.Text);
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

        private void buttonBackOffice_Click(object sender, EventArgs e)
        {
            if(ControladorCuentaUsuario.Login(textBoxMail.Text, textBoxPassword.Text) == true)
            {
            backoffice backoff = new backoffice();
            this.Enabled = false;
            backoff.Show();
            backoff.FormClosed += (s, args) => this.Enabled = true;
                 
            }
            else
            {
                MessageBox.Show("Credenciales incorrectas");
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Login Login = new Login();
            this.Enabled = false;
            Login.Show();
        }
    }
    
}

