using Microsoft.AspNetCore.Mvc;

namespace HRDC.Controllers.Participant
{
    public class FeedbackController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
