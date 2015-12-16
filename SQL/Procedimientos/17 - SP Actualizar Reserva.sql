/*
Nombre: ActualizarReserva
Descripción: Actualiza una reserva de la BD
*/

USE SisBim;
GO

IF OBJECT_ID(N'ActualizarReserva', N'P') IS NOT NULL
    DROP PROC ActualizarReserva;
GO

CREATE PROC ActualizarReserva
    (
      @IdReserva INT ,
      @IdSala INT ,
      @RutUsuario VARCHAR(9) ,
      @NombreCliente VARCHAR(50) ,
      @FechaReserva DATE ,
      @HoraInicio TIME ,
      @HoraFin TIME ,
      @EsPrivado BIT ,
      @Pagado BIT ,
      @FirmaActa BIT ,
      @Estado BIT
    )
AS
    BEGIN TRY
        BEGIN TRAN;

        UPDATE  dbo.Reservas
        SET     RUT = @RutUsuario ,
                IdSala = @IdSala ,
                NombreCliente = @NombreCliente ,
                FechaReserva = @FechaReserva ,
                HoraInicio = @HoraInicio ,
                HoraFin = @HoraFin ,
                EsPrivado = @EsPrivado ,
                Pagado = @Pagado ,
                FirmaActa = @FirmaActa ,
                Estado = @Estado
        WHERE   IdReserva = @IdReserva;

        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
    END CATCH;