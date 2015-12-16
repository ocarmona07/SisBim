/*
Nombre: ObtenerSalas
Descripción: Obtiene todas las salas de la BD
*/

USE SisBim;
GO

IF OBJECT_ID(N'ObtenerSalas', N'P') IS NOT NULL
    DROP PROC ObtenerSalas;
GO

CREATE PROC ObtenerSalas
AS
    BEGIN
        SELECT  IdSala ,
                NombreSala ,
                Descripcion ,
                Imagen ,
                Detalles ,
                Estado
        FROM    dbo.Salas;
    END;