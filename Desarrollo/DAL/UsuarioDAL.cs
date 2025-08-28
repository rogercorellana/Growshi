using DAL.DAO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    internal class UsuarioDAL
    {


        public Usuario ObtenerPorNombre(string nombreUsuario){
            // 1. La receta (la consulta con su placeholder)
            string consulta = "SELECT * FROM Usuario WHERE NombreUsuario = @nombre";

            // 2. Preparar los ingredientes de forma segura (crear la lista de parámetros)
            var parametros = new List<SqlParameter>{
                new SqlParameter("@nombre", nombreUsuario)
            };

            // 3. Tomar la herramienta (el SqlHelper)
            SqlHelper helper = SqlHelper.GetInstance();

            // 4. Usar la herramienta para "cocinar" (ejecutar la consulta)
            DataTable tabla = helper.ExecuteReader(consulta, parametros);

            // 5. Si hay resultado, se usa un Mapper para "emplatar" (convertir la tabla a un objeto)
            if (tabla.Rows.Count > 0)
            {
                DataRow filaDeUsuario = tabla.Rows[0];

                // 2. Usamos un Mapper para hacer la conversión
                Usuario usuarioMapeado = MapearAUsuarioDTO(filaDeUsuario);
                // Aquí iría la lógica del Mapper para convertir la primera fila de la tabla
                // en un objeto UsuarioDTO y devolverlo.
                return usuarioMapeado;
            }

            return null; // No se encontró al usuario
        }

        private Usuario MapearAUsuarioDTO(DataRow fila)
        {
            return new Usuario
            {
                ID = Convert.ToInt32(fila["UsuarioID"]),
                NombreUsuario = fila["NombreUsuario"].ToString(),
                Email = fila["Email"].ToString(),
                IntentosFallidos = Convert.ToInt32(fila["IntentosUsuario"])
            };
        }
    }
}
