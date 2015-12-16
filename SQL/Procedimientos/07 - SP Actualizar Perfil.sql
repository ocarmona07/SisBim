/*
Nombre: ActualizarPerfil
Descripción: Actualiza un perfil de la BD
*/

USE SisBim;
GO

IF OBJECT_ID(N'ActualizarPerfil', N'P') IS NOT NULL
    DROP PROC ActualizarPerfil;
GO

CREATE PROC ActualizarPerfil
    (
      @IdPerfil INT ,
      @NombrePerfil VARCHAR(20) ,
      @Descripcion VARCHAR(MAX) ,
      @Estado BIT
    )
AS
    BEGIN TRY
        BEGIN TRAN;

        UPDATE  dbo.Perfiles
        SET     NombrePerfil = @NombrePerfil ,
                Descripcion = @Descripcion ,
                Estado = @Estado
        WHERE   IdPerfil = @IdPerfil;

        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
    END CATCH;