using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappers
{
    public static class UsuarioMapper
    {
        public static Usuario MapearDesdeDataRow(DataRow fila)
        {
            // asegurar que los nombres de columna en fila["..."]
            // coincidan EXACTAMENTE con la DB.
            return new Usuario
            {
                NombreUsuario = fila["UsuarioNombre"].ToString(),
            };
        }
    }
}
