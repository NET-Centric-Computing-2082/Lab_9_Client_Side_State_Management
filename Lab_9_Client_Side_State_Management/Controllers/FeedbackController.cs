using Microsoft.AspNetCore.Mvc;

namespace Lab_9_FeedbackApp.Controllers
{
    public class FeedbackController : Controller
    {
        // GET: Feedback Form
        public IActionResult Index(string userId)
        {
            // Retrieve theme from cookies (default = light)
            var theme = Request.Cookies["Theme"] ?? "light";

            // Generate a feedback ID (could be GUID or random number)
            var feedbackId = Guid.NewGuid().ToString();

            ViewBag.Theme = theme;
            ViewBag.UserId = userId;
            ViewBag.FeedbackId = feedbackId;

            return View();
        }

        // POST: Handle feedback submission
        [HttpPost]
        public IActionResult Submit(string userId, string feedbackId, string theme)
        {
            // Save theme preference in cookie
            Response.Cookies.Append("Theme", theme, new CookieOptions
            {
                Expires = DateTimeOffset.UtcNow.AddDays(7) // Cookie lasts 7 days
            });

            // Pass values to result page
            ViewBag.UserId = userId;
            ViewBag.FeedbackId = feedbackId;
            ViewBag.Theme = theme;

            return View("Result");
        }
    }
}
