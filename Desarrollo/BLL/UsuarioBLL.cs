using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UsuarioBLL
    {
        #region Patron Singleton 
        private static UsuarioBLL _instancia;
        private UsuarioBLL() { }
        public static UsuarioBLL GetInstance
        {
            get
            {
                if (_instancia == null)
                {
                            _instancia = new UsuarioBLL();

                }
                return _instancia;
            }
        }
        #endregion


        public bool iniciarSesion(string usuario, string contraseña)
        {
            return true;
        }

    }
}
