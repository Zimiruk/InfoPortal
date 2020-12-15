/*ARTICLES*/

USE [InfoPortal] 
GO  
CREATE PROCEDURE CreateArticle  
	@name varchar(50),
	@theme varchar(50),
	@addedOn datetime,
	@language varchar(50),
	@link int
AS   
INSERT INTO Articles(Name, Theme, AddedOn, Language, Link)
VALUES (@name, @theme, @addedOn, @language, @link);
RETURN SCOPE_IDENTITY()
GO  

/************************************************************************************/

USE [InfoPortal];  
GO  
CREATE PROCEDURE GetArticle  
    @id int
AS   
    SELECT Id, Name, Theme, AddedOn, Language, Link
    FROM Articles 
    WHERE Id = @id 
GO  

/************************************************************************************/

USE [InfoPortal];  
GO  
CREATE PROCEDURE GetArticles  
AS   
    SELECT Id, Name, Theme, AddedOn, Language, Link
    FROM Articles 
GO  

/************************************************************************************/

USE [InfoPortal] 
GO  
CREATE PROCEDURE UpdateArticle  
    @id int,
	@name varchar(50),
	@theme varchar(50),
	@addedOn datetime,
	@language varchar(50),
	@link int
AS   

UPDATE Articles

SET 
Name = @name,
Theme = @theme,
AddedOn = @addedOn,
Language = @language,
Link = @link

WHERE Id = @id
GO

/************************************************************************************/

USE [InfoPortal] 
GO  
CREATE PROCEDURE DeleteArticle  
	@id int
AS   
DELETE FROM Articles Where Id = @id
GO  

/*FILES*/

USE [InfoPortal] 
GO  
CREATE PROCEDURE AddFile 
	@Content varbinary(max),
	@ArticleId int,
	@Type varchar(50)
AS   
INSERT INTO Files(Content, ArticleId, Type)
VALUES (@Content, @ArticleId, @Type);
RETURN SCOPE_IDENTITY()
GO  

/************************************************************************************/

USE [InfoPortal] 
GO  
CREATE PROCEDURE GetFilesByArticleId
    @id int
AS   
    SELECT Id, ArticleId, Content, Type
    FROM Files 
    WHERE ArticleId = @id
GO

/************************************************************************************/

USE [InfoPortal] 
GO  
CREATE PROCEDURE DeleteFile 
	@id int
AS   
DELETE FROM Files Where Id = @id
GO  


