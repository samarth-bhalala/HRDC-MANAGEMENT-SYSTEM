using HRDC.Models;
using Microsoft.AspNetCore.Mvc;

namespace HRDC.Controllers.Participant
{
    public class TrainingDetailsController : Controller
    {
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
    }
}
