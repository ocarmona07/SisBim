/*
Nombre: ObtenerUsuario
Descripción: Obtiene un usuario de la BD por RUT
*/

USE SisBim;
GO

IF OBJECT_ID(N'ObtenerUsuario', N'P') IS NOT NULL
    DROP PROC ObtenerUsuario;
GO

CREATE PROC ObtenerUsuario ( @Rut VARCHAR(9) )
AS
    BEGIN
        SELECT  RUT ,
                Nombres ,
                ApellidoPaterno ,
                ApellidoMaterno ,
                IdPerfil ,
                Clave ,
                Estado
        FROM    dbo.Usuarios
        WHERE   RUT = @Rut;
    END;