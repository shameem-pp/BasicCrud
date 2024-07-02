using BasicCrud.Controllers.Base;
using BasicCrud.Data;
using BasicCrud.Entities;
using BasicCrud.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BasicCrud.Controllers;

public class StudentsController(IStudentRepository studentRepository) : BaseController
{
    private readonly IStudentRepository _studentRepository = studentRepository;

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Student student)
    {
        await _studentRepository.CreateAsync(student);
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> Get() 
    {
        var students = await _studentRepository.GetAsync();
        return Ok(students);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var student = await _studentRepository.GetAsync(id);
        return Ok(student);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] Student student)
    {
        var id = await _studentRepository.UpdateAsync(student);
        return Ok(id);
    }

}
