using BE;
using DAL.DAO;
using DAL.Mappers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL.Daos
{
    /// <summary>
    /// Gestiona las operaciones de negocio (ABM) para el catálogo de backups,
    /// interactuando con la tabla [Backup] a través del SqlHelper.
    /// </summary>
    public class BackupDAO
    {
        private const string GET_ALL_QUERY = "SELECT Id, FechaHora, NombreArchivo, RutaArchivo, UsuarioID FROM [dbo].[Backup] ORDER BY FechaHora DESC";
        private const string INSERT_QUERY = "INSERT INTO [dbo].[Backup] (FechaHora, NombreArchivo, RutaArchivo, UsuarioID) VALUES (@FechaHora, @NombreArchivo, @RutaArchivo, @UsuarioID)";

        public List<Backup> ObtenerCatalogo()
        {
            var lista = new List<Backup>();

            // 1. Llama a tu SqlHelper.GetInstance(), que devuelve un DataTable.
            // Se pasa 'null' como segundo parámetro ya que esta consulta no requiere parámetros.
            var tablaResultados = SqlHelper.GetInstance().ExecuteReader(GET_ALL_QUERY, null);

            // 2. Se recorre cada DataRow en el DataTable devuelto.
            foreach (DataRow fila in tablaResultados.Rows)
            {
                // 3. Se utiliza el mapper que trabaja con DataRow para convertir la fila en un objeto.
                lista.Add(BackupMapper.MapearDesdeDataRow(fila));
            }
            return lista;
        }

        public void CrearRegistro(Backup backup)
        {
            // Se crea la lista de parámetros como la espera tu SqlHelper.
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@FechaHora", backup.FechaHora),
                new SqlParameter("@NombreArchivo", backup.NombreArchivo),
                new SqlParameter("@RutaArchivo", backup.RutaArchivo),
                new SqlParameter("@UsuarioID", backup.Usuario.IdUsuario)
            };

            SqlHelper.GetInstance().ExecuteNonQuery(INSERT_QUERY, parametros);
        }
    }
}
