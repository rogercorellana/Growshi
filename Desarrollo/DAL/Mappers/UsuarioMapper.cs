using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappers
{
    internal static class UsuarioMapper
    {
        public static Usuario MapearDesdeDataRow(DataRow fila)
        {
            // Asegúrate de que los nombres de columna en fila["..."]
            // coincidan EXACTAMENTE con tu tabla de base de datos.
            return new Usuario
            {
                IdUsuario = (int)fila["UsuarioID"],
                NombreUsuario = fila["NombreUsuario"].ToString(),
                IntentosUsuario = (int)fila["IntentosUsuario"]
            };
        }
    }
}
