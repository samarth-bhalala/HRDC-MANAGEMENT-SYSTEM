using HRDC.Models;
using Microsoft.AspNetCore.Mvc;

namespace HRDC.Controllers.Participant
{
    public class MySessionsController : Controller
    {
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
    }
}
