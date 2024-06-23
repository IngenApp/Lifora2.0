using System;
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
                        if (datos.Length >= 9 && datos[1].Trim() == mail) 
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
            listViewDataUser.Items.Clear();

            ListViewItem item = new ListViewItem("Mail");
            item.SubItems.Add(userData[1].Trim());
            listViewDataUser.Items.Add(item);

            item = new ListViewItem("Name");
            item.SubItems.Add(userData[3].Trim());
            listViewDataUser.Items.Add(item);

            item = new ListViewItem("Surname");
            item.SubItems.Add(userData[4].Trim());
            listViewDataUser.Items.Add(item);

            item = new ListViewItem("Phone");
            item.SubItems.Add(userData[5].Trim());
            listViewDataUser.Items.Add(item);

            item = new ListViewItem("Year");
            item.SubItems.Add(userData[6].Trim());
            listViewDataUser.Items.Add(item);

            item = new ListViewItem("Month");
            item.SubItems.Add(userData[7].Trim());
            listViewDataUser.Items.Add(item);

            item = new ListViewItem("Day");
            item.SubItems.Add(userData[8].Trim());
            listViewDataUser.Items.Add(item);
        }

    }
}
