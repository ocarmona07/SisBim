/*
Nombre: ObtenerReserva
Descripción: Obtiene una reserva de la BD por Id
*/

USE SisBim;
GO

IF OBJECT_ID(N'ObtenerReserva', N'P') IS NOT NULL
    DROP PROC ObtenerReserva;
GO

CREATE PROC ObtenerReserva ( @IdReserva INT )
AS
    BEGIN
        SELECT  IdReserva ,
                IdSala ,
                RUT ,
                NombreCliente ,
                FechaReserva ,
                HoraInicio ,
                HoraFin ,
                EsPrivado ,
                Pagado ,
                FirmaActa ,
                Estado
        FROM    dbo.Reservas
        WHERE   IdReserva = @IdReserva;
    END;