﻿using System;
using System.IO;
using System.Windows.Forms;

namespace Lifora
{
    public partial class backoffice : Form
    {
        private string rutaArchivo = @"C:\Users\Andres\Desktop\Proyecto LiForA\Red_Social\Lifora\Persistencia\archivo.txt";

        public backoffice()
        {
            InitializeComponent();
        }

        private void btnSearchUser_Click(object sender, EventArgs e)
        {
            string mail = txtBoxSearch.Text.Trim();
            string[] userData = SearchUser(mail);

            if (userData == null)
            {
                MessageBox.Show("Usuario no encontrado.");
                return;
            }
            
                MessageBox.Show("Usuario encontrado.");
                DisplayData(userData);

        }
        private string[] SearchUser(string mail)
        {
            try
            {
                using (StreamReader sr = new StreamReader(rutaArchivo))
                {
                    string linea;
                    while ((linea = sr.ReadLine()) != null)
                    {
                        string[] datos = linea.Split(',');
                        if (datos.Length >= 3 && datos[1].Trim() == mail)
                        {
                            return datos;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar usuario: {ex.Message}");
            }
            return null;
        }
        private void DisplayData(string[] userData)
        {
            dataGridViewInfoUser.Rows.Clear();
            dataGridViewInfoUser.Columns.Add("Data_Register", "Data Register");
            dataGridViewInfoUser.Columns.Add("User_Information", "User Information"); 

            dataGridViewInfoUser.Rows.Add("Mail", userData[1].Trim());
            dataGridViewInfoUser.Rows.Add("Name", userData[2].Trim());
            dataGridViewInfoUser.Rows.Add("Surname", userData[3].Trim());
            dataGridViewInfoUser.Rows.Add("Phone", userData[4].Trim());
            dataGridViewInfoUser.Rows.Add("Year", userData[5].Trim());
            dataGridViewInfoUser.Rows.Add("Month", userData[6].Trim());
            dataGridViewInfoUser.Rows.Add("Day", userData[7].Trim());
        }

        private void btnBlockTheUser_Click(object sender, EventArgs e)
        {
            jasfjbjasnlcknlKNASclkn;
        }

    }
}
