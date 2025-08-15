using HRDC.Models;
using Microsoft.AspNetCore.Mvc;

namespace HRDC.Controllers.Participant
{
    public class ProfileController : Controller
    {
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
}
