//using HRDC.Models;
//using Microsoft.AspNetCore.Mvc;
//namespace HRDC.Controllers.Admin
//{
//    public class ApprovalController : Controller
//    {
//        public IActionResult TrainingApproval()
//        {
//            var trainings = new List<Training>
//            {
//                new Training { Id = 1, Title = "AI Workshop (Aug 10–12)" },
//                new Training { Id = 2, Title = "Data Science Bootcamp (Sep 5–9)" }
//            };

//            var participants = new List<Participant>
//            {
//                new Participant { Name = "Riya Mehta", Email = "riya.mehta@example.com", Department = "Computer", Status = "Pending" },
//                new Participant { Name = "Kunal Patel", Email = "kunal.patel@example.com", Department = "IT", Status = "Approved" }
//            };

//            ViewBag.Trainings = trainings;
//            return View(participants);
//        }

//        [HttpPost]
//        public IActionResult ApproveAll()
//        {
//            TempData["Message"] = "All pending requests approved!";
//            return RedirectToAction("TrainingApproval");
//        }

//        [HttpPost]
//        public IActionResult ApproveParticipant(string email)
//        {
//            TempData["Message"] = $"Approved participant: {email}";
//            return RedirectToAction("TrainingApproval");
//        }


//    }
//}
