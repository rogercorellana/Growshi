using BE;
using DAL.DAO;
using DAL.Mappers;
using Interfaces.IBE;
using Interfaces.IDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL.Daos
{
    public class BackupDAO : IABM<Backup>
    {
        private readonly SqlHelper _sqlHelper;

        public BackupDAO()
        {
            _sqlHelper = SqlHelper.GetInstance();
        }


        #region CREAR - BACKUP QUERY
        public void Crear(Backup backup)
        {
            string query = "INSERT INTO [Backup] (FechaHora, NombreArchivo, RutaArchivo, Nota, UsuarioID) VALUES (@FechaHora, @NombreArchivo, @RutaArchivo, @Nota, @IdUsuario)";

            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@FechaHora", backup.FechaHora),
                new SqlParameter("@NombreArchivo", backup.NombreArchivo),
                new SqlParameter("@RutaArchivo", backup.RutaArchivo),
                new SqlParameter("@Nota", backup.Nota),
                new SqlParameter("@IdUsuario", backup.Usuario.IdUsuario)
            };

            _sqlHelper.ExecuteNonQuery(query, parameters);
        }
        #endregion

        #region ELIMINAR - BACKUP QUERY
        public void Eliminar(int id)
        {
            string query = "DELETE FROM [Backup] WHERE Id = @Id";
            var parameters = new List<SqlParameter> { new SqlParameter("@Id", id) };

            _sqlHelper.ExecuteNonQuery(query, parameters);
        }

        #endregion

        #region LEER TODO - BACKUP QUERY 
        public List<Backup> ObtenerTodos()
        {
            string query = @"SELECT b.Id, b.FechaHora, b.NombreArchivo, b.RutaArchivo, b.Nota, 
                            u.UsuarioID, 
                            u.UsuarioNombre
                     FROM [Backup] b 
                     JOIN [Usuario] u ON b.UsuarioId = u.UsuarioID 
                     ORDER BY b.FechaHora DESC";

            DataTable tabla = _sqlHelper.ExecuteReader(query, null);

            var listaDeBackups = new List<Backup>();

            foreach (DataRow fila in tabla.Rows)
            {
                listaDeBackups.Add(BackupMapper.MapearDesdeDataRow(fila));
            }

            return listaDeBackups;
        }
        #endregion


        //NO IMPLEMENTADO 

        #region LEER POR ID -
        public Backup ObtenerPorId(int id)
        {
            throw new NotSupportedException("La obtención de un backup individual por ID no está soportada.");
        }

        #endregion

        #region MODIFICAR - 
        public void Actualizar(Backup entidad)
        {
            throw new NotSupportedException("Los registros de Backup son inmutables y no pueden ser modificados.");
        }

        #endregion
  

    }
}