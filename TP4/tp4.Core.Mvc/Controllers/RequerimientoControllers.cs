using Microsoft.AspNetCore.Mvc;
using System.Data;
using TP4;
using TP4.Core;
namespace tp4.Core.Mvc.Controllers;

public class RequerimientoController : Controller
{
    IAdo _ado;
    public RequerimientoController(IAdo ado)
    {
        _ado = ado;
    }
    [HttpGet]
    public IActionResult Index() => View("ListaRequerimiento", _ado.ObtenerRequerimiento());


    [HttpGet]
    public IActionResult AltaRequerimiento()
    {
        return View();
    }

    [HttpPost]
    public IActionResult AltaRequerimiento(Requerimiento Requerimiento)
    {
        _ado.AltaRequerimiento(Requerimiento);
        return Redirect(nameof(Index));
    }
}
