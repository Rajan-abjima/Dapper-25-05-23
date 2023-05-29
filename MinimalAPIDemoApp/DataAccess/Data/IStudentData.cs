using DataAccess.Models;

namespace DataAccess.Data;
public interface IStudentData
{
    Task DeleteStudent(int rollNo);
    Task<StudentModel?> GetStudent(int RollNo);
    Task<IEnumerable<StudentModel>> GetStudents();
    Task InsertStudent(StudentModel student);
    Task UpdateStudent(StudentModel student);
}