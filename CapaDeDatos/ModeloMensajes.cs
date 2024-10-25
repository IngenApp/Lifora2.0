using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Modelo
{
    public class ModeloMensajes : Modelo
    {
        public int idPerfil1, idPerfil2, idMensaje, idConversacion, idChat;
        public string contenido, fechaHora, apodo;

        public List<ModeloMensajes> ObtenerChat(int idPerfil)
        {
            List<ModeloMensajes> chat = new List<ModeloMensajes>();

            string sql = @"SELECT c.fecha_hora, p2.apodo AS apodo_otro_perfil FROM conversacion c JOIN perfil p1 ON c.id_perfil_1 = p1.id_perfil OR c.id_perfil_2 = p1.id_perfil JOIN perfil p2 ON (p1.id_perfil = c.id_perfil_1 AND p2.id_perfil = c.id_perfil_2) OR (p1.id_perfil = c.id_perfil_2 AND p2.id_perfil = c.id_perfil_1) WHERE p1.id_perfil = @id_perfil;";

            this.Comando.CommandText = sql;
            this.Comando.Parameters.AddWithValue("@id_perfil", idPerfil);
            using (this.Lector = this.Comando.ExecuteReader())
            {
                while (this.Lector.Read())
                {
                    ModeloMensajes mp = new ModeloMensajes
                    {
                        apodo = this.Lector["apodo_otro_perfil"].ToString(),
                        fechaHora = this.Lector["fecha_hora"].ToString()
                    };
                    chat.Add(mp);
                }
            }
            return chat;

        }
        
        public List<ModeloMensajes> ObtenerMensajesDeConversacion(int idPerfil1, int idPerfil2)
        {
            List<ModeloMensajes> mensajes = new List<ModeloMensajes>();

            string sql = @"
        SELECT 
            m.id_mensaje,
            m.contenido,
            m.fecha_hora,
            p.apodo
        FROM 
            mensaje m
        JOIN 
            perfil p ON m.id_perfil = p.id_perfil
        WHERE 
            m.id_mensaje IN (
                SELECT 
                    c.id_mensaje
                FROM 
                    chat c
                WHERE 
                    (c.id_perfil_1 = @idPerfil1 AND c.id_perfil_2 = @idPerfil2) 
                    OR (c.id_perfil_1 = @idPerfil2 AND c.id_perfil_2 = @idPerfil1)
            )
        ORDER BY 
            m.fecha_hora;";

            try
            {

                this.Comando.Parameters.AddWithValue("@idPerfil1", idPerfil1);
                this.Comando.Parameters.AddWithValue("@idPerfil2", idPerfil2);
                this.Comando.CommandText = sql;
                using (this.Lector = this.Comando.ExecuteReader())
                {
                    while (this.Lector.Read())
                    {
                        ModeloMensajes mp = new ModeloMensajes
                        {
                            apodo = this.Lector["apodo"].ToString(),
                            contenido = this.Lector["contenido"].ToString(),
                            fechaHora = this.Lector["fecha_hora"].ToString()
                        };
                        mensajes.Add(mp);
                    }
                }
                
            }
            catch (Exception ex)
            {
              
                Console.WriteLine($"Error: {ex.Message}");
            }

            return mensajes;
        }
    }
}