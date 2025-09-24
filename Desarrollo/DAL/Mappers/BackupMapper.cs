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
            // Leemos la nueva columna, manejando posibles valores nulos.
            Nota = fila["Nota"] == DBNull.Value ? "" : fila["Nota"].ToString(),
            //Usuario = new Usuario { IdUsuario = Convert.ToInt32(fila["UsuarioID"]) }
            Usuario = usuario

        };
    }
}