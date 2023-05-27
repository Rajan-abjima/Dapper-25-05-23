CREATE PROCEDURE [dbo].[spStudent_Delete]
	@RollNo int
AS
begin
	delete
	from dbo.[Student]
	where RollNo = @RollNo
end
