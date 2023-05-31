using Dapper.Application.Interfaces;
using Dapper.Core.Entities;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Dapper.Infrastructure.Repositories;
public class StudentRepository : IStudentRepository
{
    private readonly IConfiguration _configuration;

    public StudentRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public async Task<IReadOnlyList<Student>> GetAllAsync()
    {
        using (var connection = new SqlConnection(_configuration.GetConnectionString("Default")))
        {
            connection.Open();
            var records = await connection.QueryAsync<Student>
                ("spStudents_GetAll", new { }, commandType: CommandType.StoredProcedure);
            return records.ToList();
        }

    }
    public async Task<Student> GetByIdAsync(int rollNo)
    {        
        using (var connection = new SqlConnection(_configuration.GetConnectionString("Default")))
        {
            connection.Open();
            var record = await connection.QuerySingleOrDefaultAsync<Student>
                ("spStudents_Get", new { RollNo = rollNo }, commandType: CommandType.StoredProcedure);
            return record;
        }
    }
    public async Task<int> AddAsync(StudentWithT student)
    {
        student.AddedOn = DateTime.Now;
        using (var connection = new SqlConnection(_configuration.GetConnectionString("Default")))
        {
            connection.Open();
            var newRecord = await connection.ExecuteAsync
                ("spStudent_Insert",
                new {student.Name, student.FamilyName, student.Address, student.Contact, student.AddedOn}, 
                commandType: CommandType.StoredProcedure);
            return newRecord;
        }
    }
    public async Task<int> UpdateAsync(StudentWithT student)
    {
        student.ModifiedOn = DateTime.Now;
        using (var connection = new SqlConnection(_configuration.GetConnectionString("Default")))
        {
            connection.Open();
            var updatedRecord = await connection.ExecuteAsync
                ("spStudent_Update", student, commandType: CommandType.StoredProcedure);
            return updatedRecord;
        }
    }
    public async Task<int> DeleteAsync(int rollNo)
    {
        using(var connection = new SqlConnection(_configuration.GetConnectionString("Default")))
        {
            connection.Open();
            var changedRecord = await connection.ExecuteAsync
                ("spStudent_Delete", new {RollNo = rollNo}, commandType: CommandType.StoredProcedure);
            return changedRecord;
        }
    }
}
