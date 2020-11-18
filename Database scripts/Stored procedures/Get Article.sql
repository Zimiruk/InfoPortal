USE [InfoPortal];  
GO  
CREATE PROCEDURE GetArticle  
    @id int
AS   
    SELECT Id, Name, Theme, AddedOn, Language, Picture, Video, Link
    FROM Articles 
    WHERE Id = @id 
GO  