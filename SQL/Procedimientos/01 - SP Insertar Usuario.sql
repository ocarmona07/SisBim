/*
Nombre: InsertarUsuarios
Descripción: Inserta un usuario a la BD
*/

USE SisBim;
GO

IF OBJECT_ID(N'InsertarUsuarios', N'P') IS NOT NULL
    DROP PROC InsertarUsuarios;
GO

CREATE PROC InsertarUsuarios
    (
      @RUT VARCHAR(9) ,
      @Nombres VARCHAR(30) ,
      @ApPaterno VARCHAR(30) ,
      @ApMaterno VARCHAR(30) ,
      @IdPerfil INT ,
      @Clave VARCHAR(16) ,
      @Estado BIT
    )
AS
    BEGIN TRY
        BEGIN TRAN;
        INSERT  INTO dbo.Usuarios
                ( RUT ,
                  Nombres ,
                  ApellidoPaterno ,
                  ApellidoMaterno ,
                  IdPerfil ,
                  Clave ,
                  Estado
                )
        VALUES  ( @RUT ,
                  @Nombres ,
                  @ApPaterno ,
                  @ApMaterno ,
                  @IdPerfil ,
                  @Clave ,
                  @Estado 
                );

        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
    END CATCH;