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
    // public IActionResult ClienteForm() => View();

    // public IActionResult ClienteForm(Cliente cliente)
    // {
    //     _ado.Altacliente(cliente);
    //     return Redirect(nameof(Index));
    // }

    [HttpGet]
    public IActionResult Index() => View("ListaCliente", _ado.ObtenerClientes());


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

    [HttpGet]
    public IActionResult Detalle(int cuit)
    {
        if (cuit == 0)
            return RedirectToAction(nameof(Index));

        var cliente = _ado.ClientePorCuit(cuit) ;
        if (cliente is null)
            return NotFound();

        


    }   





}
