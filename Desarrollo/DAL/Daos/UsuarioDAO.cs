﻿using DAL.DAO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL.Mappers;
using Interfaces;
using Interfaces.IDAL;

namespace DAL
{
    public class UsuarioDAO : IABM<Usuario>
    {
        /// <summary>
        /// Obtiene la fila completa de un usuario, incluyendo datos sensibles como la contraseña.
        /// </summary>
        /// <returns>Un DataTable con la fila del usuario, o un DataTable vacío si no se encuentra.</returns>
        public DataTable ObtenerDatosCrudosPorNombre(string nombreUsuario)
        {
            // La consulta trae todas las columnas necesarias para la validación.
            string consulta = "SELECT * FROM Usuario WHERE UsuarioNombre = @nombre"; 
            var parametros = new List<SqlParameter> { new SqlParameter("@nombre", nombreUsuario) };

            return SqlHelper.GetInstance().ExecuteReader(consulta, parametros);
        }

        /// <summary>
        /// Actualiza el contador de intentos de login fallidos para un usuario.
        /// </summary>
        public void ActualizarIntentos(int usuarioId, int nuevosIntentos)
        {
            string consulta = "UPDATE Usuario SET UsuarioIntentos = @intentos WHERE UsuarioID = @id";
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@intentos", nuevosIntentos),
                new SqlParameter("@id", usuarioId)
            };

            SqlHelper.GetInstance().ExecuteNonQuery(consulta, parametros);
        }


        public void ActualizarEstadoSesion(int usuarioId, bool estaLogueado)
        {
            string consulta = "UPDATE Usuario SET EstaLogueado = @logueado, UltimaActividad = @fecha WHERE UsuarioID = @id";
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@logueado", estaLogueado),
                new SqlParameter("@fecha", DateTime.Now),
                new SqlParameter("@id", usuarioId)
            };

            SqlHelper.GetInstance().ExecuteNonQuery(consulta, parametros);
        }


        /// <summary>
        /// Obtiene un usuario completo a partir de su ID.
        /// </summary>
        /// <returns>Un objeto Usuario, o null si no se encuentra.</returns>
        public Usuario ObtenerPorId(int usuarioId)
        {
            string consulta = "SELECT * FROM Usuario WHERE UsuarioID = @id";
            var parametros = new List<SqlParameter> { new SqlParameter("@id", usuarioId) };

            var tabla = SqlHelper.GetInstance().ExecuteReader(consulta, parametros);

            if (tabla.Rows.Count > 0)
            {
                return UsuarioMapper.MapearDesdeDataRow(tabla.Rows[0]);
            }

            return null; 
        }




        public void Crear(Usuario entidad)
        {
            throw new NotImplementedException();
        }

        public void Actualizar(Usuario entidad)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> ObtenerTodos()
        {
            throw new NotImplementedException();
        }
    }
}
