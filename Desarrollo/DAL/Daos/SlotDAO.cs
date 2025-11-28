using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BE;
using DAL.DAO; 

namespace DAL.Daos
{
    public class SlotDAO
    {
        private SqlHelper sqlHelper = SqlHelper.GetInstance();

        public List<Slot> ObtenerSlotsPorUsuario(int usuarioId)
        {
            List<Slot> lista = new List<Slot>();

            string query = @"
                SELECT s.SlotID, s.SlotEstado, s.PlantaAsociada, p.Nombre as NombrePlanta
                FROM Slot s
                INNER JOIN Usuario_Slot us ON s.SlotID = us.SlotID
                LEFT JOIN Planta p ON s.PlantaAsociada = p.PlantaID
                WHERE us.UsuarioID = @uid
                ORDER BY s.SlotID ASC";

            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@uid", usuarioId)
            };

            DataTable tabla = sqlHelper.ExecuteReader(query, parametros);

            int contadorVisual = 1;
            foreach (DataRow fila in tabla.Rows)
            {
                Slot slot = new Slot();
                slot.SlotID = Convert.ToInt32(fila["SlotID"]);
                slot.NumeroVisual = contadorVisual;

                // 1 = Prendido, 0 = Apagado
                slot.SlotEstado = Convert.ToBoolean(fila["SlotEstado"]);

                if (fila["PlantaAsociada"] != DBNull.Value)
                {
                    slot.PlantaAsociadaID = Convert.ToInt32(fila["PlantaAsociada"]);
                    slot.NombrePlanta = fila["NombrePlanta"].ToString();
                }
                else
                {
                    slot.PlantaAsociadaID = null;
                    slot.NombrePlanta = "Disponible";
                }

                lista.Add(slot);
                contadorVisual++;
            }
            return lista;
        }

        public void AsignarPermisosHardware(int usuarioId)
        {
            string query = @"
                INSERT INTO Usuario_Slot (UsuarioID, SlotID)
                SELECT @UsuarioID, SlotID 
                FROM Slot";

            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@UsuarioID", usuarioId)
            };

            sqlHelper.ExecuteNonQuery(query, parametros);
        }


        public void DeshabilitarSlot(int slotID)
        {
            string query = "UPDATE Slot SET SlotEstado = 0 WHERE SlotID = @id";
            List<SqlParameter> parametros = new List<SqlParameter>
                {
                new SqlParameter("@id", slotID)
                };

            sqlHelper.ExecuteNonQuery(query, parametros);

        }

        public void HabilitarSlot(int slotId)
        {
            string query = "UPDATE Slot SET SlotEstado = 1 WHERE SlotID = @id";

            List<SqlParameter> parametros = new List<SqlParameter>
                {
                new SqlParameter("@id", slotId)
                };

            sqlHelper.ExecuteNonQuery(query, parametros);
        }


        public void AsignarPlanta(int slotId, int plantaId)
        {
            string query = "UPDATE Slot SET PlantaAsociada = @plantaId WHERE SlotID = @slotId";

            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@slotId", slotId),
                new SqlParameter("@plantaId", plantaId)
            };

            sqlHelper.ExecuteNonQuery(query, parameters);
        }
    }
}