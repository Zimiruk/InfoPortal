/*ARTICLES*/

USE [InfoPortal] 
GO  
CREATE PROCEDURE CreateArticle  
	@name varchar(50),
	@addedOn datetime,
	@language varchar(50),
	@link int
AS   
INSERT INTO Articles(Name, AddedOn, Language, Link)
VALUES (@name, @addedOn, @language, @link);
RETURN SCOPE_IDENTITY()
GO  

/************************************************************************************/

USE [InfoPortal];  
GO  
CREATE PROCEDURE GetArticle  
    @id int
AS   
    SELECT Id, Name, AddedOn, Language, Link
    FROM Articles 
    WHERE Id = @id 
GO  

/************************************************************************************/

USE [InfoPortal];  
GO  
CREATE PROCEDURE GetArticles  
AS   
    SELECT Id, Name, AddedOn, Language, Link
    FROM Articles 
GO  

/************************************************************************************/

USE [InfoPortal] 
GO  
CREATE PROCEDURE UpdateArticle  
    @id int,
	@name varchar(50),	
	@addedOn datetime,
	@language varchar(50),
	@link int
AS   

UPDATE Articles

SET 
Name = @name,
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

/*THEMES*/

USE [InfoPortal] 
GO  
CREATE PROCEDURE CreateTheme
	@name varchar(50)

AS   
INSERT INTO Themes(Name)
VALUES (@name);
RETURN SCOPE_IDENTITY()
GO  

/***************************************************************************/

USE [InfoPortal] 
GO  
CREATE PROCEDURE DeleteTheme
	@id int
AS   
DELETE FROM Themes Where Id = @id
GO  

/***************************************************************************/

USE [InfoPortal];  
GO  
CREATE PROCEDURE GetTheme
    @id int
AS   
    SELECT Id, Name
    FROM Themes
    WHERE Id = @id 
GO 

/***************************************************************************/

USE [InfoPortal];  
GO  
CREATE PROCEDURE GetThemes
AS   
    SELECT Id, Name
    FROM Themes
GO 

/***************************************************************************/

USE [InfoPortal] 
GO  
CREATE PROCEDURE UpdateTheme 
    @id int,
	@name varchar(50)
AS   

UPDATE Themes

SET 
Name = @name
WHERE Id = @id
GO

/*ARTICLE_THEMES*/

USE [InfoPortal] 
GO  
CREATE PROCEDURE AddThemeToArticle
   @ArticleId int,
   @ThemeId int

AS   
INSERT INTO Article_Themes(ArticleId, ThemeId)
VALUES (@ArticleId, @ThemeId );
GO  

/***************************************************************************/

USE [InfoPortal] 
GO  
CREATE PROCEDURE DeleteAllByArticleId
	@ArticleId int
AS   
DELETE FROM Article_Themes Where ArticleId = @ArticleId
GO  

/***************************************************************************/

USE [InfoPortal];  
GO  
CREATE PROCEDURE GetThemesIdByArticleId
    @ArticleId int
AS   
    SELECT ArticleId, ThemeId
    FROM Article_Themes
    WHERE ArticleId = @ArticleId
GO 

