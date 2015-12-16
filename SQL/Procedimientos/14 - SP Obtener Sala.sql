/*
Nombre: ObtenerSala
Descripción: Obtiene una sala de la BD por Id
*/

USE SisBim;
GO

IF OBJECT_ID(N'ObtenerSala', N'P') IS NOT NULL
    DROP PROC ObtenerSala;
GO

CREATE PROC ObtenerSala ( @IdSala INT )
AS
    BEGIN
        SELECT  IdSala ,
                NombreSala ,
                Descripcion ,
                Imagen ,
                Detalles ,
                Estado
        FROM    dbo.Salas
        WHERE   IdSala = @IdSala;
    END;