USE DbP8;
GO

-- This checks if the user exists already
SELECT name FROM sys.database_principals WHERE name = 'DESKTOP-615JHDG\user';
GO

-- This will map the existing login to the DB
CREATE USER [DESKTOP-615JHDG\user] FOR LOGIN [DESKTOP-615JHDG\user];
GO

-- Grant permissions (you could use db_datareader, db_datawriter instead)
ALTER ROLE db_owner ADD MEMBER [DESKTOP-615JHDG\user];

USE master;
GO

CREATE LOGIN [DESKTOP-615JHDG\user] FROM WINDOWS;
GO

SELECT SYSTEM_USER;

IF EXISTS (SELECT * FROM sys.databases WHERE name = 'DbP8')
    DROP DATABASE DbP8;
ELSE
    CREATE DATABASE DbP8;
GO

USE DbP8;
GO

IF EXISTS (SELECT * FROM sys.tables WHERE name = 'Students')
    DROP TABLE Students;
ELSE
CREATE TABLE Students (
    roll INT PRIMARY KEY,
    name NVARCHAR(255) NOT NULL,
    bday DATETIME NOT NULL,
    branch INT NOT NULL CHECK (branch IN (0, 1))
);
GO

SELECT * FROM Students;