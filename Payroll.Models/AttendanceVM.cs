using System;
using System.Collections.Generic;
using System.Text;

namespace Payroll.Models
{
    public class AttendanceVM 
    {
        public List<Employee>? Employees { get; set; }
        public List<Attendance>? Attendances { get; set; }
    }
}
