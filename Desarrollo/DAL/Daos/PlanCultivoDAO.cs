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

            
            query.AppendLine("   INSERT INTO PlanCultivo (NombrePlan, FechaInicio, Estado)");
            query.AppendLine("   VALUES (@NombrePlan, @FechaInicio, @Estado);");

            query.AppendLine("   DECLARE @NuevoID INT = SCOPE_IDENTITY();");

            // Vinculamos el plan con el usuario
            query.AppendLine("   INSERT INTO Usuario_PlanCultivo (UsuarioID, PlanCultivoID)");
            query.AppendLine("   VALUES (@UsuarioID, @NuevoID);");

            parametros.Add(new SqlParameter("@NombrePlan", plan.NombrePlan));
            parametros.Add(new SqlParameter("@FechaInicio", plan.FechaInicio));
            parametros.Add(new SqlParameter("@Estado", true)); 
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
    }
}
