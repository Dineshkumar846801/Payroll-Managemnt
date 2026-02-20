using Payroll.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payroll.DataAccess.Repository.IRepository
{
    public interface IAttendanceRepository : IRepository<Attendance>
    {
        void Update(Attendance obj);
    }
}
