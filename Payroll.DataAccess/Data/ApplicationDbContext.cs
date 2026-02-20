using Microsoft.EntityFrameworkCore;
using Payroll.Models;

namespace Payroll.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
            
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Attendance> Attendances { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee { EmployeeId = 1, Name = "Aman", EmployeeCode = 101, Department = "IT", Designation = "Junior-Engeener", CreatedAt = new DateTime(), Salary = 20000 },
                new Employee { EmployeeId = 2, Name = "Sourav", EmployeeCode = 102, Department = "Account", Designation = "Senior-Engeener", CreatedAt = new DateTime(), Salary = 20000 },
                new Employee { EmployeeId = 3, Name = "Jagan", EmployeeCode = 103, Department = "IT", Designation = "Junior-Engeener", CreatedAt = new DateTime(), Salary = 20000 }
                );

            modelBuilder.Entity<Attendance>().HasData(
                new Attendance { AttendanceId = 1, Present = false, AttendanceDate = new DateOnly(), EmployeeId = 1 },
                new Attendance { AttendanceId = 2, Present = true, AttendanceDate = new DateOnly(), EmployeeId = 3 },
                new Attendance { AttendanceId = 3, Present = false, AttendanceDate = new DateOnly(), EmployeeId = 2 }
                    );
        }
    }
}
