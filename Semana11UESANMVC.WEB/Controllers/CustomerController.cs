using Microsoft.AspNetCore.Mvc;
using Semana11UESANMVC.WEB.Services;

namespace Semana11UESANMVC.WEB.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Listado()
        {
            var customers = await CustomerService.GetAll();
            return View(customers);
        }

        
    }
}
