using Dapper.Application.Interfaces;
using Dapper.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DapperStudnets.Controllers;
[Route("api/[controller]")]
[ApiController]
public class StudentController : ControllerBase
{
    private readonly IStudentRepository _studentRepository;

    public StudentController(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _studentRepository.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetStudentByRollNo(int rollNo)
    {
        var result = await _studentRepository.GetByIdAsync(rollNo);
        if (result == null) { return Ok(); }
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> AddNewStudent(Student student)
    {
        var result = await _studentRepository.AddAsync(student);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateStudent(Student student)
    {
        var result = await _studentRepository.UpdateAsync(student);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> RemoveStudent(int rollNo)
    {
        var result = await _studentRepository.DeleteAsync(rollNo);
        return Ok(result);
    }
}
