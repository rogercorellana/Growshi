using BE;
using DAL.Mappers;
using System;
using System.Data;
public static class BackupMapper
{
    public static Backup MapearDesdeDataRow(DataRow fila)
    {
        var usuario = UsuarioMapper.MapearDesdeDataRow(fila);


        return new Backup
        {
            Id = Convert.ToInt32(fila["Id"]),
            FechaHora = Convert.ToDateTime(fila["FechaHora"]),
            NombreArchivo = fila["NombreArchivo"].ToString(),
            RutaArchivo = fila["RutaArchivo"].ToString(),
            Nota = fila["Nota"] == DBNull.Value ? "" : fila["Nota"].ToString(),
            Usuario = usuario

        };
    }
}