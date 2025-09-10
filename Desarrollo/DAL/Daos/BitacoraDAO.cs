using BE;
using DAL.DAO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL.Daos
{
    public class BitacoraDAO
    {
        public void Insertar(Bitacora entrada)
        {
            // La consulta SQL con parámetros para evitar inyección SQL.
            string consulta = @"
                INSERT INTO Bitacora 
                    (UsuarioID, Mensaje, Fecha, Criticidad) 
                VALUES 
                    (@userId, @mensaje, @fecha, @criticidad)";

            // Maneja el caso de un usuario nulo (para eventos del sistema).
            // Si entrada.Usuario es null, guardamos un DBNull.Value en la DB.
            SqlParameter userIdParam;
            if (entrada.Usuario != null)
            {
                userIdParam = new SqlParameter("@userId", entrada.Usuario.IdUsuario);
            }
            else
            {
                // DBNull.Value es la forma correcta de insertar un NULL en la base de datos.
                userIdParam = new SqlParameter("@userId", DBNull.Value);
            }

            // Creamos la lista de parámetros.
            var parametros = new List<SqlParameter>
            {
                userIdParam,
                new SqlParameter("@mensaje", entrada.Mensaje),
                new SqlParameter("@fecha", entrada.Fecha),
                new SqlParameter("@criticidad", entrada.Criticidad)
            };

            // Usamos tu SqlHelper para ejecutar la consulta.
            SqlHelper.GetInstance().ExecuteNonQuery(consulta, parametros);
        }
    }
}