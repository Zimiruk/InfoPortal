CREATE TABLE [InfoPortal].[dbo].[Files]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [ArticleId] INT NOT NULL,
	[Name] VARCHAR(50) NOT NULL, 
)

GO