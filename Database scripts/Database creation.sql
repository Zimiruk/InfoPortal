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
	[Link] INT NOT NULL
)
GO

CREATE TABLE [InfoPortal].[dbo].[Files]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    [ArticleId] INT NULL,

		CONSTRAINT FK_Article_Files FOREIGN KEY (ArticleId)
        REFERENCES Articles (Id)
        ON DELETE CASCADE
        ON UPDATE CASCADE,

	[Content] varbinary(MAX) NULL, 
)

GO

