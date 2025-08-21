//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;

//namespace HRDC.Controllers.Admin
//{
//    public class EmployeeController : Controller
//    {
//        [HttpGet]
//        public IActionResult ViewEmployee(string type = "")
//        {
//            var employees = this.employees.Select(e => new EmployeeViewModel
//            {
//                EmployeeId = e.EmployeeId,
//                Name = e.Name,
//                Email = e.Email,
//                Department = departments.FirstOrDefault(d => d.Id == e.DepartmentId)?.Name,
//                Designation = designations.FirstOrDefault(d => d.Id == e.DesignationId)?.Name,
//                EmployeeType = employeeTypes.FirstOrDefault(et => et.Id == e.EmployeeTypeId)?.Name
//            }).ToList();

//            if (!string.IsNullOrEmpty(type) && type != "All")
//            {
//                employees = employees.Where(e => e.EmployeeType == type).ToList();
//            }

//            var model = new EmployeeViewModel
//            {
//                Employees = employees,
//                SelectedType = type,
//                EmployeeTypes = new List<SelectListItem>
//        {
//            new SelectListItem("-- Select Type --", "All"),
//            new SelectListItem("Technical", "Technical"),
//            new SelectListItem("Non-Technical", "Non-Technical")
//        }
//            };

//            return View(model);
//        }

//        //[HttpGet]
//        //public IActionResult EditEmployee(int id)
//        //{
//        //    var emp = employees.FirstOrDefault(e => e.EmployeeId == id);
//        //    if (emp == default)
//        //        return NotFound();

//        //    var model = new EmployeeEditViewModel
//        //    {
//        //        EmployeeId = emp.EmployeeId,
//        //        Name = emp.Name,
//        //        Email = emp.Email,
//        //        DepartmentId = emp.DepartmentId,
//        //        DesignationId = emp.DesignationId,
//        //        EmployeeTypeId = emp.EmployeeTypeId,
//        //        Departments = departments.Select(d => new SelectListItem(d.Name, d.Id.ToString())).ToList(),
//        //        Designations = designations.Select(d => new SelectListItem(d.Name, d.Id.ToString())).ToList(),
//        //        EmployeeTypes = employeeTypes.Select(e => new SelectListItem(e.Name, e.Id.ToString())).ToList()
//        //    };

//        //    return View(model);
//        //}

//        //[HttpPost]
//        //public IActionResult EditEmployee(EmployeeEditViewModel model)
//        //{
//        //    if (!ModelState.IsValid)
//        //    {
//        //        // Reload dropdowns if model invalid
//        //        model.Departments = departments.Select(d => new SelectListItem(d.Name, d.Id.ToString())).ToList();
//        //        model.Designations = designations.Select(d => new SelectListItem(d.Name, d.Id.ToString())).ToList();
//        //        model.EmployeeTypes = employeeTypes.Select(e => new SelectListItem(e.Name, e.Id.ToString())).ToList();

//        //        return View(model);
//        //    }

//        //    // TODO: Save update to database here.
//        //    // For example: update employee record with model values.

//        //    TempData["Message"] = "Employee updated successfully!";
//        //    return RedirectToAction("ViewEmployee"); // Redirect back to list
//        //}
//    }
//}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace HRDC.Controllers.Admin
{
    public class EmployeeController : Controller
    {
        private readonly List<dynamic> employees = new()
        {
            new { EmployeeId = 1, Name = "John Doe", Email = "john@example.com", DepartmentId = 1, DesignationId = 1, EmployeeTypeId = 1 },
            new { EmployeeId = 2, Name = "Jane Smith", Email = "jane@example.com", DepartmentId = 2, DesignationId = 2, EmployeeTypeId = 2 }
        };

        private readonly List<dynamic> departments = new()
        {
            new { Id = 1, Name = "HR" },
            new { Id = 2, Name = "IT" }
        };

        private readonly List<dynamic> designations = new()
        {
            new { Id = 1, Name = "Manager" },
            new { Id = 2, Name = "Developer" }
        };

        private readonly List<dynamic> employeeTypes = new()
        {
            new { Id = 1, Name = "Technical" },
            new { Id = 2, Name = "Non-Technical" }
        };

        [HttpGet]
        public IActionResult ViewEmployee(string type = "")
        {
            // Map employees from your data source into EmployeeViewModel
            var employees = this.employees.Select(e => new EmployeeViewModel
            {
                EmployeeId = e.EmployeeId,
                Name = e.Name,
                Email = e.Email,
                Department = departments.FirstOrDefault(d => d.Id == e.DepartmentId)?.Name,
                Designation = designations.FirstOrDefault(d => d.Id == e.DesignationId)?.Name,
                EmployeeType = employeeTypes.FirstOrDefault(et => et.Id == e.EmployeeTypeId)?.Name
            }).ToList();

            // Apply filter
            if (!string.IsNullOrEmpty(type) && type != "All")
            {
                employees = employees.Where(e => e.EmployeeType == type).ToList();
            }

            // Prepare final model for the View
            var model = new EmployeeListViewModel
            {
                Employees = employees,
                SelectedType = type,
                EmployeeTypes = new List<SelectListItem>
                {
                    new SelectListItem { Text = "-- Select Type --", Value = "All" },
                    new SelectListItem { Text = "Technical", Value = "Technical" },
                    new SelectListItem { Text = "Non-Technical", Value = "Non-Technical" }
                }
            };

            return View("~/ Views / Admin / Employee / ViewEmployee.cshtml",model);
        }
    }
}

