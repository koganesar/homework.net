using hm7.Models;
using Microsoft.AspNetCore.Mvc;

namespace hm7.Controllers
{
    [Route("UserProfile")]
        public class UserProfileController: Controller
        {
            [HttpGet]
            public IActionResult UserProfile() =>
                View();

            [HttpPost]
            public IActionResult UserProfile(UserProfile userProfile) =>
                View(userProfile);
        }
}