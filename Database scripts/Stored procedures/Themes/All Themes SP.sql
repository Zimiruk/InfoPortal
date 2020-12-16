USE [InfoPortal] 
GO  
CREATE PROCEDURE CreateTheme
	@name varchar(50)

AS   
INSERT INTO Themes(Name)
VALUES (@name);
RETURN SCOPE_IDENTITY()
GO  

/***************************************************************************/

USE [InfoPortal] 
GO  
CREATE PROCEDURE DeleteThemes
	@id int
AS   
DELETE FROM Themes Where Id = @id
GO  

/***************************************************************************/

USE [InfoPortal];  
GO  
CREATE PROCEDURE GetTheme
    @id int
AS   
    SELECT Id, Name
    FROM Themes
    WHERE Id = @id 
GO 

/***************************************************************************/

USE [InfoPortal];  
GO  
CREATE PROCEDURE GetThemes
AS   
    SELECT Id, Name
    FROM Theme
GO 

/***************************************************************************/

USE [InfoPortal] 
GO  
CREATE PROCEDURE UpdateTheme 
    @id int,
	@name varchar(50)
AS   

UPDATE Articles

SET 
Name = @name
WHERE Id = @id
GO