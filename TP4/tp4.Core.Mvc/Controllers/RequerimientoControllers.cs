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
    public IActionResult Index() => View();

    public IActionResult RequerimientoForm() => View();

    public IActionResult RequerimientoForm(Requerimiento requerimiento)
    {
        _ado.AltaRequerimiento(requerimiento);
        return Redirect(nameof(Index));
    }
    public ViewResult ListaRequerimiento() => View(Requerimiento.AltaRequerimiento);
}
