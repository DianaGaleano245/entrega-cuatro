using Microsoft.AspNetCore.Mvc;
using System.Data;
using TP4;
namespace tp4.Core.Mvc.Controllers;

public class ClienteController : Controller
{
    IAdo _ado;
    public ClienteController(IAdo ado)
    {
        _ado = ado;
    }
    public IActionResult Index() => View();

    public IActionResult ClienteForm() => View();

    public IActionResult ClienteForm(Cliente cliente)
    {
        _ado.altacliente(cliente);
        return Redirect(nameof(Index));
    }
    [HttpGet]

    public ViewResult ListaCliente() => View(_ado.ObtenerClientes());




}
