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
    public IActionResult Index() => View("ListaProyecto", _ado.ObtenerProyectos());


    [HttpGet]
    public IActionResult AltaProyecto()
    {
        var Clientes = _ado.ObtenerClientes();
        var vmProyecto = new VMProyecto(Clientes);
        return View(vmProyecto);
    }

    [HttpPost]
    public IActionResult AltaProyecto(VMProyecto vmProyecto)
    {
        if (vmProyecto.idProyecto == 0)
        {
            var cliente = _ado.ClientePorCuit(vmProyecto.Cuit);
            var _Proyecto = new Proyecto(cliente, vmProyecto.DescripcionProyecto!, vmProyecto.PresupuestoProyecto!,vmProyecto.InicioProyecto!,vmProyecto.FinProyecto!);
            _ado.AltaProyecto(_Proyecto);
        }

        return Redirect(nameof(Index));
    }
    // public IActionResult Detalle(short IdProyecto)
    // {
    //     var ProyectoGuardado = _ado.ProyectoPorId(IdProyecto);
    //     return View("Detalle",ProyectoGuardado );
    // }
     public IActionResult Detalle(short IdProyecto)
    {
        if (IdProyecto == 0)
        {
            return RedirectToAction(nameof(Index));
        }
        var RequerimietoProyecto = _ado.RequerimientosDelProyecto(IdProyecto);
        return View("Detalle",RequerimietoProyecto );
    }

}