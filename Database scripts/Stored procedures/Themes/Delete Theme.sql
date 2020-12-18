USE [InfoPortal] 
GO  
CREATE PROCEDURE DeleteTheme
	@id int
AS   
DELETE FROM Themes Where Id = @id
GO  