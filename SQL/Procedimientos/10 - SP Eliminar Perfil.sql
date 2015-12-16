/*
Nombre: EliminarPerfil
Descripción: Elimina un perfil de la BD
*/

USE SisBim;
GO

IF OBJECT_ID(N'EliminarPerfil', N'P') IS NOT NULL
    DROP PROC EliminarPerfil;
GO

CREATE PROC EliminarPerfil ( @IdPerfil INT )
AS
    BEGIN
        DELETE  FROM dbo.Perfiles
        WHERE   IdPerfil = @IdPerfil;
    END;