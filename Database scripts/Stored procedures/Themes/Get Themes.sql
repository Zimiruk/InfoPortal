USE [InfoPortal];  
GO  
CREATE PROCEDURE GetThemes
AS   
    SELECT Id, Name
    FROM Themes
GO  