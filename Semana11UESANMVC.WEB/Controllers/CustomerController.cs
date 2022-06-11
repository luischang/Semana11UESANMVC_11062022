using Microsoft.AspNetCore.Mvc;
using Semana11UESANMVC.WEB.Services;

namespace Semana11UESANMVC.WEB.Controllers
{
    public class CustomerController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Listado()
        {
            var customers = await CustomerService.GetAll();
            return PartialView(customers);
        }

        
    }
}
