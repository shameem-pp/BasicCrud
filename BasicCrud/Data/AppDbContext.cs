using BasicCrud.Entities;
using Microsoft.EntityFrameworkCore;

namespace BasicCrud.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Student> Students { get; set; }
}
