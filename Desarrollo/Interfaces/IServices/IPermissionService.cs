using Interfaces.IBE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.IServices
{
    public interface IPermissionService
    {
        /// <summary>
        /// Verifica si un usuario logueado tiene un permiso específico.
        /// </summary>
        /// <param name="usuario">Cualquier objeto que cumpla el contrato IUsuarioLogueado.</param>
        /// <param name="permisoId">El string del permiso a verificar.</param>
        /// <returns>True si tiene el permiso, de lo contrario False.</returns>
        bool TienePermiso(IUsuarioLogueado usuario, string permisoId);
    }
}
