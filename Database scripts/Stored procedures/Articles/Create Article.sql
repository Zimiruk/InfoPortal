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