using HRDC.Models;
using Microsoft.AspNetCore.Mvc;

namespace HRDC.Controllers.Participant
{
    public class UpcomingSessionsController : Controller
    {
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

    }
}
