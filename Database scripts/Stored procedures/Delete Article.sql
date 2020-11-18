USE [InfoPortal] 
GO  
CREATE PROCEDURE DeleteArticle  
	@id int
AS   
DELETE FROM Articles Where Id = @id
GO  