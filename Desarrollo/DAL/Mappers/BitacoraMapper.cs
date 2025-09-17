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
        /// <summary>
        /// Convierte un DataRow de la tabla Bitacora a un objeto Bitacora.
        /// </summary>
        public static Bitacora MapearDesdeDataRow(DataRow fila)
        {
            return new Bitacora
            {
                BitacoraID = Convert.ToInt32(fila["BitacoraID"]),

                // Manejamos la posible nulidad de la columna UsuarioID
                UsuarioID = fila["UsuarioID"] == DBNull.Value ? (int?)null : Convert.ToInt32(fila["UsuarioID"]),

                FechaHora = Convert.ToDateTime(fila["FechaHora"]),

                // Convertimos el string de la base de datos de vuelta al enum NivelCriticidad.
                // El 'true' en Enum.Parse ignora mayúsculas/minúsculas.
                Nivel = (NivelCriticidad)Enum.Parse(typeof(NivelCriticidad), fila["Nivel"].ToString(), true),

                Modulo = fila["Modulo"].ToString(),
                Mensaje = fila["Mensaje"].ToString()
            };
        }
    }
}
