using Microsoft.AspNetCore.Mvc;
using MvcCoreApiEmpleadosRoutes.Services;
using NugetApiModels.Models;
using System.Threading.Tasks;

namespace MvcCoreApiEmpleadosRoutes.Controllers
{
    public class EmpleadosController : Controller
    {
        private ServiceEmpleados service;

        public EmpleadosController(ServiceEmpleados service)
        {
            this.service = service;
        }

        public async Task<IActionResult> Index(string? oficio)
        {
            List<string> oficios = await this.service.GetOficiosAsync();
            List<Empleado> empleados = await this.service.GetEmpleadosAsync();
            ViewData["OFICIOS"] = oficios;
            if(oficio != null)
            {
                List<Empleado> empleadosOficio = await this.service.GetEmpleadosOficiosAsync(oficio);
                return View(empleadosOficio);
            }
            return View(empleados);
        }
    }
}
