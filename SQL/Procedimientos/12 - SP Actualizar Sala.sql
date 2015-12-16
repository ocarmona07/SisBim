/*
Nombre: ActualizarSala
Descripción: Actualiza una sala en la BD
*/

USE SisBim;
GO

IF OBJECT_ID(N'ActualizarSala', N'P') IS NOT NULL
    DROP PROC ActualizarSala;
GO

CREATE PROC ActualizarSala
    (
      @IdSala INT ,
      @NombreSala VARCHAR(30) ,
      @Descripcion VARCHAR(MAX) ,
      @Imagen VARCHAR(MAX) ,
      @Detalles VARCHAR(MAX) ,
      @Estado BIT
    )
AS
    BEGIN TRY
        BEGIN TRAN;

        UPDATE  dbo.Salas
        SET     NombreSala = @NombreSala ,
                Descripcion = @Descripcion ,
                Imagen = @Imagen ,
                Detalles = @Detalles ,
                Estado = @Estado
        WHERE   IdSala = @IdSala;

        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
    END CATCH;