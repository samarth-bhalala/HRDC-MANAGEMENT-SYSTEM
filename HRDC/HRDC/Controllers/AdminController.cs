using HRDC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

public class AdminController : Controller
{
    public IActionResult Dashboard()
    {
        // Replace these with real data fetch logic from DB
        var model = new AdminDashboardViewModel
        {
            SeminarCount = 6,
            TechnicalStaffCount = 20,
            NonTechnicalStaffCount = 10,
            TotalStaffCount = 30,
            SelectedAttendanceFilter = "all",
            SelectedFeedbackFilter = "all"
        };

        return View(model);
    }

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

  
    [HttpGet]
    public IActionResult EditEmployee(int id)
    {
        var emp = employees.FirstOrDefault(e => e.EmployeeId == id);
        if (emp == default)
            return NotFound();

        var model = new EmployeeEditViewModel
        {
            EmployeeId = emp.EmployeeId,
            Name = emp.Name,
            Email = emp.Email,
            DepartmentId = emp.DepartmentId,
            DesignationId = emp.DesignationId,
            EmployeeTypeId = emp.EmployeeTypeId,
            Departments = departments.Select(d => new SelectListItem(d.Name, d.Id.ToString())).ToList(),
            Designations = designations.Select(d => new SelectListItem(d.Name, d.Id.ToString())).ToList(),
            EmployeeTypes = employeeTypes.Select(e => new SelectListItem(e.Name, e.Id.ToString())).ToList()
        };

        return View(model);
    }

    [HttpPost]
    public IActionResult EditEmployee(EmployeeEditViewModel model)
    {
        if (!ModelState.IsValid)
        {
            // Reload dropdowns if model invalid
            model.Departments = departments.Select(d => new SelectListItem(d.Name, d.Id.ToString())).ToList();
            model.Designations = designations.Select(d => new SelectListItem(d.Name, d.Id.ToString())).ToList();
            model.EmployeeTypes = employeeTypes.Select(e => new SelectListItem(e.Name, e.Id.ToString())).ToList();

            return View(model);
        }

        // TODO: Save update to database here.
        // For example: update employee record with model values.

        TempData["Message"] = "Employee updated successfully!";
        return RedirectToAction("ViewEmployee"); // Redirect back to list
    }




    private static List<TrainingSession> Trainings = new List<TrainingSession>()
    {
        new TrainingSession
        {
            Id = 1,
            Title = "AI Workshop",
            TrainerName = "Dr. Sharma",
            DateFrom = new DateTime(2025, 8, 10),
            DateTo = new DateTime(2025, 8, 12),
            TimeFrom = new TimeSpan(10,0,0),
            TimeTo = new TimeSpan(16,0,0),
            Venue = "Auditorium",
            Description = "Intro to AI",
            Status = "Published"
        }
    };

    [HttpGet]
    public IActionResult TrainingManagement()
    {
        return View(Trainings);
    }

    [HttpPost]
    public IActionResult AddTraining(TrainingSession model)
    {
        if (ModelState.IsValid)
        {
            model.Id = Trainings.Any() ? Trainings.Max(t => t.Id) + 1 : 1;
            Trainings.Add(model);
            TempData["Message"] = "Training added successfully!";
        }
        else
        {
            TempData["Message"] = "Invalid data!";
        }
        return RedirectToAction(nameof(TrainingManagement));
    }

    [HttpPost]
    public IActionResult EditTraining(TrainingSession model)
    {
        var training = Trainings.FirstOrDefault(t => t.Id == model.Id);
        if (training != null && ModelState.IsValid)
        {
            training.Title = model.Title;
            training.TrainerName = model.TrainerName;
            training.DateFrom = model.DateFrom;
            training.DateTo = model.DateTo;
            training.TimeFrom = model.TimeFrom;
            training.TimeTo = model.TimeTo;
            training.Venue = model.Venue;
            training.Description = model.Description;
            training.Status = model.Status;

            TempData["Message"] = "Training updated successfully!";
        }
        else
        {
            TempData["Message"] = "Training not found or invalid data!";
        }
        return RedirectToAction(nameof(TrainingManagement));
    }

    [HttpPost]
    public IActionResult DeleteTraining(int id)
    {
        var training = Trainings.FirstOrDefault(t => t.Id == id);
        if (training != null)
        {
            Trainings.Remove(training);
            TempData["Message"] = "Training deleted successfully!";
        }
        else
        {
            TempData["Message"] = "Training not found!";
        }
        return RedirectToAction(nameof(TrainingManagement));
    }



    public IActionResult TrainingApproval()
    {
        var trainings = new List<Training>
            {
                new Training { Id = 1, Title = "AI Workshop (Aug 10–12)" },
                new Training { Id = 2, Title = "Data Science Bootcamp (Sep 5–9)" }
            };

        var participants = new List<Participant>
            {
                new Participant { Name = "Riya Mehta", Email = "riya.mehta@example.com", Department = "Computer", Status = "Pending" },
                new Participant { Name = "Kunal Patel", Email = "kunal.patel@example.com", Department = "IT", Status = "Approved" }
            };

        ViewBag.Trainings = trainings;
        return View(participants);
    }

    [HttpPost]
    public IActionResult ApproveAll()
    {
        TempData["Message"] = "All pending requests approved!";
        return RedirectToAction("TrainingApproval");
    }

    [HttpPost]
    public IActionResult ApproveParticipant(string email)
    {
        TempData["Message"] = $"Approved participant: {email}";
        return RedirectToAction("TrainingApproval");
    }




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