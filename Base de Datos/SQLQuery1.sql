CREATE TABLE RelacionUsuarioTipoUsuario (
    UsuarioID varchar(50),
    TipoUsuarioID INT,

    -- 1. Se define una Clave Primaria Compuesta.
    -- Esto garantiza que la combinación de un usuario y un tipo sea única.
    -- Un usuario no puede tener el rol "Admin" dos veces.
    PRIMARY KEY (UsuarioID, TipoUsuarioID),

    -- 2. Se define la Clave Foránea (Foreign Key) hacia la tabla Usuario.
    -- Esto asegura que cada UsuarioID en esta tabla DEBE existir en la tabla Usuario.
    CONSTRAINT FK_Relacion_Usuario
        FOREIGN KEY (UsuarioID)
        REFERENCES Usuario(UsuarioId)
        ON DELETE CASCADE, -- Opcional: si se borra un usuario, se borra la relación automáticamente.

    -- 3. Se define la Clave Foránea (Foreign Key) hacia la tabla TipoUsuario.
    -- Esto asegura que cada TipoUsuarioID en esta tabla DEBE existir en la tabla TipoUsuario.
    CONSTRAINT FK_Relacion_TipoUsuario
        FOREIGN KEY (TipoUsuarioID)
        REFERENCES TipoUsuario(TipoUsuarioID)
        ON DELETE CASCADE -- Opcional: si se borra un tipo de usuario, se borra la relación.
);



SELECT
    U.UsuarioID,
    U.Contraseña, -- O cualquier otro campo de la tabla Usuario que quieras ver
    TU.NombreTipoUsuario AS RolAsignado
FROM
    Usuario AS U
LEFT JOIN
    RelacionUsuarioTipoUsuario AS R ON U.UsuarioID = R.UsuarioID
LEFT JOIN
    TipoUsuario AS TU ON R.TipoUsuarioID = TU.TipoUsuarioID
ORDER BY
    U.UsuarioID;


