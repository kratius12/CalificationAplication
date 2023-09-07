using api.Datos;
using api.Models;
using api.Models.ViewModels;
using api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace api.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        ChartDatos _ChartDatos = new ChartDatos();
        public IActionResult mejoresPer()
        {
            var lista = _ChartDatos.Listar();


            return StatusCode(StatusCodes.Status200OK,lista);
        }
    }
}