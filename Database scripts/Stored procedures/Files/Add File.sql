USE [InfoPortal] 
GO  
CREATE PROCEDURE AddFile 
	@Content varbinary(max),
	@ArticleId int
AS   
INSERT INTO Files(Content, ArticleId)
VALUES (@Content, @ArticleId);
RETURN SCOPE_IDENTITY()
