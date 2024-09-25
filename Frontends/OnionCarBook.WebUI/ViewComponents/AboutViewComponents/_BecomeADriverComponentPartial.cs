using Microsoft.AspNetCore.Mvc;

namespace OnionCarBook.WebUI.ViewComponents.AboutViewComponents
{
    public class _BecomeADriverComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
