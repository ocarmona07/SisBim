/*
Nombre: InsertarSala
Descripción: Inserta una sala en la BD
*/

USE SisBim;
GO

IF OBJECT_ID(N'InsertarSala', N'P') IS NOT NULL
    DROP PROC InsertarSala;
GO

CREATE PROC InsertarSala
    (
      @NombreSala VARCHAR(30) ,
      @Descripcion VARCHAR(MAX) ,
      @Imagen VARCHAR(MAX) ,
      @Detalles VARCHAR(MAX) ,
      @Estado BIT
    )
AS
    BEGIN TRY
        BEGIN TRAN;
        INSERT  INTO dbo.Salas
                ( NombreSala ,
                  Descripcion ,
                  Imagen ,
                  Detalles ,
                  Estado
                )
        VALUES  ( @NombreSala ,
                  @Descripcion ,
                  @Imagen ,
                  @Detalles ,
                  @Estado
                );

        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
    END CATCH;