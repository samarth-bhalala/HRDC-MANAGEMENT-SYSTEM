using HRDC.Models;
using Microsoft.AspNetCore.Mvc;

public class ParticipantController : Controller
{
    public IActionResult Dashboard()
    {
        return View();
    }
    public IActionResult MySessions()
    {
        // Dummy data (replace with DB call later)
        var sessions = new List<SessionViewModel>
            {
                new SessionViewModel
                {
                    TrainingName = "Leadership Skills",
                    FromDate = DateTime.Now.AddDays(-10),
                    ToDate = DateTime.Now.AddDays(-8),
                    Trainer = "John Doe",
                    Status = "Completed",
                    Venue = "Main Hall"
                },
                new SessionViewModel
                {
                    TrainingName = "Advanced .NET",
                    FromDate = DateTime.Now.AddDays(2),
                    ToDate = DateTime.Now.AddDays(4),
                    Trainer = "Jane Smith",
                    Status = "Upcoming",
                    Venue = "Room 101"
                }
            };
        return View(sessions);
    }
    public IActionResult UpcomingSessions()
    {
        // Replace this with your real data source
        var sessions = new List<SessionViewModel>
            {
                new SessionViewModel
                {
                    SessionID = 1,
                    SessionName = "Leadership Workshop",
                    AuthorName = "John Doe",
                    StartDate = DateTime.Now.AddDays(3),
                    EndDate = DateTime.Now.AddDays(5),
                    SessionType = "Online"
                },
                new SessionViewModel
                {
                    SessionID = 2,
                    SessionName = "Advanced .NET Training",
                    AuthorName = "Jane Smith",
                    StartDate = DateTime.Now.AddDays(7),
                    EndDate = DateTime.Now.AddDays(9),
                    SessionType = "Offline"
                }
            };

        return View(sessions);
    }

    [HttpPost]
    public IActionResult Apply(int sessionId)
    {
        // Handle apply logic here (e.g., save to DB)
        // For demo, just redirect back to list with a message

        TempData["Message"] = $"Applied to session ID {sessionId}";
        return RedirectToAction("UpcomingSessions");
    }

    [HttpGet]
    public IActionResult TrainingDetails()
    {
        var model = new TrainingDetailsViewModel
        {
            Title = "Data Science Bootcamp",
            Trainer = "Prof. N. Sinha",
            DateRange = "5th Sept 2025 – 9th Sept 2025",
            Time = "10:00 AM – 4:00 PM",
            Venue = "Seminar Hall B",
            Description = "This training will cover Python for Data Analysis, ML workflows, and real-world case studies."
        };
        return View(model);
    }

    [HttpPost]
    public IActionResult TrainingDetails(TrainingDetailsViewModel model, string submitButton)
    {
        if (submitButton == "Yes")
        {
            // Handle Yes logic, e.g., save expectations, registration, etc.
            TempData["Message"] = "Thank you for confirming your participation!";
        }
        else if (submitButton == "No")
        {
            // Handle No logic
            TempData["Message"] = "You have declined to participate.";
        }

        return RedirectToAction("TrainingDetails");
    }

    public IActionResult TrainingDetailsResult()
    {
        return View();
    }

    [HttpGet]
    public IActionResult TrainingFeedback()
    {
        return View(new TrainingFeedbackViewModel());
    }

    [HttpPost]
    public IActionResult TrainingFeedback(TrainingFeedbackViewModel model)
    {
        if (ModelState.IsValid)
        {
            // TODO: Save feedback to DB or process as needed

            TempData["Message"] = "Thank you for your feedback!";
            return RedirectToAction("TrainingFeedback");
        }
        // If validation fails, return view with errors
        return View(model);
    }

    public IActionResult TrainingFeedbackResult()
    {
        return View();
    }


    public IActionResult ViewCertificate()
    {
        // Simulated logged-in user
        string employeeId = "E001"; // Replace with real user ID from authentication

        var certificates = new List<CertificateViewModel>
            {
                new CertificateViewModel
                {
                    TrainingName = "AI Basics",
                    Date = new System.DateTime(2025, 6, 15),
                    CertificatePath = $"certificates/{employeeId}_AI_Basics.jpg"
                },
                new CertificateViewModel
                {
                    TrainingName = "Cloud Computing",
                    Date = new System.DateTime(2025, 6, 20),
                    CertificatePath = $"certificates/{employeeId}_Cloud_Computing.jpg"
                }
            };

        return View(certificates);
    }

    public IActionResult DownloadCertificate(string filePath)
    {
        if (string.IsNullOrEmpty(filePath))
        {
            TempData["Error"] = "Invalid certificate file path.";
            return RedirectToAction("ViewCertificate");
        }

        var fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", filePath.Replace('/', Path.DirectorySeparatorChar));

        if (!System.IO.File.Exists(fullPath))
        {
            TempData["Error"] = "❌ Certificate file not found.";
            return RedirectToAction("ViewCertificate");
        }

        var contentType = "application/octet-stream";
        var fileName = Path.GetFileName(fullPath);

        return PhysicalFile(fullPath, contentType, fileName);
    }


    [HttpGet]
    public IActionResult Profile()
    {
        // You can load profile data from DB here, for example:
        var model = new ProfileViewModel
        {
            Email = "demo@gmail.com",  // Email is readonly
                                       // populate other fields if available
        };
        return View(model);
    }

    // Handle profile update post
    [HttpPost]
    public IActionResult Profile(ProfileViewModel model)
    {
        if (ModelState.IsValid)
        {
            // Save profile changes to DB here

            ViewBag.Message = "Profile updated successfully!";
            return View(model);
        }
        return View(model);
    }
}