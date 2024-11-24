using Microsoft.AspNetCore.Mvc;

namespace WebApi2.Controllers
{
    public class ClienteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
