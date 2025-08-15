using Microsoft.AspNetCore.Mvc;

namespace HRDC.Controllers.Participant
{
    public class DashboardController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
