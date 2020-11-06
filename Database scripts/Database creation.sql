/*
More tables will be added
*/

CREATE DATABASE [InfoPortal]

GO

CREATE TABLE [InfoPortal].[dbo].[Articles]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
	[Name] VARCHAR(50) NOT NULL, 
	[Theme] VARCHAR(50) NOT NULL, 
	[AddedOn] DATETIME NOT NULL DEFAULT GETDATE(),
	[Language] VARCHAR(50) NOT NULL,
	[Picture] VARCHAR(100) NOT NULL, 
	[Video] VARCHAR(100) NOT NULL, 
	[Link] INT NOT NULL
)