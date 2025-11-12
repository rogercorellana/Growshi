using Interfaces.IServices;
using System;
using System.Collections.Generic;

namespace Services
{
    public class IdiomaService : IIdiomaService
    {
        #region Singleton
        private static readonly Lazy<IdiomaService> _instancia =
            new Lazy<IdiomaService>(() => new IdiomaService());

        public static IIdiomaService GetInstance() => _instancia.Value;
        #endregion

        #region Observer
        public event Action IdiomaCambiado;

        public void NotificarCambio()
        {
            IdiomaCambiado?.Invoke();
        }
        #endregion

        #region Diccionario en Memoria
        private Dictionary<string, string> _traducciones;
        public int IdiomaActualID { get; private set; }

        private IdiomaService()
        {
            _traducciones = new Dictionary<string, string>();
            IdiomaActualID = 1; 
        }

        public void CargarTraducciones(Dictionary<string, string> traducciones, int idiomaId)
        {
            _traducciones = traducciones;
            IdiomaActualID = idiomaId;
        }

        public string Traducir(string clave)
        {
            if (string.IsNullOrEmpty(clave)) return "";
            if (_traducciones.ContainsKey(clave))
            {
                return _traducciones[clave];
            }
            return $"[{clave.ToUpper()}_ERR]";
        }
        #endregion
    }
}