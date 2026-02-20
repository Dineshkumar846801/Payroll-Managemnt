using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Payroll.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required]
        [DisplayName("Employee Name")]
        [MinLength(3)]
        public string Name { get; set; }
        [DisplayName("Employee Code")]
        [Range(101,10000,ErrorMessage ="Employee Code must be between 101 - 9999")]
        public int EmployeeCode { get; set; }
        public string Designation { get; set; }
        public string Department { get; set; }

        public DateTime CreatedAt { get; set; }
        public int Salary { get; set; }
    }
}
