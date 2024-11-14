using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using System.Data;

namespace Controladores
{ 
   public class ControladorGrupos 
    {
        public static void CrearGrupo(int idCuenta, string nombre, string informacion)
        {
            ModeloGrupos grupo = new ModeloGrupos
            {
                idPerfil = idCuenta,
                nombre = nombre,
                informacion = informacion
            };
            grupo.CrearGrupo();
        }
        public static void UnirseAGrupo(int idGrupo, int idPerfil, bool silenciar)
        {
            ModeloGrupos grupo = new ModeloGrupos();
            grupo.UnirseAGrupo(idGrupo, idPerfil, silenciar);
        }
        public static List<string> ObtenerApodoDeIntegrantes(int idGrupo)
        {
            ModeloGrupos grupo = new ModeloGrupos();
            return grupo.ObtenerApodoDeIntegrantes(idGrupo);
        }
        public static int ObtenerCantidadDeIntegrantes(int idGrupo)
        {
            ModeloGrupos grupo = new ModeloGrupos();
            return grupo.ObtenerCantidadDeIntegrantes(idGrupo);
        }
        public static void SalirDeGrupo(int idGrupo, int idPerfil)
        {
            ModeloGrupos grupo = new ModeloGrupos();
            grupo.SalirDelGrupo(idGrupo, idPerfil);
        }
        public static void SilenciarGrupo(int idGrupo, int idPerfil, bool silenciar)
        {
            ModeloGrupos grupo = new ModeloGrupos();
            grupo.SilenciarGrupo(idGrupo, idPerfil, silenciar);
        }
        public static Dictionary<string, string> BuscarGrupoPorNombre(string nombreGrupo)
        {
            Dictionary<string, string> grupoInfo = new Dictionary<string, string>();
            ModeloGrupos grupo = new ModeloGrupos();
            grupo = grupo.BuscarGrupoPorNombre(nombreGrupo);

            if (grupo != null)
            {
                grupoInfo.Add("idGrupo", grupo.idGrupo.ToString());
                grupoInfo.Add("nombre", grupo.nombre);
                grupoInfo.Add("informacion", grupo.informacion);
                grupoInfo.Add("idFotoGrupo", grupo.idFotoGrupo ?? "null");
                grupoInfo.Add("fecha", grupo.fecha);
                grupoInfo.Add("idPerfil", grupo.idPerfil.ToString());
            }
            else
            {
                grupoInfo.Add("error", "Grupo no encontrado");
            }

            return grupoInfo;
        }
        public static Dictionary<string, string> BuscarGrupoPorId(int idGrupo)
        {
            Dictionary<string, string> grupoInfo = new Dictionary<string, string>();
            ModeloGrupos grupo = new ModeloGrupos();
            grupo = grupo.BuscarGrupoPorId(idGrupo);

            if (grupo != null)
            {
                grupoInfo.Add("idGrupo", grupo.idGrupo.ToString());
                grupoInfo.Add("nombre", grupo.nombre);
                grupoInfo.Add("informacion", grupo.informacion);
                grupoInfo.Add("idFotoGrupo", grupo.idFotoGrupo ?? "null");
                grupoInfo.Add("fecha", grupo.fecha);
                grupoInfo.Add("idPerfil", grupo.idPerfil.ToString());
            }
            else
            {
                grupoInfo.Add("error", "Grupo no encontrado");
            }

            return grupoInfo;
        }
 
    /*    
        public static void AsociarPostAGrupo(int idGrupo, int idPost)
        {
            ModeloGrupos grupo = new ModeloGrupos();
            grupo.AsociarPostAGrupo(idGrupo, idPost);
        }
        public static void EliminarPostDeGrupo(int idGrupo, int idPost)
        {
            ModeloGrupos grupo = new ModeloGrupos();
            grupo.EliminarPostDeGrupo(idGrupo, idPost);
        }
        public static List<int> ObtenerPostsDeGrupo(int idGrupo)
        {
            ModeloGrupos grupo = new ModeloGrupos();
            return grupo.ObtenerPostsDeGrupo(idGrupo);
        }
        public static bool EsPostDeGrupo(int idGrupo, int idPost)
        {
            ModeloGrupos grupo = new ModeloGrupos();
            return grupo.EsPostDeGrupo(idGrupo, idPost);
        }
   */     
        public static void ModificarGrupo(int idGrupo, string nombre, string informacion, string idFotoGrupo)
        {
            ModeloGrupos grupo = new ModeloGrupos();
            grupo.idGrupo = idGrupo;
            grupo.nombre = nombre;
            grupo.informacion = informacion;
            grupo.idFotoGrupo = idFotoGrupo;
          
            grupo.ModificarGrupo();
        }
        public static void BloquearGrupo(int idGrupo)
        {
            ModeloGrupos grupo = new ModeloGrupos
            {
                idGrupo = idGrupo
            };
            grupo.BloquearGrupo();
        }
        public static void HabilitarGrupo(int idGrupo)
        {
            ModeloGrupos grupo = new ModeloGrupos
            {
                idGrupo = idGrupo
            };
            grupo.HabilitarGrupo();
        }
        public static DataTable ListarGrupos()
        {
            DataTable tabla = new DataTable();

            tabla.Columns.Add("ID_Grupo", typeof(int));
            tabla.Columns.Add("Nombre_Grupo", typeof(string));
            tabla.Columns.Add("Informacion", typeof(string));
            tabla.Columns.Add("Fecha", typeof(string)); 
            tabla.Columns.Add("ID_Perfil", typeof(int));

            ModeloGrupos modeloGrupos = new ModeloGrupos();
            List<ModeloGrupos> listaGrupos = modeloGrupos.ObtenerTodos();

            foreach (ModeloGrupos g in listaGrupos)
            {
                DataRow fila = tabla.NewRow();

                fila["ID_Grupo"] = g.idGrupo;
                fila["Nombre_Grupo"] = g.nombre;
                fila["Informacion"] = g.informacion;
                fila["Fecha"] = g.fecha; 
                fila["ID_Perfil"] = g.idPerfil;

                tabla.Rows.Add(fila);
            }

            return tabla;
        }

    }
}
