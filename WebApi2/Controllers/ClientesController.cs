using Microsoft.AspNetCore.Mvc;

namespace WebApi2.Controllers
{
    public class ClientesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
