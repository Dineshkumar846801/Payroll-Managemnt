using System;
using System.Collections.Generic;
using System.Text;

namespace Payroll.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IEmployeeRepository Employee{ get; }

        IAttendanceRepository Attendance{ get; }

        void Save();
    }
}
