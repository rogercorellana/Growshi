using System;
using System.Collections.Generic;

namespace Interfaces.IServices
{
    public interface IIdiomaService
    {
      
        event Action IdiomaCambiado;

        void CargarTraducciones(Dictionary<string, string> traducciones, int idiomaId);

        
        void NotificarCambio();

        string Traducir(string clave);

        
        int IdiomaActualID { get; }
    }
}