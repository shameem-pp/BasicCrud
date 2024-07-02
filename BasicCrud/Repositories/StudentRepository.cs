using BasicCrud.Data;
using BasicCrud.Entities;
using Microsoft.EntityFrameworkCore;

namespace BasicCrud.Repositories;

public class StudentRepository(AppDbContext context) : IStudentRepository
{
    private readonly AppDbContext _context = context;


    public async Task<int> CreateAsync(Student student)
    {
        await _context.Students.AddAsync(student);
        _context.SaveChanges();
        return student.Id;
    }

    public async Task<IEnumerable<Student>> GetAsync()
    {
        var students = await _context.Students.ToListAsync();

        return students;
    }

    public async Task<Student> GetAsync(int id)
    {
        var student = await _context.Students.SingleAsync(x => x.Id == id);
        return student;
    }

    public async Task<int> UpdateAsync(Student student)
    {
        var std = await _context.Students.FirstAsync(s => s.Id == student.Id);

        std.Name = student.Name;
        std.Address = student.Address;

        //_context.Students.Update(student);
        await _context.SaveChangesAsync();

        return std.Id;
    }
}
