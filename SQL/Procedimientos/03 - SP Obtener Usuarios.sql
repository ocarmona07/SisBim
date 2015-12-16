/*
Nombre: ObtenerUsuarios
Descripción: Obtiene todos los usuarios de la BD
*/

USE SisBim;
GO

IF OBJECT_ID(N'ObtenerUsuarios', N'P') IS NOT NULL
    DROP PROC ObtenerUsuarios;
GO

CREATE PROC ObtenerUsuarios
AS
    BEGIN
        SELECT  RUT ,
                Nombres ,
                ApellidoPaterno ,
                ApellidoMaterno ,
                IdPerfil ,
                Clave ,
                Estado
        FROM    dbo.Usuarios;
    END;