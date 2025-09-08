using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class LoginService : ILoginService
    {
        private readonly IEncriptacionService _encriptacionService;

        public LoginService()
        {
            _encriptacionService = new EncriptacionService();
        }

        public bool ValidarLogin(string passwordIngresada, Usuario usuarioDesdeDB)
        {
            if (usuarioDesdeDB == null || string.IsNullOrEmpty(passwordIngresada))
            {
                return false;
            }

            // 1. Usa otra herramienta (Encriptacion) para verificar la contraseña.
            if (!_encriptacionService.Verificar(passwordIngresada, usuarioDesdeDB.Password))
            {
                return false;
            }

            // 2. Aquí podría tener otras validaciones puras (ej: la cuenta no está deshabilitada)
            // if (!usuarioDesdeDB.Activo) return false;

            return true;
        }
    }
}
