/*
Nombre: ObtenerReservas
Descripción: Obtiene todas las reservas de la BD
*/

USE SisBim;
GO

IF OBJECT_ID(N'ObtenerReservas', N'P') IS NOT NULL
    DROP PROC ObtenerReservas;
GO

CREATE PROC ObtenerReservas
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
        FROM    dbo.Reservas;
    END;