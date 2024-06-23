using System;
using System.IO;
using System.Windows.Forms;
using CapaDeDatos;
namespace Lifora
{
    public partial class login : Form
    {
        private string rutaArchivo = @"C:\Users\Andres\Desktop\Proyecto LiForA\Red_Social\Lifora\Persistencia\archivo.txt";
        public login()
        {
            InitializeComponent();

            for (int year = 1940; year <= 2040; year++)
            {
                CmbBoxYear.Items.Add(year.ToString());
            }
            CmbBoxYear.SelectedIndex = CmbBoxYear.Items.Count - 51;          
            string[] meses = {
                "Enero", "Febrero", "Marzo", "Abril",
                "Mayo", "Junio", "Julio", "Agosto",
                "Septiembre", "Octubre", "Noviembre", "Diciembre"
            };
            CmbBoxMonth.Items.AddRange(meses);
            CmbBoxMonth.SelectedIndexChanged += CmbBoxMonth_SelectedIndexChanged;
            CompleteDays(1); 
            CmbBoxMonth.SelectedIndex = 0;
            CmBoxDay.SelectedIndex = 0;
        }
        private void CmbBoxMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indiceMes = CmbBoxMonth.SelectedIndex + 1;

            CompleteDays(indiceMes + 1); 
        }
        private void CompleteDays(int mes)
        {
            int cantidadDias = DateTime.DaysInMonth(DateTime.Now.Year, mes); 
            CmBoxDay.Items.Clear();
            for (int dia = 1; dia <= cantidadDias; dia++)
            {
                CmBoxDay.Items.Add(dia.ToString());
            }
            CmBoxDay.SelectedIndex = 0;
        }
        private void btnAccess_Click(object sender, EventArgs e)
    {
            backoffice backoffice = new backoffice();
            string mail = loginMail.Text.Trim();
            string password = loginPassword.Text;
            if (VerifyAcces(mail, password))
            {
                MessageBox.Show("Acceso permitido. ¡Bienvenido!");
                backoffice.FormClosed += (s, args) => this.Show();
                loginMail.ResetText();
                loginPassword.ResetText();
                this.Hide();
                backoffice.Show();
            }
            if (!VerifyAcces(mail, password))
            {
                MessageBox.Show("Acceso denegado. Verifica tus credenciales.");
            }
        }
        private bool VerifyAcces(string mail, string password)
        {
            try
            {
                using (StreamReader sr = new StreamReader(rutaArchivo))
                {
                    string linea;
                    while ((linea = sr.ReadLine()) != null)
                    {
                        string[] datos = linea.Split(',');
                        if (datos.Length >= 3 && datos[1].Trim() == mail && datos[2].Trim() == password)
                        {
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al verificar acceso: {ex.Message}");
            }
            return false;
        }
        private void btnRegister_Click(object sender, EventArgs e)
        {
            string mail = txtBoxMail.Text.Trim();
            string password = txtBoxPassword.Text;
            string confirmPassword = txtBoxConfirmPassword.Text;
            string name = txtBoxName.Text;
            string surname = txtBoxSurname.Text;
            string phone = txtBoxPhone.Text;
            string age = CmbBoxYear.SelectedItem?.ToString();
            string month = CmbBoxMonth.SelectedItem?.ToString();
            string day = CmBoxDay.SelectedItem?.ToString();
            if (password != confirmPassword)
            {
                MessageBox.Show("Las contraseñas no coinciden. Por favor, verifica.");
                return;
            }
            if (!EsNumero(phone))
            {
                MessageBox.Show("El teléfono debe contener solo números.");
                return;
            }
                string datosNuevos = $"{mail}, {password}, {name}, {surname}, {phone}, {age}, {month}, {day}";
            if (!CamposCompletos())
            {
                MessageBox.Show("Debe rellenar todos los campos para registrarce.");
                return;
            }
            if (MailRegister(mail))
            {
                MessageBox.Show("El correo electrónico ya está registrado.");
                return;
            }
            if (TelefonoRegistrado(phone))
            {
                MessageBox.Show("El número de teléfono ya está registrado.");
                return;
            }
            try
                {
                    Controlador.Create(datosNuevos);
                    MessageBox.Show("Usuario registrado exitosamente.");
                    LimpiarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al registrar usuario: {ex.Message}");
                } 
        }
        private bool MailRegister(string mail)
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
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al verificar correo registrado: {ex.Message}");
            }
            return false;
        }
        private bool TelefonoRegistrado(string phone)
        {
            try
            {
                using (StreamReader sr = new StreamReader(rutaArchivo))
                {
                    string linea;
                    while ((linea = sr.ReadLine()) != null)
                    {
                        string[] datos = linea.Split(',');
                        if (datos.Length >= 6 && datos[5].Trim() == phone.Trim())
                        {
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al verificar Teléfono registrado: {ex.Message}");
            }
            return false;
        }
        private bool CamposCompletos()
        {
            if (string.IsNullOrWhiteSpace(txtBoxMail.Text) ||
                string.IsNullOrWhiteSpace(txtBoxPassword.Text) ||
                string.IsNullOrWhiteSpace(txtBoxConfirmPassword.Text) ||
                string.IsNullOrWhiteSpace(txtBoxName.Text) ||
                string.IsNullOrWhiteSpace(txtBoxSurname.Text) ||
                string.IsNullOrWhiteSpace(txtBoxPhone.Text) ||
                CmbBoxYear.SelectedItem == null ||
                CmbBoxMonth.SelectedItem == null ||
                CmBoxDay.SelectedItem == null)
            {
                return false;
            }
            return true;
        }
        private bool EsNumero(string texto)
        {
            foreach (char c in texto)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }
        private void LimpiarCampos()
        {
            txtBoxMail.Text = "";
            txtBoxPassword.Text = "";
            txtBoxConfirmPassword.Text = "";
            txtBoxName.Text = "";
            txtBoxSurname.Text = "";
            txtBoxPhone.Text = "";
            CmbBoxYear.SelectedIndex = -1;
            CmbBoxMonth.SelectedIndex = -1;
            CmBoxDay.SelectedIndex = -1;
        }
        private void txtBoxPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Cancelar la tecla presionada
            }
        }
    }
}

