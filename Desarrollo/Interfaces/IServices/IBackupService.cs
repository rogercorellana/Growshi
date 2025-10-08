using System;
using Interfaces.IBE;

namespace Interfaces.IServices
{
    
    public interface IBackupService
    {    
        string GenerarNombreDeArchivo();
        bool Validar(IBackup backup);
    }
}