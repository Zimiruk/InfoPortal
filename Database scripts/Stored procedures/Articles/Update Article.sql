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