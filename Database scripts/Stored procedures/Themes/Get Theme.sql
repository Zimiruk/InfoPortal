USE [InfoPortal];  
GO  
CREATE PROCEDURE GetTheme
    @id int
AS   
    SELECT Id, Name
    FROM Themes
    WHERE Id = @id 
GO  