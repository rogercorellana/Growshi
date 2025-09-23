using BE;
using System;
using System.Data;
public static class BackupMapper
{
    public static Backup MapearDesdeDataRow(DataRow fila)
    {
        return new Backup
        {
            Id = Convert.ToInt32(fila["Id"]),
            FechaHora = Convert.ToDateTime(fila["FechaHora"]),
            NombreArchivo = fila["NombreArchivo"].ToString(),
            RutaArchivo = fila["RutaArchivo"].ToString(),
            // Leemos la nueva columna, manejando posibles valores nulos.
            Nota = fila["Nota"] == DBNull.Value ? "" : fila["Nota"].ToString(), // <-- AÑADIDO
            Usuario = new Usuario { Id = Convert.ToInt32(fila["UsuarioID"]) }
        };
    }
}