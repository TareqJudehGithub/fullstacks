using LeaveManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace LeaveManagementSystem.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            int year = new DateTime().Year;
            var model = new TestViewModel
            {
                name = "John Smith",
                age = 50,
                DateOfBirth = new DateTime(1975, 06, 27)
            };
            return View(model);
        }
    }
}
