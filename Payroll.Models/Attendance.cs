using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Payroll.Models
{
    public class Attendance
    {
        [Key]
        public int AttendanceId { get; set; }

        public Boolean Present { get; set; }

        public DateOnly AttendanceDate { get; set; } = new DateOnly();

        public int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }
    }
}
