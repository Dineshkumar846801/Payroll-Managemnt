using Payroll.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payroll.DataAccess.Repository.IRepository
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        void Update(Employee obj);
    }
}
