using Payroll.DataAccess.Data;
using Payroll.DataAccess.Repository.IRepository;
using Payroll.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payroll.DataAccess.Repository
{
    public class AttendanceRepository : Repository<Attendance> , IAttendanceRepository
    {
        private ApplicationDbContext _db;

        public AttendanceRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }




        public void Update(Attendance obj)
        {
            _db.Attendances.Update(obj);
        }

    }
}
