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
          
            return new Usuario
            {
                IdUsuario = Convert.ToInt32(fila["UsuarioID"]),
                NombreUsuario = fila["UsuarioNombre"].ToString(),
                IdiomaPreferidoID = Convert.ToInt32(fila["IdiomaPreferidoID"])
            }; 
        }
    }
}
