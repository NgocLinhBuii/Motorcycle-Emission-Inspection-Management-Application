USE [master];
GO

CREATE DATABASE [db_prn];
GO

ALTER DATABASE [db_prn] SET COMPATIBILITY_LEVEL = 160;
GO

USE [db_prn];
GO

-- Enable Full-Text Search if installed
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
BEGIN
    EXEC [db_prn].[dbo].[sp_fulltext_database] @action = 'enable';
END
GO

-- Tables and Constraints

CREATE TABLE [dbo].[__EFMigrationsHistory](
    [MigrationId] NVARCHAR(150) NOT NULL,
    [ProductVersion] NVARCHAR(32) NOT NULL,
    CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED ([MigrationId] ASC)
);

CREATE TABLE [dbo].[InspectionStations](
    [StationID] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [Name] NVARCHAR(100) NOT NULL,
    [Address] NVARCHAR(MAX) NOT NULL,
    [Phone] NVARCHAR(15) NOT NULL,
    [Email] NVARCHAR(100) NOT NULL UNIQUE
);

CREATE TABLE [dbo].[Roles](
    [RoleID] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [RoleName] NVARCHAR(50) NOT NULL UNIQUE
);

CREATE TABLE [dbo].[Users](
    [UserID] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [FullName] NVARCHAR(100) NOT NULL,
    [Email] NVARCHAR(100) NOT NULL UNIQUE,
    [Password] NVARCHAR(255) NOT NULL,
    [RoleID] INT NOT NULL,
    [Phone] NVARCHAR(15) NOT NULL,
    [Address] NVARCHAR(MAX) NOT NULL,
    [StationID] INT NULL
);

CREATE TABLE [dbo].[Vehicles](
    [VehicleID] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [OwnerID] INT NOT NULL,
    [PlateNumber] NVARCHAR(15) NOT NULL UNIQUE,
    [Brand] NVARCHAR(50) NOT NULL,
    [Model] NVARCHAR(50) NOT NULL,
    [ManufactureYear] INT NOT NULL CHECK ([ManufactureYear] >= 1950 AND [ManufactureYear] <= YEAR(GETDATE())),
    [EngineNumber] NVARCHAR(100) NOT NULL
);

CREATE TABLE [dbo].[InspectionRecords](
    [RecordID] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [VehicleID] INT NOT NULL,
    [StationID] INT NOT NULL,
    [InspectorID] INT NULL,
    [InspectionDate] DATETIME NULL DEFAULT GETDATE(),
    [Result] NVARCHAR(50) NULL CHECK ([Result] IN ('Fail', 'Pass')),
    [CO2Emission] DECIMAL(18,2) NULL,
    [HCEmission] DECIMAL(18,2) NULL,
    [Comments] NVARCHAR(MAX) NULL
);

CREATE TABLE [dbo].[Logs](
    [LogID] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [UserID] INT NOT NULL,
    [Action] NVARCHAR(100) NOT NULL,
    [Timestamp] DATETIME NULL DEFAULT GETDATE()
);

CREATE TABLE [dbo].[Notifications](
    [NotificationID] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [UserID] INT NOT NULL,
    [Message] NVARCHAR(MAX) NOT NULL,
    [SentDate] DATETIME NULL DEFAULT GETDATE(),
    [IsRead] BIT NULL DEFAULT 0
);

ALTER TABLE [dbo].[Users] ADD CONSTRAINT [FK_Users_RoleID] FOREIGN KEY ([RoleID]) REFERENCES [dbo].[Roles] ([RoleID]);
ALTER TABLE [dbo].[Users] ADD CONSTRAINT [FK_Users_StationID] FOREIGN KEY ([StationID]) REFERENCES [dbo].[InspectionStations] ([StationID]);
ALTER TABLE [dbo].[Vehicles] ADD CONSTRAINT [FK_Vehicles_OwnerID] FOREIGN KEY ([OwnerID]) REFERENCES [dbo].[Users] ([UserID]);
ALTER TABLE [dbo].[InspectionRecords] ADD CONSTRAINT [FK_Records_Vehicle] FOREIGN KEY ([VehicleID]) REFERENCES [dbo].[Vehicles] ([VehicleID]);
ALTER TABLE [dbo].[InspectionRecords] ADD CONSTRAINT [FK_Records_Station] FOREIGN KEY ([StationID]) REFERENCES [dbo].[InspectionStations] ([StationID]);
ALTER TABLE [dbo].[InspectionRecords] ADD CONSTRAINT [FK_Records_Inspector] FOREIGN KEY ([InspectorID]) REFERENCES [dbo].[Users] ([UserID]);
ALTER TABLE [dbo].[Logs] ADD CONSTRAINT [FK_Logs_User] FOREIGN KEY ([UserID]) REFERENCES [dbo].[Users] ([UserID]);
ALTER TABLE [dbo].[Notifications] ADD CONSTRAINT [FK_Notifications_User] FOREIGN KEY ([UserID]) REFERENCES [dbo].[Users] ([UserID]);

USE [master];
GO
ALTER DATABASE [db_prn] SET READ_WRITE;
GO