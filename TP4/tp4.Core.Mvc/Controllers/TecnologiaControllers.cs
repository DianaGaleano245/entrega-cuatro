using Microsoft.AspNetCore.Mvc;
using TP4.Core;
namespace tp4.Core.Mvc.Controllers;

public class TecnologiaController : Controller
{
    IAdo _ado;
    public TecnologiaController(IAdo ado)
    {
        _ado = ado;
    }

    [HttpGet]
    public IActionResult Index() => View("ListaTecnologia", _ado.ObtenerTecnologia());

    public IActionResult Detalle(byte IdTecnologia)
    {
        if (IdTecnologia == 0)
        {
            return RedirectToAction(nameof(Index));
        }
        var requerimientosTecnologia = _ado.RequerimientosDeLaTecnologia(IdTecnologia);
        return View("Detalle", requerimientosTecnologia);
    }

    [HttpGet]
    public IActionResult AltaCliente()
    {
        return View();
    }


    [HttpGet]
    public IActionResult AltaTecnologia()
    {
        return View();
    }

    [HttpPost]
    public IActionResult AltaTecnologia(Tecnologia Tecnologia)
    {
        _ado.AltaTecnologia(Tecnologia);
        return Redirect(nameof(Index));
    }





}
