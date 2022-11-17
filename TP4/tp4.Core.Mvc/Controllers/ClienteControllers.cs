using Microsoft.AspNetCore.Mvc;
using TP4.Core;
namespace tp4.Core.Mvc.Controllers;

public class ClienteController : Controller
{
    IAdo _ado;
    public ClienteController(IAdo ado)
    {
        _ado = ado;
    }
    public async Task<IActionResult> Index() => View("ListaCliente", await _ado.ObtenerClientesAsync());

    public async Task<IActionResult> Detalle(int Cuit)
    {
        if (Cuit == 0)
        {
            //El "RedirectToAction" redirecciona al metodo "Index()" 
            return RedirectToAction(nameof(Index));
        }

        // Guardamos en la variable "proyectosCliente" los proyectos de los cuales el cuit del cliente que contienen
        // sea igual al Cuit que le pasamos por parametro en este caso "Cuit"
        var proyectosCliente = await _ado.ProyectosDelClienteAsync(Cuit);
        return View("Detalle", proyectosCliente);
    }

    [HttpGet]
    public IActionResult AltaCliente()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> AltaCliente(Cliente cliente)
    {
        await _ado.AltaclienteAsync(cliente);
        return Redirect(nameof(Index));
    }

}