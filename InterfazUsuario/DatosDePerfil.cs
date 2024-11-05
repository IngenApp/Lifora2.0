using System;
using Newtonsoft.Json;
using RestSharp;

namespace InterfazUsuario
{
    public class DatosDePerfil
    {
        public int idPerfil { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string fechaNacimiento { get; set; }
        public string email { get; set; }
        public string telefono { get; set; }
        public string apodo { get; set; }
        public int? idFotoPerfil { get; set; }
        public string idioma { get; set; }
        public string atributo1 { get; set; }
        public string atributo2 { get; set; }

        public static DatosDePerfil ObtenerPerfilPorEmail(string email)
        {
            RestClient client = new RestClient("https://localhost:44331/");
            RestRequest request = new RestRequest($"/api/Usuario/Perfil/{email}", Method.Get);

            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");

            try
            {
                RestResponse response = client.Execute(request);

                if (!response.IsSuccessful)
                {
                    throw new Exception("No se encontró el perfil.");
                }

                return JsonConvert.DeserializeObject<DatosDePerfil>(response.Content);
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocurrió un error: {ex.Message}");
            }
        }



    }
}
