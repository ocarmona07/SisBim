/*
Nombre: EliminarSala
Descripción: Elimina una sala de la BD
*/

USE SisBim;
GO

IF OBJECT_ID(N'EliminarSala', N'P') IS NOT NULL
    DROP PROC EliminarSala;
GO

CREATE PROC EliminarSala ( @IdSala INT )
AS
    BEGIN
        DELETE  FROM dbo.Salas
        WHERE   IdSala = @IdSala;
    END;