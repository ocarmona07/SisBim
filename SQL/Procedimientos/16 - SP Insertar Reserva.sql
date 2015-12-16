/*
Nombre: InsertarReserva
Descripción: Inserta una reserva en la BD
*/

USE SisBim;
GO

IF OBJECT_ID(N'InsertarReserva', N'P') IS NOT NULL
    DROP PROC InsertarReserva;
GO

CREATE PROC InsertarReserva
    (
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
        INSERT  INTO dbo.Reservas
                ( IdSala ,
                  RUT ,
                  NombreCliente ,
                  FechaReserva ,
                  HoraInicio ,
                  HoraFin ,
                  EsPrivado ,
                  Pagado ,
                  FirmaActa ,
                  Estado
                )
        VALUES  ( @IdSala ,
                  @RutUsuario ,
                  @NombreCliente ,
                  @FechaReserva ,
                  @HoraInicio ,
                  @HoraFin ,
                  @EsPrivado ,
                  @Pagado ,
                  @FirmaActa ,
                  @Estado
                );

        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
    END CATCH;