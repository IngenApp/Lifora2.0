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
            
            tabla.Columns.Add("ID", typeof(int));
            tabla.Columns.Add("Nombre", typeof(string));
            tabla.Columns.Add("Descripcion", typeof(string));
            tabla.Columns.Add("Fecha", typeof(string));
            tabla.Columns.Add("Habilitado", typeof(bool));
            tabla.Columns.Add("IDCuenta", typeof(int));

            ModeloGrupos modeloGrupos = new ModeloGrupos();
            foreach (ModeloGrupos g in modeloGrupos.ObtenerTodos())
            {
                DataRow fila = tabla.NewRow();
                
                fila["ID"] = g.idGrupo;
                fila["Nombre"] = g.nombre;
                fila["Descripcion"] = g.descripcion;
                fila["Fecha"] = g.fecha;
                fila["Habilitado"] = g.habilitado;
                fila["IDCuenta"] = g.idCuenta;
                tabla.Rows.Add(fila);
            }
            return tabla;
        }

    }
}
