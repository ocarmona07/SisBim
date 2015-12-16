/*
Nombre: EliminarUsuario
Descripción: Elimina un usuario de la BD
*/

USE SisBim;
GO

IF OBJECT_ID(N'EliminarUsuario', N'P') IS NOT NULL
    DROP PROC EliminarUsuario;
GO

CREATE PROC EliminarUsuario ( @Rut INT )
AS
    BEGIN
        DELETE  FROM dbo.Usuarios
        WHERE   RUT = @Rut;
    END;