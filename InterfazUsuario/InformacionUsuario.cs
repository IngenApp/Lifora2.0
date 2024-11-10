using Newtonsoft.Json;
using RestSharp;
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
    public partial class InformacionUsuario : Form
    {
        public InformacionUsuario()
        {
            InitializeComponent();
            labelEmail.Text = DatosDePerfil.apodo;
            labelTelefono.Text = DatosDePerfil.telefono;
            labelNombre.Text = DatosDePerfil.nombre;
            labelApellido.Text = DatosDePerfil.apellido;
            labelFechaNac.Text = DatosDePerfil.fechaNacimiento;
        }

        private void CargarDatosPerfil()
        {
            string email = DatosDePerfil.email;
            Dictionary<string, string> perfil = ObtenerDatosPerfilDesdeApi(email);

            if (perfil == null)
            {
                MessageBox.Show("No se pudieron obtener los datos del perfil.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DatosDePerfil.idPerfil = int.Parse(perfil["idPerfil"]);
            DatosDePerfil.nombre = perfil["nombre"];
            DatosDePerfil.apellido = perfil["apellido"];
            DatosDePerfil.fechaNacimiento = perfil["fechaNacimiento"];
            DatosDePerfil.email = perfil["email"];
            DatosDePerfil.telefono = perfil["telefono"];
            DatosDePerfil.apodo = perfil["apodo"];
            DatosDePerfil.idFotoPerfil = perfil["idFotoPerfil"];
            DatosDePerfil.idioma = perfil["idioma"];
            DatosDePerfil.atributo1 = perfil["atributo1"];
            DatosDePerfil.atributo2 = perfil["atributo2"];

        }
        private Dictionary<string, string> ObtenerDatosPerfilDesdeApi(string email)
        {
            RestClient client = new RestClient("http://localhost:44331/");
            RestRequest request = new RestRequest($"/api/Usuario/{email}", Method.Get);
            request.AddHeader("Accept", "application/json");

            RestResponse response = client.Execute(request);
            return JsonConvert.DeserializeObject<Dictionary<string, string>>(response.Content);
        }

    }
}
