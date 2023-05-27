CREATE PROCEDURE [dbo].[spStudent_Insert]
	@Name nvarchar(50),
	@FamilyName nvarchar(50),
	@Address nvarchar(100),
	@Contact nvarchar(10)
AS
begin
	insert into dbo.[Student](Name, FamilyName, Address, Contact)
	values (@Name,@FamilyName,@Address,@Contact);
end
