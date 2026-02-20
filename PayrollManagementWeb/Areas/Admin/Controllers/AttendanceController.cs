using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Payroll.DataAccess.Repository.IRepository;
using Payroll.Models;

namespace PayrollManagementWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AttendanceController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        public AttendanceController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index(DateOnly? date = null)
        {

            List<Employee> objEmployeeList = _unitOfWork.Employee.GetAll().ToList();
            List<Attendance> objAttendancelist = _unitOfWork.Attendance.GetAll().ToList();
            if (date.HasValue)
            {
                TempData["selectedDate"] = date.Value;
                List<Attendance> chooseDate = objAttendancelist.FindAll((ad) => ad.AttendanceDate == date.Value).ToList();
                return View(chooseDate);

            }

            return View(objAttendancelist);
        }

        public IActionResult Create()
        {
            List<Employee> objEmployeeList = _unitOfWork.Employee.GetAll().ToList();
            List<Attendance> objAttendancelist = _unitOfWork.Attendance.GetAll().ToList();

            AttendanceVM attendance = new AttendanceVM()
            {
                Employees = objEmployeeList,
                Attendances = new List<Attendance>()
            };
            return View(attendance);
        }
        [HttpPost]
        public IActionResult Create(AttendanceVM atten)
        {
            return View();
        }
    }
}
