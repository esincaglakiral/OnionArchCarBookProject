using Microsoft.AspNetCore.Mvc;

namespace OnionCarBook.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
