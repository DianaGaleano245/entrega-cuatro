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
    public IActionResult Index() => View("ListaCliente", _ado.ObtenerClientes());

    public IActionResult Detalle(int Cuit)
    {
        if (Cuit == 0)
        {
            //El "RedirectToAction" redirecciona al metodo "Index()" 
            return RedirectToAction(nameof(Index));
        }

        // Guardamos en la variable "proyectosCliente" los proyectos de los cuales el cuit del cliente que contienen
        // sea igual al Cuit que le pasamos por parametro en este caso "Cuit"
        var proyectosCliente = _ado.ProyectosDelCliente(Cuit);
        return View("Detalle", proyectosCliente);
    }

    [HttpGet]
    public IActionResult AltaCliente()
    {
        return View();
    }

    [HttpPost]
    public IActionResult AltaCliente(Cliente cliente)
    {
        _ado.Altacliente(cliente);
        return Redirect(nameof(Index));
    }
    



        







}
