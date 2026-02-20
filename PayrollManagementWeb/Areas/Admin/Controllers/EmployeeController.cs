using Microsoft.AspNetCore.Mvc;
using Payroll.DataAccess.Data;
using Payroll.DataAccess.Repository.IRepository;
using Payroll.Models;

namespace PayrollManagementWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EmployeeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public EmployeeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Employee> objEmployeeList = _unitOfWork.Employee.GetAll().ToList();
            return View(objEmployeeList);
        }


        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee obj)
        {
            if (ModelState.IsValid)
            {

                _unitOfWork.Employee.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Employee created successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Employee? employeeFromDb = _unitOfWork.Employee.Get(e => e.EmployeeId == id);
            //Employee? employeeFromDb1 = _db.Employees.FirstOrDefault(e => e.EmployeeId == id);
            //Employee? employeeFromDb2 = _db.Employees.Where(u => u.EmployeeId == id).FirstOrDefault();
            if (employeeFromDb == null)
            {
                return NotFound();
            }
            return View(employeeFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Employee obj)
        {
            if (ModelState.IsValid)
            {

                _unitOfWork.Employee.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Employee updated successfully";
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Employee? employeeFromDb = _unitOfWork.Employee.Get(e => e.EmployeeId == id);
            //Employee? employeeFromDb1 = _db.Employees.FirstOrDefault(e => e.EmployeeId == id);
            //Employee? employeeFromDb2 = _db.Employees.Where(u => u.EmployeeId == id).FirstOrDefault();
            if (employeeFromDb == null)
            {
                return NotFound();
            }
            return View(employeeFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Employee? obj = _unitOfWork.Employee.Get(e => e.EmployeeId == id);

            if (obj == null)
            {
                return NotFound();
            }

            _unitOfWork.Employee.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Employee deleted successfully";

            return RedirectToAction("Index");
        }
    }
}
