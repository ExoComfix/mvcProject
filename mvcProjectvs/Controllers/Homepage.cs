using Microsoft.AspNetCore.Mvc;

namespace mvcProjectvs.Controllers
{
    public class Homepage : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
