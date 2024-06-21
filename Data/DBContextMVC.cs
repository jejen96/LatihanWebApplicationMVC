using LatihanWebApplicationMVC.Models.Employee;
using Microsoft.EntityFrameworkCore;

namespace LatihanWebApplicationMVC.Data
{
    public class DBContextMVC : DbContext
    {
        public DBContextMVC(DbContextOptions<DBContextMVC> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
