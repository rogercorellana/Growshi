using BE;
using DAL.DAO;
using DAL.Mappers; // Asegúrate de tener el using al namespace de tus mappers
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
            // ... (El código de Guardar y Eliminar no cambia)
            string query = "INSERT INTO Backup (FechaHora, NombreArchivo, RutaArchivo, Nota, IdUsuario) VALUES (@FechaHora, @NombreArchivo, @RutaArchivo, @Nota, @IdUsuario)";
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

        public void Eliminar(int id)
        {
            // ... (El código de Guardar y Eliminar no cambia)
            string query = "DELETE FROM Backup WHERE Id = @Id";
            var parameters = new List<SqlParameter> { new SqlParameter("@Id", id) };
            _sqlHelper.ExecuteNonQuery(query, parameters);
        }

        public List<Backup> ListarTodos()
        {
            string query = @"SELECT b.Id, b.FechaHora, b.NombreArchivo, b.RutaArchivo, b.Nota, 
                                    u.Id as IdUsuario, u.Nombre as NombreUsuario 
                             FROM Backup b 
                             JOIN Usuario u ON b.IdUsuario = u.Id 
                             ORDER BY b.FechaHora DESC";

            DataTable tabla = _sqlHelper.ExecuteReader(query, null);

            var listaDeBackups = new List<Backup>();

            // --- AQUÍ ESTÁ EL CAMBIO ---
            // El DAO ahora itera sobre la tabla y usa el mapper estático.
            foreach (DataRow fila in tabla.Rows)
            {
                listaDeBackups.Add(BackupMapper.MapearDesdeDataRow(fila));
            }

            return listaDeBackups;
        }
    }
}