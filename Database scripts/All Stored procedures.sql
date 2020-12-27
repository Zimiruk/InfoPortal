/*ARTICLES*/

USE [InfoPortal] 
GO  
CREATE PROCEDURE CreateArticle  
	@name varchar(50),
	@addedOn datetime,
	@languageId int,
	@link int
AS   
INSERT INTO Articles(Name, AddedOn, LanguageId, Link)
VALUES (@name, @addedOn, @languageId, @link);
RETURN SCOPE_IDENTITY()
GO  

/************************************************************************************/

USE [InfoPortal];  
GO  
CREATE PROCEDURE GetArticle  
    @id int
AS   
    SELECT Id, Name, AddedOn, LanguageId, Link
    FROM Articles 
    WHERE Id = @id 
GO  

/************************************************************************************/

USE [InfoPortal];  
GO  
CREATE PROCEDURE GetArticles  
AS   
    SELECT Id, Name, AddedOn, LanguageId, Link
    FROM Articles 
GO  

/************************************************************************************/

USE [InfoPortal] 
GO  
CREATE PROCEDURE UpdateArticle  
    @id int,
	@name varchar(50),	
	@addedOn datetime,
	@languageId int,
	@link int
AS   

UPDATE Articles

SET 
Name = @name,
AddedOn = @addedOn,
LanguageId = @languageId,
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

USE [InfoPortal] 
GO
CREATE PROCEDURE [dbo].[GetArticlesByLanguageId]    
    @Id int
AS   
    SELECT Articles.Id, Articles.Name, AddedOn, LanguageId, Link
    FROM Articles

    WHERE LanguageId = @Id

/***********************************************************************************/


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

USE [InfoPortal]
GO  
CREATE PROCEDURE GetThemesByArticleId    
	@Id int
	AS   
    SELECT Themes.Id, Name
    FROM Themes
	INNER JOIN Article_Themes
ON Themes.Id = Article_Themes.ThemeId

    WHERE Article_Themes.ArticleId = @Id
GO  

/***************************************************************************/

USE [InfoPortal]  
GO  
CREATE PROCEDURE GetArticlesByThemeId    
    @Id int
AS   
    SELECT Articles.Id, Articles.Name, AddedOn, LanguageId, Link
    FROM Articles
	INNER JOIN Article_Themes
ON Articles.Id = Article_Themes.ArticleId

    WHERE Article_Themes.ThemeId = @Id

GO

	/*LANGUAGES*/

USE [InfoPortal] 
GO  
CREATE PROCEDURE CreateLanguage
	@name varchar(50)

AS   
INSERT INTO Languages(Name)
VALUES (@name);
RETURN SCOPE_IDENTITY()
GO  

/***************************************************************************/

USE [InfoPortal] 
GO  
CREATE PROCEDURE DeleteLanguage
	@id int
AS   
DELETE FROM Languages Where Id = @id
GO  

/***************************************************************************/

USE [InfoPortal];  
GO  
CREATE PROCEDURE GetLanguage
    @id int
AS   
    SELECT Id, Name
    FROM Languages
    WHERE Id = @id 
GO 

/***************************************************************************/

USE [InfoPortal];  
GO  
CREATE PROCEDURE GetLanguages
AS   
    SELECT Id, Name
    FROM Languages
GO 

/***************************************************************************/

USE [InfoPortal] 
GO  
CREATE PROCEDURE UpdateLanguage 
    @id int,
	@name varchar(50)
AS   

UPDATE Languages

SET 
Name = @name
WHERE Id = @id
GO

