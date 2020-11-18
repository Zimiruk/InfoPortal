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