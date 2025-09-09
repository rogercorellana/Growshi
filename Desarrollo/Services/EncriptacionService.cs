using Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class EncriptacionService : IEncriptacionService
    {
        public string Hashear(string texto)
        {
            if (string.IsNullOrEmpty(texto)) return "";
            using (var sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(texto));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }

        public bool Verificar(string passIngresado, string hashTraido)
        {
            if (string.IsNullOrEmpty(passIngresado) || string.IsNullOrEmpty(hashTraido))
                return false;

            string hashNuevo = Hashear(passIngresado);


            return hashNuevo == hashTraido;
        }
    }
}
