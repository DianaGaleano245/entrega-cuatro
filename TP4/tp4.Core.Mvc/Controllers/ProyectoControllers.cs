using Microsoft.AspNetCore.Mvc;
using System.Data;
using TP4;

namespace tp4.Core.Mvc.Controllers;
public class ProyectoController : Controller
{
    IAdo _ado;
    public ProyectoController(IAdo ado)
    {
        _ado = ado;
    }
    public IActionResult Index() => View();

    public IActionResult ProyectoForm() => View();

    public IActionResult ProyectoForm(Proyecto proyecto)
    {
        //_ado.AltaProyecto(proyecto);
        return Redirect(nameof(Index));
    }
    [HttpGet]

    public ViewResult ListaProyecto() => View();
}