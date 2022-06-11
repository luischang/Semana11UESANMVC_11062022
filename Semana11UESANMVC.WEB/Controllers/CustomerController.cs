using Microsoft.AspNetCore.Mvc;
using Semana11UESANMVC.WEB.Models;
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

        [HttpPost]
        public async Task<IActionResult> Create(int idCliente, string nombre,
                string apellido, string ciudad, string telefono, string pais) 
        {
            var customer = new CustomerModel()
            {
                FirstName = nombre,
                LastName = apellido,
                City = ciudad,
                Country = pais,
                Phone = telefono
            };

            bool exito = true;
            if (idCliente == -1)
                exito = await CustomerService.Create(customer) > 0 ? true: false;
            else {
                customer.Id = idCliente;
                exito = await CustomerService.Update(customer) > 0 ? true : false;
            }
            return Json(exito);        
        }        
    }
}
