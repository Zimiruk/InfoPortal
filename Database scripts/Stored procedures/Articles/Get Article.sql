USE [InfoPortal];  
GO  
CREATE PROCEDURE GetArticle  
    @id int
AS   
    SELECT Id, Name, Theme, AddedOn, Language, Link
    FROM Articles 
    WHERE Id = @id 
GO  