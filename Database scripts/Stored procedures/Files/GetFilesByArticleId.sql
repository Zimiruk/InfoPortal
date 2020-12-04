USE [InfoPortal] 
GO  
CREATE PROCEDURE GetFilesByArticleId
    @id int
AS   
    SELECT Id, Content, ArticleId
    FROM Files 
    WHERE ArticleId = @id
