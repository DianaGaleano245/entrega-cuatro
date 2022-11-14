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
