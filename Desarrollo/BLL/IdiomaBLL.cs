using BE;
using DAL;
using DAL.Daos;
using Interfaces.IServices;
using Services; 
using System;
using System.Collections.Generic;
using System.Data;

namespace BLL
{
    public class IdiomaBLL
    {
        private readonly IIdiomaService _idiomaService;
        private readonly IdiomaDAO _idiomaDAO;
        private readonly UsuarioDAO _usuarioDAO;

        public IdiomaBLL()
        {
            _idiomaService = IdiomaService.GetInstance();
            _idiomaDAO = new IdiomaDAO();
            _usuarioDAO = new UsuarioDAO();
        }

        public void CargarIdiomaInicial(Usuario usuario)
        {
            try
            {
                var traducciones = ObtenerTraducciones(usuario.IdiomaPreferidoID);

                _idiomaService.CargarTraducciones(traducciones, usuario.IdiomaPreferidoID);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cargar idioma inicial: {ex.Message}");
                _idiomaService.CargarTraducciones(new Dictionary<string, string>(), 1);
            }
        }

       
        public void CambiarIdioma(int nuevoIdiomaId, Usuario usuario)
        {
            try
            {
                _usuarioDAO.ActualizarIdioma(usuario.IdUsuario, nuevoIdiomaId);

                usuario.IdiomaPreferidoID = nuevoIdiomaId;

                var traducciones = ObtenerTraducciones(nuevoIdiomaId);

                _idiomaService.CargarTraducciones(traducciones, nuevoIdiomaId);

                _idiomaService.NotificarCambio();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cambiar idioma: {ex.Message}");
            }
        }

     
        private Dictionary<string, string> ObtenerTraducciones(int idiomaId)
        {
            DataTable tabla = _idiomaDAO.ObtenerTraducciones(idiomaId);
            var diccionario = new Dictionary<string, string>();

            foreach (DataRow fila in tabla.Rows)
            {
                diccionario[fila["Clave"].ToString()] = fila["Valor"].ToString();
            }
            return diccionario;
        }

     
        public string Traducir(string clave)
        {
            return _idiomaService.Traducir(clave);
        }
    }
}