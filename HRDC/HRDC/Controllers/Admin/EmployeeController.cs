//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;

//namespace HRDC.Controllers.Admin
//{
//    public class EmployeeController : Controller
//    {
//        [HttpGet]
//        public IActionResult EditEmployee(int id)
//        {
//            var emp = employees.FirstOrDefault(e => e.EmployeeId == id);
//            if (emp == default)
//                return NotFound();

//            var model = new EmployeeEditViewModel
//            {
//                EmployeeId = emp.EmployeeId,
//                Name = emp.Name,
//                Email = emp.Email,
//                DepartmentId = emp.DepartmentId,
//                DesignationId = emp.DesignationId,
//                EmployeeTypeId = emp.EmployeeTypeId,
//                Departments = departments.Select(d => new SelectListItem(d.Name, d.Id.ToString())).ToList(),
//                Designations = designations.Select(d => new SelectListItem(d.Name, d.Id.ToString())).ToList(),
//                EmployeeTypes = employeeTypes.Select(e => new SelectListItem(e.Name, e.Id.ToString())).ToList()
//            };

//            return View(model);
//        }

//        [HttpPost]
//        public IActionResult EditEmployee(EmployeeEditViewModel model)
//        {
//            if (!ModelState.IsValid)
//            {
//                // Reload dropdowns if model invalid
//                model.Departments = departments.Select(d => new SelectListItem(d.Name, d.Id.ToString())).ToList();
//                model.Designations = designations.Select(d => new SelectListItem(d.Name, d.Id.ToString())).ToList();
//                model.EmployeeTypes = employeeTypes.Select(e => new SelectListItem(e.Name, e.Id.ToString())).ToList();

//                return View(model);
//            }

//            // TODO: Save update to database here.
//            // For example: update employee record with model values.

//            TempData["Message"] = "Employee updated successfully!";
//            return RedirectToAction("ViewEmployee"); // Redirect back to list
//        }
//    }
//}
