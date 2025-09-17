using BE;
using DAL.DAO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL.Daos
{
    public class BitacoraDAO
    {
        /// <summary>
        /// Guarda un nuevo registro de evento en la tabla Bitacora.
        /// </summary>
        /// <param name="evento">El objeto Bitacora con la información a guardar.</param>
        public void Guardar(Bitacora evento)
        {
            string consulta = @"
                INSERT INTO Bitacora (UsuarioID, Nivel, Modulo, Mensaje)
                VALUES (@UsuarioID, @Nivel, @Modulo, @Mensaje)";

            // Usamos List<SqlParameter> para mantener la consistencia con tu UsuarioDAO
            var parametros = new List<SqlParameter>
            {
                // Manejamos correctamente los valores nulos para columnas que lo permiten
                new SqlParameter("@UsuarioID", evento.UsuarioID.HasValue ? (object)evento.UsuarioID.Value : DBNull.Value),
                new SqlParameter("@Nivel", evento.Nivel.ToString()), // El enum se convierte a string para guardarlo en la DB
                new SqlParameter("@Modulo", string.IsNullOrEmpty(evento.Modulo) ? DBNull.Value : (object)evento.Modulo),
                new SqlParameter("@Mensaje", evento.Mensaje)
            };

            // Llamamos al SqlHelper para ejecutar la consulta de inserción
            SqlHelper.GetInstance().ExecuteNonQuery(consulta, parametros);
        }

        // Aquí podrías agregar métodos futuros para LEER la bitácora
        // public List<Bitacora> ObtenerTodos() { ... }
        // public List<Bitacora> ObtenerPorUsuario(int usuarioId) { ... }
    }
}