using Microsoft.AspNetCore.Mvc;

namespace ToDoAppPatika.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("list", "Task");
            
        }
    }
}
