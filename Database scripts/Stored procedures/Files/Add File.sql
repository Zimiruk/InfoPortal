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
