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
            //El "RedirectToAction" redirecciona al metodo "Index()" 
            return RedirectToAction(nameof(Index));
        }

        // Guardamos en la variable "proyectosCliente" los proyectos de los cuales el cuit del cliente que contienen
        // sea igual al Cuit que le pasamos por parametro en este caso "Cuit"
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
