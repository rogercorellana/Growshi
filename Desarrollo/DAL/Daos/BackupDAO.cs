using BE;
using DAL.DAO;
using DAL.Mappers;
using Interfaces.IBE;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL.Daos
{
    public class BackupDAO
    {
        private readonly SqlHelper _sqlHelper;

        public BackupDAO()
        {
            _sqlHelper = SqlHelper.GetInstance();
        }

        public void Guardar(IBackup backup)
        {
            // --- CORRECCIÓN AQUÍ ---
            string query = "INSERT INTO [Backup] (FechaHora, NombreArchivo, RutaArchivo, Nota, UsuarioID) VALUES (@FechaHora, @NombreArchivo, @RutaArchivo, @Nota, @IdUsuario)";

            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@FechaHora", backup.FechaHora),
                new SqlParameter("@NombreArchivo", backup.NombreArchivo),
                new SqlParameter("@RutaArchivo", backup.RutaArchivo),
                new SqlParameter("@Nota", backup.Nota),
                new SqlParameter("@IdUsuario", backup.Usuario.IdUsuario) // Asumo que la propiedad se llama IdUsuario
            };

            _sqlHelper.ExecuteNonQuery(query, parameters);
        }

        public void Eliminar(int id)
        {
            // --- CORRECCIÓN AQUÍ ---
            string query = "DELETE FROM [Backup] WHERE Id = @Id";
            var parameters = new List<SqlParameter> { new SqlParameter("@Id", id) };

            _sqlHelper.ExecuteNonQuery(query, parameters);
        }

        public List<Backup> ListarTodos()
        {
            // --- CORRECCIÓN FINAL AQUÍ ---
            // Se ajustaron los nombres de las columnas de la tabla Usuario (u.Id -> u.UsuarioID, u.Nombre -> u.UsuarioNombre)
            // para que coincidan EXACTAMENTE con tu base de datos.
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
    }
}