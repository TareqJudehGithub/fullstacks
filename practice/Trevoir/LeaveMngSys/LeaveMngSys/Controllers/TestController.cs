using LeaveMngSys.Models;
using Microsoft.AspNetCore.Mvc;

namespace LeaveMngSys.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            var model = new TestViewModel
            {
                Name = "John Smith",
                Age = 50,
                Birthday = new DateTime(1975, 06, 27)
            };
            return View(model);
        }
    }
}
