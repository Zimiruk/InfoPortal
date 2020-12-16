USE [InfoPortal] 
GO  
CREATE PROCEDURE DeleteThemes
	@id int
AS   
DELETE FROM Themes Where Id = @id
GO  