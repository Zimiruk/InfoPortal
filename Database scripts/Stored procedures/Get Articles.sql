USE [InfoPortal];  
GO  
CREATE PROCEDURE GetArticles  
AS   
    SELECT Id, Name, Theme, AddedOn, Language, Picture, Video, Link
    FROM Articles 
GO  