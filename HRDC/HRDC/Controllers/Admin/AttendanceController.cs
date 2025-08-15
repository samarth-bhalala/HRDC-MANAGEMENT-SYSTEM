using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HRDC.Controllers.Admin
{
    public class AttendanceController : Controller
    {

        private List<(int EmployeeId, string Name, string Email, int DepartmentId, int DesignationId, int EmployeeTypeId)> employees = new()
    {
        (101, "Alice Johnson", "alice@example.com", 1, 2, 1),
        (102, "Bob Smith", "bob@example.com", 2, 1, 2),
    };
        private List<(int Id, string Title, DateTime StartDate, DateTime EndDate)> trainingSessions = new()
    {
        (1, "Leadership Training", new DateTime(2025, 9, 1), new DateTime(2025, 9, 3)),
        (2, "Advanced C# Workshop", new DateTime(2025, 9, 4), new DateTime(2025, 9, 6)),
    };

        [HttpGet]
        public IActionResult AttendanceManagement()
        {
            var model = new AttendanceViewModel
            {
                TrainingSessions = trainingSessions.Select(ts =>
                    new SelectListItem(ts.Title, ts.Id.ToString())).ToList()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult AttendanceManagement(AttendanceViewModel model, string action)
        {
            // Load employees when "Load Employees" button is clicked
            if (action == "load")
            {
                // Filter employees based on search term if any
                var filteredEmployees = string.IsNullOrWhiteSpace(model.SearchTerm)
                    ? employees
                    : employees.Where(e => e.Name.Contains(model.SearchTerm, StringComparison.OrdinalIgnoreCase)).ToList();

                model.Employees = filteredEmployees.Select(e => new AttendanceViewModel.EmployeeAttendance
                {
                    EmployeeId = e.EmployeeId,
                    Name = e.Name,
                    IsPresent = false
                }).ToList();

                model.TrainingSessions = trainingSessions.Select(ts =>
                    new SelectListItem(ts.Title, ts.Id.ToString(), ts.Id == model.SelectedTrainingSessionId)).ToList();
            }
            else if (action == "save")
            {
                // Save attendance data (model.Employees)
                // TODO: Implement actual save logic

                ViewBag.Message = "Attendance saved successfully!";
                model.TrainingSessions = trainingSessions.Select(ts =>
                    new SelectListItem(ts.Title, ts.Id.ToString(), ts.Id == model.SelectedTrainingSessionId)).ToList();
            }
            else if (action == "search")
            {
                // On search, reload employees filtered by search term
                var filteredEmployees = employees.Where(e => e.Name.Contains(model.SearchTerm ?? "", StringComparison.OrdinalIgnoreCase)).ToList();
                model.Employees = filteredEmployees.Select(e => new AttendanceViewModel.EmployeeAttendance
                {
                    EmployeeId = e.EmployeeId,
                    Name = e.Name,
                    IsPresent = false
                }).ToList();

                model.TrainingSessions = trainingSessions.Select(ts =>
                    new SelectListItem(ts.Title, ts.Id.ToString(), ts.Id == model.SelectedTrainingSessionId)).ToList();
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult ExportAttendanceToExcel()
        {
            // Implement export to Excel logic here
            // For example, generate Excel file and return FileResult

            return Content("Export functionality not implemented yet.");
        }


        // Dummy data, replace with your DB fetching logic
        private List<(int Id, string Name)> departments = new()
    {
        (1, "HR"),
        (2, "Finance"),
        (3, "Technical")
    };

        private List<(int Id, string Name)> designations = new()
    {
        (1, "Manager"),
        (2, "Senior Developer"),
        (3, "Junior Developer")
    };

        private List<(int Id, string Name)> employeeTypes = new()
    {
        (1, "Technical Staff"),
        (2, "Non-Technical Staff")
    };

    }
}
