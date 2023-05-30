using Dapper.Application.Interfaces;
using Dapper.Core.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        var students = "SELECT * FROM StudentRecords";
        using (var connection = new SqlConnection(_configuration.GetConnectionString("Default")))
        {
            connection.Open();
            var records = await connection.QueryAsync<Student>(students);
            return records.ToList();
        }

    }
    public async Task<Student> GetByIdAsync(int rollNo)
    {
        var student = "SELECT * FROM StudentRecords WHERE RollNo = @RollNo";
        using (var connection = new SqlConnection(_configuration.GetConnectionString("Default")))
        {
            connection.Open();
            var record = await connection.QuerySingleOrDefaultAsync<Student>
                (student, new { RollNo = rollNo });
            return record;
        }
    }
    public async Task<int> AddAsync(Student student)
    {
        var newStudent = "INSERT INTO StudentRecords (Name, FamilyName, Address, Contact) VALUES (@Name, @FamilyName, @Address, @Contact)";
        using (var connection = new SqlConnection(_configuration.GetConnectionString("Default")))
        {
            connection.Open();
            var newRecord = await connection.ExecuteAsync(newStudent, student);
            return newRecord;
        }
    }
    public async Task<int> UpdateAsync(Student student)
    {
        var updateStudent =
            "UPDATE StudentRecords SET Name = @Name, FamilyName = @FamilyName, Address = @Address, Contact = @Contact WHERE RollNo = @RollNo";
        using (var connection = new SqlConnection(_configuration.GetConnectionString("Default")))
        {
            connection.Open();
            var updatedRecord = await connection.ExecuteAsync(updateStudent, student);
            return updatedRecord;
        }
    }
    public async Task<int> DeleteAsync(int rollNo)
    {
        var removingStudent = "DELETE FROM StudentRecords WHERE RollNo = @RollNo";
        using(var connection = new SqlConnection(_configuration.GetConnectionString("Default")))
        {
            connection.Open();
            var changedRecord = await connection.ExecuteAsync(removingStudent, new {RollNo = rollNo});
            return changedRecord;
        }

    }

}
