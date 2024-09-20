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
        public static void CrearGrupo(int idCuenta, string nombre, string descripcion)
        {
            ModeloGrupos grupo = new ModeloGrupos
            {
                idCuenta = idCuenta,
                nombre = nombre,
                descripcion = descripcion
            };
            grupo.CrearGrupo();
        }

        public static void ModificarGrupo(int idGrupo, string nombre, string descripcion)
        {
            ModeloGrupos grupo = new ModeloGrupos
            {
                idGrupo = idGrupo,
                nombre = nombre,
                descripcion = descripcion
            };
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
            tabla.Columns.Add("idGrupo", typeof(int));
            tabla.Columns.Add("nombre", typeof(string));
            tabla.Columns.Add("descripcion", typeof(string));
            tabla.Columns.Add("fecha", typeof(string));
            tabla.Columns.Add("habilitado", typeof(bool));

            ModeloGrupos modeloGrupos = new ModeloGrupos();
            foreach (ModeloGrupos g in modeloGrupos.ObtenerTodos())
            {
                DataRow fila = tabla.NewRow();
                fila["id_grupo"] = g.idGrupo;
                fila["nombre"] = g.nombre;
                fila["descripcion"] = g.descripcion;
                fila["fecha"] = g.fecha;
                fila["habilitado"] = g.habilitado;
                tabla.Rows.Add(fila);
            }
            return tabla;
        }
    }
}
