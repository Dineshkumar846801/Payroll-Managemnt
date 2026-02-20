using Payroll.DataAccess.Data;
using Payroll.DataAccess.Repository.IRepository;
using Payroll.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Payroll.DataAccess.Repository
{
    public class EmployeeRepository :  Repository<Employee> , IEmployeeRepository
    {
        private ApplicationDbContext _db;

        public EmployeeRepository(ApplicationDbContext db) : base(db) {
            _db = db;
        }
        

        

        public void Update(Employee obj)
        {
            _db.Employees.Update(obj);
        }
    }
}
