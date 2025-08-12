using HRDC.Models;
using Microsoft.AspNetCore.Mvc;

namespace HRDC.Controllers.Participant
{
    public class TrainingFeedbackController : Controller
    {
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

    }
}
