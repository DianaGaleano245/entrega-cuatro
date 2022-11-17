using Microsoft.AspNetCore.Mvc;
using System.Data;
using TP4;
using TP4.Core;
using tp4.Core.Mvc.ViewModels;
namespace tp4.Core.Mvc.Controllers;

public class RequerimientoController : Controller
{
    IAdo _ado;
    public RequerimientoController(IAdo ado)
    {
        _ado = ado;
    }
    [HttpGet]
    public async Task<IActionResult> Index() => View("ListaRequerimiento", await _ado.ObtenerRequerimientoAsync());


    [HttpGet]
    public async Task<IActionResult> AltaRequerimiento()
    {
        var Tecnologias = await _ado.ObtenerTecnologiasAsync();
        var Proyectos = await _ado.ObtenerProyectosAsync();
        var vMRequerimiento = new VMRequerimiento(Tecnologias, Proyectos);
        return View(vMRequerimiento);
    }

    [HttpPost]
    public async Task<IActionResult> AltaRequerimiento(VMRequerimiento VMRequerimiento)
    {
        if (VMRequerimiento.IdRequerimiento == 0)
        {
            var Tecnologia = await _ado.TecnologiaPorIdAsync(VMRequerimiento.IdTecnologia);
            var proyectos = await _ado.ProyectoPorIdAsync(VMRequerimiento.IdProyecto);
            var Requerimiento = new Requerimiento(VMRequerimiento.IdProyecto, proyectos, Tecnologia, VMRequerimiento.DescripcionRequerimiento, VMRequerimiento.ComplejidadRequerimiento);
             await _ado.AltaRequerimientoAsync(Requerimiento);
        }
        return Redirect(nameof(Index));
    }
    public async Task<IActionResult> Detalle(int IdRequerimiento)
    {
        if (IdRequerimiento == 0)
        {
            return RedirectToAction(nameof(Index));
        }
        var RequerimietoGuardado = await _ado.RequerimientoPorIdAsync(IdRequerimiento);
        return View("Detalle",RequerimietoGuardado );
    }
}