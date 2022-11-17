using Microsoft.AspNetCore.Mvc;
using System.Data;
using tp4.Core.Mvc.ViewModels;
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
    public async Task<IActionResult> Index() => View("ListaProyecto", await _ado.ObtenerProyectosAsync());


    [HttpGet]
    public async Task<IActionResult> AltaProyecto()
    {
        var Clientes = await _ado.ObtenerClientesAsync();
        var vmProyecto = new VMProyecto(Clientes);
        return View(vmProyecto);
    }

    [HttpPost]
    public async Task<IActionResult> AltaProyecto(VMProyecto vmProyecto)
    {
        if (vmProyecto.idProyecto == 0)
        {
            var cliente = await _ado.ClientePorCuitAsync(vmProyecto.Cuit);
            var _Proyecto = new Proyecto(cliente, vmProyecto.DescripcionProyecto!, vmProyecto.PresupuestoProyecto!,vmProyecto.InicioProyecto!,vmProyecto.FinProyecto!);
            await _ado.AltaProyectoAsync(_Proyecto);
        }

        return Redirect(nameof(Index));
    }
    // public IActionResult Detalle(short IdProyecto)
    // {
    //     var ProyectoGuardado = _ado.ProyectoPorId(IdProyecto);
    //     return View("Detalle",ProyectoGuardado );
    // }
     public async Task<IActionResult> Detalle(short IdProyecto)
    {
        if (IdProyecto == 0)
        {
            return RedirectToAction(nameof(Index));
        }
        var RequerimietoProyecto = await _ado.RequerimientosDelProyectoAsync(IdProyecto);
        return View("Detalle",RequerimietoProyecto );
    }

}