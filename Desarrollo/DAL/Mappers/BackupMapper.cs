using BE;
using System;
using System.Data;

public static class BackupMapper
{
    public static Backup MapearDesdeDataRow(DataRow fila)
    {
        
        var usuarioDelBackup = new Usuario
        {
            IdUsuario = Convert.ToInt32(fila["UsuarioId"]),
            NombreUsuario = fila["UsuarioNombre"].ToString()
        };

        return new Backup
        {
            Id = Convert.ToInt32(fila["Id"]),
            FechaHora = Convert.ToDateTime(fila["FechaHora"]),
            NombreArchivo = fila["NombreArchivo"].ToString(),
            RutaArchivo = fila["RutaArchivo"].ToString(),
            Nota = fila["Nota"] == DBNull.Value ? "" : fila["Nota"].ToString(),

            Usuario = usuarioDelBackup
        };
    }
}