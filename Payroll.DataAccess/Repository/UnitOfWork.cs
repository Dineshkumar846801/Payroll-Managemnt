using Payroll.DataAccess.Data;
using Payroll.DataAccess.Repository.IRepository;
using Payroll.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payroll.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public IEmployeeRepository Employee { get; private set; }
        public IAttendanceRepository Attendance { get; private set; }

        private ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Employee = new EmployeeRepository(_db);
            Attendance = new AttendanceRepository(_db);
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
