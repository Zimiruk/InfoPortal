USE [InfoPortal] 
GO  
CREATE PROCEDURE CreateArticle  
	@name varchar(50),
	@theme varchar(50),
	@addedOn datetime,
	@language varchar(50),
	@picture varchar(100),
	@video varchar(100),
	@link int
AS   
INSERT INTO Articles(Name, Theme, AddedOn, Language, Picture, Video, Link)
VALUES (@name, @theme, @addedOn, @language, @picture, @video, @link);
RETURN SCOPE_IDENTITY()
GO  

/************************************************************************************/

USE [InfoPortal];  
GO  
CREATE PROCEDURE GetArticle  
    @id int
AS   
    SELECT Id, Name, Theme, AddedOn, Language, Picture, Video, Link
    FROM Articles 
    WHERE Id = @id 
GO  

/************************************************************************************/

USE [InfoPortal];  
GO  
CREATE PROCEDURE GetArticles  
AS   
    SELECT Id, Name, Theme, AddedOn, Language, Picture, Video, Link
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
	@picture varchar(100),
	@video varchar(100),
	@link int
AS   

UPDATE Articles

SET 
Name = @name,
Theme = @theme,
AddedOn = @addedOn,
Language = @language,
Picture = @picture,
Video = @video,
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

