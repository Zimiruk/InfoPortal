USE [InfoPortal] 
GO  
CREATE PROCEDURE CreateArticle  
	@name varchar(50),
	@themeId int,
	@addedOn datetime,
	@language varchar(50),
	@link int
AS   
INSERT INTO Articles(Name, ThemeId, AddedOn, Language, Link)
VALUES (@name, @themeId, @addedOn, @language, @link);
RETURN SCOPE_IDENTITY()
GO  

/************************************************************************************/

USE [InfoPortal];  
GO  
CREATE PROCEDURE GetArticle  
    @id int
AS   
    SELECT Id, Name, ThemeId, AddedOn, Language, Link
    FROM Articles 
    WHERE Id = @id 
GO  

/************************************************************************************/

USE [InfoPortal];  
GO  
CREATE PROCEDURE GetArticles  
AS   
    SELECT Id, Name, ThemeId, AddedOn, Language, Link
    FROM Articles 
GO  

/************************************************************************************/

USE [InfoPortal] 
GO  
CREATE PROCEDURE UpdateArticle  
    @id int,
	@name varchar(50),
	@themeId int,
	@addedOn datetime,
	@language varchar(50),
	@link int
AS   

UPDATE Articles

SET 
Name = @name,
ThemeId = @themeId,
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

