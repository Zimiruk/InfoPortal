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