using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace YourProject.Controllers
{
    public class AccountController : Controller
    {
        // GET: /Account/Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            // Replace this with your DB check
            if (username == "admin" && password == "admin123")
            {
                HttpContext.Session.SetString("Username", username);
                HttpContext.Session.SetString("Role", "Admin");
                return RedirectToAction("Dashboard", "Admin");
            }
            else if (username == "user" && password == "123")
            {
                HttpContext.Session.SetString("Username", username);
                HttpContext.Session.SetString("Role", "Participant");
                return RedirectToAction("Dashboard", "Participant");
            }

            ViewBag.Error = "Invalid username or password.";
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }


    }
}
