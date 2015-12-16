/*
Nombre: InsertarPerfil
Descripción: Inserta un perfil a la BD
*/

USE SisBim;
GO

IF OBJECT_ID(N'InsertarPerfil', N'P') IS NOT NULL
    DROP PROC InsertarPerfil;
GO

CREATE PROC InsertarPerfil
    (
      @NombrePerfil VARCHAR(20) ,
      @Descripcion VARCHAR(MAX) ,
      @Estado BIT
    )
AS
    BEGIN TRY
        BEGIN TRAN;
        INSERT  INTO dbo.Perfiles
                ( NombrePerfil ,
                  Descripcion ,
                  Estado
                )
        VALUES  ( @NombrePerfil ,
                  @Descripcion ,
                  @Estado
                );

        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
    END CATCH;