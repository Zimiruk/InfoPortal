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
