namespace MinimalAPI;

public static class API
{
    public static void ConfigureAPI(this WebApplication app)
    {
        //endpoints mapping
        app.MapGet("/students", GetStudents);
        app.MapGet("/students/{RollNo}", GetStudent);
        app.MapPost("/students", InsertStudent);
        app.MapPut("/students", UpdateStudent);
        app.MapDelete("/students", DeleteStudent);
    }

    private static async Task<IResult> GetStudents(IStudentData data)
    {
        try
        {
            return Results.Ok(await data.GetStudents());
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> GetStudent(int RollNo, IStudentData data)
    {
        try
        {
            var results = Results.Ok(await data.GetStudent(RollNo));
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> InsertStudent(StudentModel student, IStudentData data)
    {
        try
        {
            await data.InsertStudent(student);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> UpdateStudent(StudentModel student, IStudentData data)
    {
        try
        {
            await data.UpdateStudent(student);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> DeleteStudent(int rollNo, IStudentData data)
    {
        try
        {
            await data.DeleteStudent(rollNo);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }


}
