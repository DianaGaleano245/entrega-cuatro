using Microsoft.AspNetCore.Mvc;
using ClienteMVC.Models;
using TP4;

namespace ClienteMVC.Controllers;
public class HomeControhgvbvbvbvbller : Controller
{
    public IActionResult Index() => View();

    public IActionResult InvitacionForm() => View();

    public IActionResult InvitacionForm(Invitacion invitacion)
    {
        Cliente.AltaCliente(4);
        return View("Gracias", invitacion);
    }
    public ViewResult ListaCliente() => View(Cliente.AltaCliente);
}