/*
Nombre: EliminarReserva
Descripción: Elimina una reserva de la BD
*/

USE SisBim;
GO

IF OBJECT_ID(N'EliminarReserva', N'P') IS NOT NULL
    DROP PROC EliminarReserva;
GO

CREATE PROC EliminarReserva ( @IdReserva INT )
AS
    BEGIN
        DELETE  FROM dbo.Reservas
        WHERE   IdReserva = @IdReserva;
    END;