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
        public IActionResult Index(DateTime? date = null)
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

     

            var model = objEmployeeList.Select(e => new AttendanceVM
            {
                EmployeeId = e.EmployeeId,
                Name = e.Name,
                Status = "Absent"
            }).ToList();

            return View(model);
        }


        [HttpPost]
        public IActionResult Create(List<AttendanceVM> model)
        {
            DateTime today = DateTime.Today;

            foreach (var item in model)
            {
                _unitOfWork.Attendance.Add(new Attendance
                {
                    EmployeeId = item.EmployeeId,
                    AttendanceDate = today,
                    Status = item.Status
                });
            }

            _unitOfWork.Save();
            return RedirectToAction("Index");
        }
    }
}
