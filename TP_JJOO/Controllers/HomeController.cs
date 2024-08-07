using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP_JJOO.Models;

namespace TP_JJOO.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Deportes()
    {
        //ViewBag.ListaDeportes = 
        return View();
    }

    public IActionResult Paises()
    {
        ViewBag.ListaPaises = BD.ListarPaises(); 
        return View();
    }

    public IActionResult VerDetalleDeporte(int idDeporte)
    {
        //ViewBag.DatosDeporte = BD.de
        ViewBag.ListaDeportistas = BD.ListarDeportistasXdep(idDeporte);
        return View("DetalleDeporte");
    }

    public IActionResult VerDetallePais(int idPais)
    {
        //ViewBag.ListaPaises = BD. 
        ViewBag.ListaDeportistasPais = BD.ListarDeportistasXpais(idPais);
        return View("DetallePais");
    }

    

    
}
