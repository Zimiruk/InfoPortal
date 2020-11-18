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