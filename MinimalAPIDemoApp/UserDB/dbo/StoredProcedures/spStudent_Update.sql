CREATE PROCEDURE [dbo].[spStudent_Update]
	@RollNo int,
	@Name nvarchar(50),
	@FamilyName nvarchar(50),
	@Address nvarchar(100),
	@Contact nvarchar(10)
AS
begin
	update dbo.[Student]
	set Name = @Name, FamilyName = @FamilyName, Contact = @Contact
	where RollNo = @RollNo;
end
