using BE;
using Interfaces.IBE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappers
{
    public static class BitacoraMapper
    {
        
        public static Bitacora MapearDesdeDataRow(DataRow fila)
        {
            return new Bitacora
            {
                BitacoraID = Convert.ToInt32(fila["BitacoraID"]),

                UsuarioID = fila["UsuarioID"] == DBNull.Value ? (int?)null : Convert.ToInt32(fila["UsuarioID"]),

                FechaHora = Convert.ToDateTime(fila["FechaHora"]),

               
                Nivel = (NivelCriticidad)Enum.Parse(typeof(NivelCriticidad), fila["Nivel"].ToString(), true),

                Modulo = fila["Modulo"].ToString(),
                Mensaje = fila["Mensaje"].ToString()
            };
        }
    }
}
