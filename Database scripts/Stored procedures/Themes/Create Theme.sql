USE [InfoPortal] 
GO  
CREATE PROCEDURE CreateTheme
	@name varchar(50)

AS   
INSERT INTO Themes(Name)
VALUES (@name);
RETURN SCOPE_IDENTITY()
GO  