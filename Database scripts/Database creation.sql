/*
More tables will be added
*/

CREATE DATABASE [InfoPortal]

GO

CREATE TABLE [InfoPortal].[dbo].[Themes]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
	[Name] VARCHAR(50) NOT NULL
)
GO

CREATE TABLE [InfoPortal].[dbo].[Articles]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
	[Name] VARCHAR(50) NOT NULL, 
	[ThemeId] INT NULL, 
	[AddedOn] DATETIME NOT NULL DEFAULT GETDATE(),
	[Language] VARCHAR(50) NOT NULL,
	[Link] INT NOT NULL,

	CONSTRAINT FK_Themes_Articles FOREIGN KEY (ThemeId)
        REFERENCES Themes (Id)
        ON DELETE SET NULL
)
GO

CREATE TABLE [InfoPortal].[dbo].[Files]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    	[ArticleId] INT NULL,
	[Content] varbinary(MAX) NULL, 
	[Type] VARCHAR(50) NOT NULL

	CONSTRAINT FK_Article_Files FOREIGN KEY (ArticleId)
        REFERENCES Articles (Id)
        ON DELETE CASCADE       
)

GO



