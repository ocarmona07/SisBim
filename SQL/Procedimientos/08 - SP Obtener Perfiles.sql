/*
Nombre: ObtenerPerfiles
Descripción: Obtiene todos los perfiles de la BD
*/

USE SisBim;
GO

IF OBJECT_ID(N'ObtenerPerfiles', N'P') IS NOT NULL
    DROP PROC ObtenerPerfiles;
GO

CREATE PROC ObtenerPerfiles
AS
    BEGIN
        SELECT  IdPerfil ,
                NombrePerfil ,
                Descripcion ,
                Estado
        FROM    dbo.Perfiles;
    END;