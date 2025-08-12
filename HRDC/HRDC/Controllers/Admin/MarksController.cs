using HRDC.Models;
using Microsoft.AspNetCore.Mvc;

namespace HRDC.Controllers.Admin
{
    public class MarksController : Controller
    {

        private readonly List<string> _trainings = new List<string>
        {
            "AI Bootcamp",
            "Cloud Fundamentals"
        };

        private readonly List<EmployeeMarks> _mockEmployees = new List<EmployeeMarks>
        {
            new EmployeeMarks { EmployeeId = "EMP001", Name = "Riya Mehta" },
            new EmployeeMarks { EmployeeId = "EMP002", Name = "Kunal Patel" },
            new EmployeeMarks { EmployeeId = "EMP003", Name = "Ayesha Shah" }
        };

        [HttpGet]
        public IActionResult MarksEntry()
        {
            var model = new MarksEntryViewModel
            {
                Trainings = _trainings
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult LoadEmployees(MarksEntryViewModel model)
        {
            if (string.IsNullOrEmpty(model.SelectedTraining))
            {
                model.Message = "⚠️ Please select a training session.";
            }
            else if (!model.OutOfMarks.HasValue)
            {
                model.Message = "⚠️ Please enter the 'Out Of' marks.";
            }
            else
            {
                model.Employees = _mockEmployees;
            }

            model.Trainings = _trainings;
            return View("MarksEntry", model);
        }

        [HttpPost]
        public IActionResult SaveMarks(MarksEntryViewModel model)
        {
            if (model.Employees == null || !model.Employees.Any())
            {
                model.Message = "⚠️ No data loaded to submit.";
            }
            else
            {
                foreach (var emp in model.Employees)
                {
                    System.Diagnostics.Debug.WriteLine($"Employee: {emp.EmployeeId} - {emp.Name}, Marks: {emp.Marks}");
                }
                model.Message = "✅ Marks saved successfully (in-memory only).";
            }

            model.Trainings = _trainings;
            return View("MarksEntry", model);
        }

    }
}
