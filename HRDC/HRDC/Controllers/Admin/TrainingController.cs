using Microsoft.AspNetCore.Mvc;

namespace HRDC.Controllers.Admin
{
    public class TrainingController : Controller
    {
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
    }
}
