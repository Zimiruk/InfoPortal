USE [InfoPortal] 
GO  
CREATE PROCEDURE UpdateTheme 
    @id int,
	@name varchar(50)
AS   

UPDATE Themes

SET 
Name = @name
WHERE Id = @id
GO