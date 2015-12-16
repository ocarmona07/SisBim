/*
Nombre: ObtenerPerfil
Descripción: Obtiene un perfil de la BD por Id
*/

USE SisBim;
GO

IF OBJECT_ID(N'ObtenerPerfil', N'P') IS NOT NULL
    DROP PROC ObtenerPerfil;
GO

CREATE PROC ObtenerPerfil ( @IdPerfil INT )
AS
    BEGIN
        SELECT  IdPerfil ,
                NombrePerfil ,
                Descripcion ,
                Estado
        FROM    dbo.Perfiles
        WHERE   IdPerfil = @IdPerfil;
    END;