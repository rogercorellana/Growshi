using BE;
using DAL.DAO;
using DAL.Mappers;
using Interfaces.IBE;
using System;
using System.Collections.Generic;
using System.Data;
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

            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@UsuarioID", evento.UsuarioID.HasValue ? (object)evento.UsuarioID.Value : DBNull.Value),
                new SqlParameter("@Nivel", evento.Nivel.ToString()), // El enum se convierte a string para guardarlo en la DB
                new SqlParameter("@Modulo", string.IsNullOrEmpty(evento.Modulo) ? DBNull.Value : (object)evento.Modulo),
                new SqlParameter("@Mensaje", evento.Mensaje)
            };

            SqlHelper.GetInstance().ExecuteNonQuery(consulta, parametros);
        }

        public List<Bitacora> ObtenerTodos()
        {
            List<Bitacora> lista = new List<Bitacora>();

            string consulta = "SELECT * FROM Bitacora ORDER BY BitacoraID DESC";

            DataTable tabla = SqlHelper.GetInstance().ExecuteReader(consulta, null);

            foreach (DataRow row in tabla.Rows)
            {
                lista.Add(BitacoraMapper.MapearDesdeDataRow(row));
            }

            return lista;
        }


        // Aquí podrías agregar métodos futuros para LEER la bitácora
        // public List<Bitacora> ObtenerTodos() { ... }
        // public List<Bitacora> ObtenerPorUsuario(int usuarioId) { ... }
    }
}

