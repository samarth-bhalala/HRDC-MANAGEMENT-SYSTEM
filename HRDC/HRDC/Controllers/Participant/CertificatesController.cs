using HRDC.Models;
using Microsoft.AspNetCore.Mvc;

namespace HRDC.Controllers.Participant
{
    public class CertificatesController : Controller
    {
        public IActionResult ViewCertificate()
        {
            // Simulated logged-in user
            string employeeId = "E001"; // Replace with real user ID from authentication

            var certificates = new List<CertificateViewModel>
            {
                new CertificateViewModel
                {
                    TrainingName = "AI Basics",
                    Date = new System.DateTime(2025, 6, 15),
                    CertificatePath = $"certificates/{employeeId}_AI_Basics.jpg"
                },
                new CertificateViewModel
                {
                    TrainingName = "Cloud Computing",
                    Date = new System.DateTime(2025, 6, 20),
                    CertificatePath = $"certificates/{employeeId}_Cloud_Computing.jpg"
                }
            };

            return View(certificates);
        }

        public IActionResult DownloadCertificate(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                TempData["Error"] = "Invalid certificate file path.";
                return RedirectToAction("ViewCertificate");
            }

            var fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", filePath.Replace('/', Path.DirectorySeparatorChar));

            if (!System.IO.File.Exists(fullPath))
            {
                TempData["Error"] = "❌ Certificate file not found.";
                return RedirectToAction("ViewCertificate");
            }

            var contentType = "application/octet-stream";
            var fileName = Path.GetFileName(fullPath);

            return PhysicalFile(fullPath, contentType, fileName);
        }

    }
}
