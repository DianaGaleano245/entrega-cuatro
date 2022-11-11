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
    public IActionResult Index() => View("ListaRequerimiento", _ado.ObtenerRequerimiento());


    [HttpGet]
    public IActionResult AltaRequerimiento()
    {
        var Tecnologias = _ado.ObtenerTecnologia();
        var Proyectos = _ado.ObtenerProyectos();
        var vMRequerimiento = new VMRequerimiento(Tecnologias, Proyectos);
        return View(vMRequerimiento);
    }

    [HttpPost]
    public IActionResult AltaRequerimiento(VMRequerimiento VMRequerimiento)
    {
        if (VMRequerimiento.IdRequerimiento == 0)
        {
            var Tecnologia = _ado.TecnologiaPorId(VMRequerimiento.IdTecnologia);
            var proyectos = _ado.ProyectoPorId(VMRequerimiento.IdProyecto);
            var Requerimiento = new Requerimiento(VMRequerimiento.IdProyecto, proyectos, Tecnologia, VMRequerimiento.DescripcionRequerimiento, VMRequerimiento.ComplejidadRequerimiento);
            _ado.AltaRequerimiento(Requerimiento);
        }
        return Redirect(nameof(Index));
    }
}
