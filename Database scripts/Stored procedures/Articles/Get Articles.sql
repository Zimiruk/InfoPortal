USE [InfoPortal];  
GO  
CREATE PROCEDURE GetArticles  
AS   
    SELECT Id, Name, Theme, AddedOn, Language, Link
    FROM Articles 
GO  