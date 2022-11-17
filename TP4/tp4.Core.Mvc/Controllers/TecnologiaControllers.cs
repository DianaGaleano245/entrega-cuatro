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
    public async Task<IActionResult> Index() => View("ListaTecnologia",await _ado.ObtenerTecnologiasAsync());

    public async Task<IActionResult> Detalle(byte IdTecnologia)
    {
        if (IdTecnologia == 0)
        {
            return RedirectToAction(nameof(Index));
        }
        var requerimientosTecnologia = await _ado.RequerimientosDeLaTecnologiaAsync(IdTecnologia);
        return View("Detalle", requerimientosTecnologia);
    }

    [HttpGet]
    public IActionResult AltaTecnologia()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> AltaTecnologia(Tecnologia Tecnologia)
    {
        await _ado.AltaTecnologiaAsync(Tecnologia);
        return Redirect(nameof(Index));
    }





}
