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
	[Image] varbinary(MAX) NULL,
	[Video] varbinary(MAX) NULL,
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


CREATE TABLE [InfoPortal].[dbo].[Roles]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    [Name] VARCHAR(50) NOT NULL
)
GO

CREATE TABLE [InfoPortal].[dbo].[Users]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    [Login] VARCHAR(50) NOT NULL,
	[Email] VARCHAR(50) NOT NULL,
	[Password] VARCHAR(50) NOT NULL,
	[RoleId] int NOT NULL

	CONSTRAINT FK_User_Roles FOREIGN KEY (RoleId)
    REFERENCES Roles (Id)
    ON DELETE CASCADE      
)
GO

INSERT INTO [InfoPortal].[dbo].[Roles] (Name)
VALUES 
  ('Admin'), 
  ('Editor')

  INSERT INTO [InfoPortal].[dbo].[Users] (Login, Email, Password, RoleId)
VALUES 
  ('Admin', 'Admin@mamail.com', 'Admin', 1), 
  ('Editor', 'Editor@mamail.com', 'Editor', 2)