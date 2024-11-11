using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class ClientesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
