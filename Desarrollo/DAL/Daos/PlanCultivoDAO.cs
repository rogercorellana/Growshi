using BE;
using DAL.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Daos
{
    public class PlanCultivoDAO
    {
        private SqlHelper sqlHelper = SqlHelper.GetInstance();

        public List<PlanCultivo> Listar()
        {
            List<PlanCultivo> lista = new List<PlanCultivo>();
            string query = "SELECT * FROM PlanCultivo"; 

            DataTable table = sqlHelper.ExecuteReader(query, null);

            foreach (DataRow row in table.Rows)
            {
                lista.Add(Mappers.PlanCultivoMapper.Map(row));
            }

            return lista;
        }

        public bool Alta(PlanCultivo plan, int usuarioID)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            StringBuilder query = new StringBuilder();

            query.AppendLine("BEGIN TRANSACTION;");
            query.AppendLine("BEGIN TRY");

            
            query.AppendLine("   INSERT INTO PlanCultivo (NombrePlan)");
            query.AppendLine("   VALUES (@NombrePlan);");

            query.AppendLine("   DECLARE @NuevoID INT = SCOPE_IDENTITY();");

            // Vinculamos el plan con el usuario
            query.AppendLine("   INSERT INTO Usuario_PlanCultivo (UsuarioID, PlanCultivoID)");
            query.AppendLine("   VALUES (@UsuarioID, @NuevoID);");

            parametros.Add(new SqlParameter("@NombrePlan", plan.NombrePlan));
            parametros.Add(new SqlParameter("@UsuarioID", usuarioID)); 

            for (int i = 0; i < plan.Etapas.Count; i++)
            {
                var etapa = plan.Etapas[i];
                string s = i.ToString();

                query.AppendLine($"   INSERT INTO EtapaCultivo (PlanCultivoID, Nombre, Orden, DuracionDias, TempMinima, TempMaxima, HumedadMinima, HumedadMaxima, PHMinimo, PHMaximo, ECMinima, ECMaxima)");
                query.AppendLine($"   VALUES (@NuevoID, @Nom{s}, @Ord{s}, @Dur{s}, @TMin{s}, @TMax{s}, @HMin{s}, @HMax{s}, @PMin{s}, @PMax{s}, @EMin{s}, @EMax{s});");

                parametros.Add(new SqlParameter($"@Nom{s}", etapa.NombreEtapa));
                parametros.Add(new SqlParameter($"@Ord{s}", etapa.Orden));
                parametros.Add(new SqlParameter($"@Dur{s}", etapa.Duracion));
                parametros.Add(new SqlParameter($"@TMin{s}", etapa.TempMin));
                parametros.Add(new SqlParameter($"@TMax{s}", etapa.TempMax));
                parametros.Add(new SqlParameter($"@HMin{s}", etapa.HumMin));
                parametros.Add(new SqlParameter($"@HMax{s}", etapa.HumMax));
                parametros.Add(new SqlParameter($"@PMin{s}", etapa.PhMin));
                parametros.Add(new SqlParameter($"@PMax{s}", etapa.PhMax));
                parametros.Add(new SqlParameter($"@EMin{s}", etapa.EcMin));
                parametros.Add(new SqlParameter($"@EMax{s}", etapa.EcMax));
            }

            query.AppendLine("   COMMIT TRANSACTION;");
            query.AppendLine("   SELECT @NuevoID AS IDGenerado;");
            query.AppendLine("END TRY");
            query.AppendLine("BEGIN CATCH");
            query.AppendLine("   ROLLBACK TRANSACTION;");
            query.AppendLine("   THROW;");
            query.AppendLine("END CATCH");

            DataTable tablaResultado = sqlHelper.ExecuteReader(query.ToString(), parametros);

            if (tablaResultado != null && tablaResultado.Rows.Count > 0)
            {
                plan.PlanCultivoID = Convert.ToInt32(tablaResultado.Rows[0]["IDGenerado"]);
                return true;
            }

            return false;
        }

        public bool modificarPlan(PlanCultivo plan)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            StringBuilder query = new StringBuilder();

            query.AppendLine("BEGIN TRANSACTION;");
            query.AppendLine("BEGIN TRY");

            // 1. Actualizar el Nombre del Plan (Cabecera)
            query.AppendLine("   UPDATE PlanCultivo SET NombrePlan = @NombrePlan WHERE PlanCultivoID = @PlanID;");

            parametros.Add(new SqlParameter("@NombrePlan", plan.NombrePlan));
            parametros.Add(new SqlParameter("@PlanID", plan.PlanCultivoID));

            // 2. Actualizar cada Etapa (Detalle)
            for (int i = 0; i < plan.Etapas.Count; i++)
            {
                var etapa = plan.Etapas[i];
                string s = i.ToString(); // Sufijo para que los parámetros sean únicos (@Nom0, @Nom1, etc.)

                query.AppendLine($"   UPDATE EtapaCultivo SET ");
                query.AppendLine($"       Nombre = @Nom{s}, ");
                query.AppendLine($"       DuracionDias = @Dur{s}, ");
                query.AppendLine($"       TempMinima = @TMin{s}, TempMaxima = @TMax{s}, ");
                query.AppendLine($"       HumedadMinima = @HMin{s}, HumedadMaxima = @HMax{s}, ");
                query.AppendLine($"       PHMinimo = @PMin{s}, PHMaximo = @PMax{s}, ");
                query.AppendLine($"       ECMinima = @EMin{s}, ECMaxima = @EMax{s} ");
                query.AppendLine($"   WHERE EtapaCultivoID = @EtapaID{s};");

                // Parámetros de la etapa
                parametros.Add(new SqlParameter($"@EtapaID{s}", etapa.EtapaCultivoID)); // ¡CRUCIAL! El ID para el WHERE
                parametros.Add(new SqlParameter($"@Nom{s}", etapa.NombreEtapa));
                parametros.Add(new SqlParameter($"@Dur{s}", etapa.Duracion));
                parametros.Add(new SqlParameter($"@TMin{s}", etapa.TempMin));
                parametros.Add(new SqlParameter($"@TMax{s}", etapa.TempMax));
                parametros.Add(new SqlParameter($"@HMin{s}", etapa.HumMin));
                parametros.Add(new SqlParameter($"@HMax{s}", etapa.HumMax));
                parametros.Add(new SqlParameter($"@PMin{s}", etapa.PhMin));
                parametros.Add(new SqlParameter($"@PMax{s}", etapa.PhMax));
                parametros.Add(new SqlParameter($"@EMin{s}", etapa.EcMin));
                parametros.Add(new SqlParameter($"@EMax{s}", etapa.EcMax));
            }

            // 3. Confirmar transacción
            query.AppendLine("   COMMIT TRANSACTION;");
            query.AppendLine("END TRY");
            query.AppendLine("BEGIN CATCH");
            query.AppendLine("   ROLLBACK TRANSACTION;");
            query.AppendLine("   THROW;"); // Lanza el error hacia C#
            query.AppendLine("END CATCH");

            // Ejecutar todo el bloque
            int filasAfectadas = sqlHelper.ExecuteNonQuery(query.ToString(), parametros);

            // Si afectó filas (al menos 1 del plan + las etapas), retornamos true
            return filasAfectadas > 0;
        }

        public bool Eliminar(int idPlan)
        {
            // Gracias al ON DELETE CASCADE en tu base de datos, 
            // al borrar el Plan se borran solas las Etapas.
            string query = "DELETE FROM PlanCultivo WHERE PlanCultivoID = @id";

            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@id", idPlan));

            int filas = sqlHelper.ExecuteNonQuery(query, parametros);

            return filas > 0;
        }
    }
}
