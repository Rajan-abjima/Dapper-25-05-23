CREATE PROCEDURE [dbo].[spStudent_GetAll]
AS
begin
	SELECT RollNo, Name, FamilyName, Address, Contact
	from dbo.[Student]
end

