CREATE PROCEDURE [dbo].[spStudent_Get]
	@RollNo int
AS
begin
	SELECT RollNo, Name, FamilyName, Address, Contact
	from dbo.[Student]
	where RollNo = @RollNo;
end

