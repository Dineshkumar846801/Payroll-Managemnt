using System;
using System.Collections.Generic;
using System.Text;

namespace Payroll.Models
{
    public class AttendanceVM 
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
    }
}
