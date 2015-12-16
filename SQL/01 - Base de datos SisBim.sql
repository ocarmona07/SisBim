USE master;
IF ( EXISTS ( SELECT    name
              FROM      master.dbo.sysdatabases
              WHERE     ( '[' + name + ']' = 'SisBim'
                          OR name = 'SisBim'
                        ) ) )
    BEGIN
        EXEC msdb.dbo.sp_delete_database_backuphistory @database_name = N'SisBim'
        ALTER DATABASE SisBim
        SET  SINGLE_USER WITH ROLLBACK IMMEDIATE
        DROP DATABASE SisBim                      	
    END
GO

CREATE DATABASE SisBim
GO

USE SisBim;

/*==============================================================*/
/* Table: Perfiles                                              */
/*==============================================================*/
CREATE TABLE Perfiles
    (
      IdPerfil INT IDENTITY ,
      NombrePerfil VARCHAR(20) NOT NULL ,
      Descripcion VARCHAR(MAX) NULL ,
      Estado BIT NOT NULL ,
      CONSTRAINT PK_PERFILES PRIMARY KEY ( IdPerfil )
    );
GO

/*==============================================================*/
/* Table: Reservas                                              */
/*==============================================================*/
CREATE TABLE Reservas
    (
      IdReserva INT IDENTITY ,
      IdSala INT NULL ,
      RUT VARCHAR(9) NULL ,
      NombreCliente VARCHAR(50) NOT NULL ,
      FechaReserva DATE NOT NULL ,
      HoraInicio TIME NOT NULL ,
      HoraFin TIME NOT NULL ,
      EsPrivado BIT NULL ,
      Pagado BIT NULL ,
      FirmaActa BIT NULL ,
      Estado BIT NULL ,
      CONSTRAINT PK_RESERVAS PRIMARY KEY ( IdReserva )
    );
GO

/*==============================================================*/
/* Table: Salas                                                 */
/*==============================================================*/
CREATE TABLE Salas
    (
      IdSala INT IDENTITY ,
      NombreSala VARCHAR(30) NOT NULL ,
      Descripcion VARCHAR(MAX) NULL ,
      Imagen VARCHAR(MAX) NULL ,
      Detalles VARCHAR(MAX) NOT NULL ,
      Estado BIT NOT NULL ,
      CONSTRAINT PK_SALAS PRIMARY KEY ( IdSala )
    );
GO

/*==============================================================*/
/* Table: Usuarios                                              */
/*==============================================================*/
CREATE TABLE Usuarios
    (
      RUT VARCHAR(9) NOT NULL ,
      Nombres VARCHAR(30) NOT NULL ,
      ApellidoPaterno VARCHAR(30) NOT NULL ,
      ApellidoMaterno VARCHAR(30) NULL ,
      IdPerfil INT NULL ,
      Clave VARCHAR(16) NOT NULL ,
      Estado BIT NOT NULL ,
      CONSTRAINT PK_USUARIOS PRIMARY KEY ( RUT )
    );
GO

ALTER TABLE Reservas
ADD CONSTRAINT FK_RESERVAS_REFERENCE_SALAS FOREIGN KEY (IdSala)
REFERENCES Salas (IdSala);
GO

ALTER TABLE Reservas
ADD CONSTRAINT FK_RESERVAS_REFERENCE_USUARIOS FOREIGN KEY (RUT)
REFERENCES Usuarios (RUT);
GO

ALTER TABLE Usuarios
ADD CONSTRAINT FK_USUARIOS_REFERENCE_PERFILES FOREIGN KEY (IdPerfil)
REFERENCES Perfiles (IdPerfil);
GO
