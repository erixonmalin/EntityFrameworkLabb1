using EntityFrameworkLabb1.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkLabb1.Data
{
    public class VacationDbContext : DbContext
    {
        public VacationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Vacation> Vacations { get; set; }
        public DbSet<VacationList> VacationLists { get; set; }
    }
}
