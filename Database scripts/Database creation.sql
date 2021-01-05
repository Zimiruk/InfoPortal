/*
More tables will be added
*/

CREATE DATABASE [InfoPortal]

GO

CREATE TABLE [InfoPortal].[dbo].[Languages]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
	[Name] VARCHAR(50) NOT NULL
)
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
	[AddedOn] DATETIME NOT NULL		DEFAULT GETDATE(),
	[LanguageId] INT NOT NULL,
    [Text] TEXT

	CONSTRAINT FK_Article_Language FOREIGN KEY (LanguageId)
    REFERENCES Languages (Id)      
)
GO

CREATE TABLE [InfoPortal].[dbo].[Article_Themes]
(
	[ArticleId] INT NOT NULL, 
	[ThemeId] INT  NOT NULL, 
	CONSTRAINT FK_Article 
      FOREIGN KEY (ArticleId) REFERENCES Articles (Id)
		ON DELETE CASCADE    ,
	CONSTRAINT FK_Theme
      FOREIGN KEY (ThemeId) REFERENCES Themes (Id)
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


CREATE TABLE [InfoPortal].[dbo].[Users]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    [Login] VARCHAR(50) NOT NULL,
	[Email] VARCHAR(50) NOT NULL,
	[Password] VARCHAR(50) NOT NULL,
	[Role] VARCHAR(50) NOT NULL
)

GO





