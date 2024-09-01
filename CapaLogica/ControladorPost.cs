using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using System.Data;

namespace Controladores
{
    public class ControladorPost
    {
        public string TextoPost { get; set; }
        public bool EstaHabilitado { get; set; }

        public static List<string> ListarPost(int idUsuario)
        {
            List<string> listaPosts = new List<string>();
            ModeloPost ListarPost = new ModeloPost();
            foreach (ModeloPost p in ListarPost.ObtenerPostUsuario(idUsuario))
            {
                string itemText = $"ID Post: {p.idPost}, Texto: {p.post}, Likes: {p.like}";
                listaPosts.Add(itemText);
            }

            return listaPosts;
        }

        public static void DeshabilitarPost(int id)
        {
            ModeloPost Post = new ModeloPost();
            Post.idCuenta = id;
            Post.DeshabilitarPost();
        }
        public static void HabilitarPost(int id)
        {
            ModeloPost Post = new ModeloPost();
            Post.idCuenta = id;
            Post.HabilitarPost();
        }
        public static int ExtraerIdPost(string textoItem)
        {
            try
            {
                string[] partes = textoItem.Split(',');
                string idParte = partes[0];
                string idString = idParte.Split(':')[1].Trim();

                return int.Parse(idString);
            }
            catch (Exception ex)
            {
                Console.Write("Error al extraer el ID del post. Verifique el formato del texto.", "Error");
                return -1;
            }
        }

    }
}
