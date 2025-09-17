using Interfaces.IBE;
using Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public sealed class PermissionService : IPermissionService
    {
        private static readonly IPermissionService _instancia = new PermissionService();

        private PermissionService() { }

        public static IPermissionService GetInstance() => _instancia;

        // El método recibe la interfaz, cumpliendo 100% con la arquitectura.
        public bool TienePermiso(IUsuarioLogueado usuario, string permisoId)
        {
            if (usuario?.Permisos == null)
            {
                return false;
            }
            return usuario.Permisos.Contains(permisoId);
        }
    }
}
