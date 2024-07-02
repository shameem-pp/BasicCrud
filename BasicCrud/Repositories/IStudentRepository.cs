using BasicCrud.Entities;

namespace BasicCrud.Repositories;
public interface IStudentRepository
{
    Task<int> CreateAsync(Student student);
    Task<IEnumerable<Student>> GetAsync();
    Task<Student> GetAsync(int id);
    Task<int> UpdateAsync(Student student);
}