/*
Nombre: ActualizarUsuarios
Descripción: Actualiza un usuario de la BD
*/

USE SisBim;
GO

IF OBJECT_ID(N'ActualizarUsuario', N'P') IS NOT NULL
    DROP PROC ActualizarUsuario;
GO

CREATE PROC ActualizarUsuario
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

        UPDATE  dbo.Usuarios
        SET     Nombres = @Nombres ,
                ApellidoPaterno = @ApPaterno ,
                ApellidoMaterno = @ApMaterno ,
                IdPerfil = @IdPerfil ,
                Clave = @Clave ,
                Estado = @Estado
        WHERE   RUT = @RUT;

        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
    END CATCH;