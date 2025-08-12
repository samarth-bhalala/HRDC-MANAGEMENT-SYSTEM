using Microsoft.AspNetCore.Mvc;

namespace HRDC.Controllers.Admin
{
    public class DashboardController : Controller
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
    }
}

