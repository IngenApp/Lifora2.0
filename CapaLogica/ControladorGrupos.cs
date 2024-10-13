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

        public static void ModificarGrupo(int idGrupo, string nombre, string informacion, int idFotoGrupo)
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
            tabla.Columns.Add("Habilitado", typeof(bool));
            tabla.Columns.Add("ID_Perfil", typeof(int));

            ModeloGrupos modeloGrupos = new ModeloGrupos();
            foreach (ModeloGrupos g in modeloGrupos.ObtenerTodos())
            {
                DataRow fila = tabla.NewRow();
                
                fila["ID_Grupo"] = g.idGrupo;
                fila["Nombre_Grupo"] = g.nombre;
                fila["Informacion"] = g.informacion;
                fila["Fecha"] = g.fecha;
                fila["Habilitado"] = g.habilitado;
                fila["ID_Perfil"] = g.idPerfil;
                tabla.Rows.Add(fila);
            }
            return tabla;
        }

    }
}
