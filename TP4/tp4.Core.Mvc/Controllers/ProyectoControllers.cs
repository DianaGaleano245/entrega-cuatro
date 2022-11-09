using Microsoft.AspNetCore.Mvc;
using System.Data;
using TP4.Core;

namespace tp4.Core.Mvc.Controllers;
public class ProyectoController : Controller
{
    IAdo _ado;
    public ProyectoController(IAdo ado)
    {
        _ado = ado;
    }
    [HttpGet]
    public IActionResult Index() => View("ListaProyecto", _ado.ObtenerProyectos());


    [HttpGet]
    public IActionResult AltaProyecto()
    {
        return View();
    }

    [HttpPost]
    public IActionResult AltaProyecto(Proyecto proyecto)
    {
        _ado.AltaProyecto(proyecto);
        return Redirect(nameof(Index));
    }
}