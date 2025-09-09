using Interfaces;
using Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    // Implementación del servicio de validación.
    // NO conoce a la DAL, es puro.
    public class LoginService : ILoginService
    {
        private readonly EncriptacionService _encriptacionService;

        public LoginService()
        {
            _encriptacionService = new EncriptacionService();
        }

        public bool ValidarLogin(string passwordIngresada, string hashTraido)
        {
            if (hashTraido == null || string.IsNullOrEmpty(passwordIngresada))
            {
                return false;
            }

            if (!_encriptacionService.Verificar(passwordIngresada, hashTraido))
            {
                return false;
            }

            return true;
        }
    }
}
