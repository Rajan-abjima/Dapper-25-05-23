using DataAccess.DbAccess;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data;
public class StudentData : IStudentData
{
    private readonly ISqlDataAccess _db;

    public StudentData(ISqlDataAccess db)
    {
        _db = db;
    }

    public Task<IEnumerable<StudentModel>> GetStudents() =>
        _db.LoadData<StudentModel, dynamic>(storedProcedure: "dbo.spStudent_GetAll", new { });

    public async Task<StudentModel?> GetStudent(int RollNo)
    {
        var results = await _db.LoadData<StudentModel, dynamic>(
            storedProcedure: "dbo.spStudent_Get",
            new { RollNo = RollNo });
        return results.FirstOrDefault();
    }

    public Task InsertStudent(StudentModel student) =>
        _db.SaveData(storedProcedure: "dbo.spStudent_Insert",
            new { student.Name, student.FamilyName, student.Address, student.Contact });

    public Task UpdateStudent(StudentModel student) =>
        _db.SaveData(storedProcedure: "dbo.spStudent_Update", student);

    public Task DeleteStudent(int rollNo) =>
        _db.SaveData(storedProcedure: "dbo.spStudent_Delete", new { RollNo= rollNo });
}
