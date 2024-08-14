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
        ViewBag.ListaDeportes = BD.ListarDeportes();
        return View();
    }

    public IActionResult Paises()
    {
        ViewBag.ListaPaises = BD.ListarPaises(); 
        return View();
    }

    public IActionResult VerDetalleDeporte(int idDeporte)
    {
        ViewBag.DatosDeporte = BD.Deporte(idDeporte);
        ViewBag.ListaDeportistas = BD.ListarDeportistasXdep(idDeporte);
        return View("VerDetalleDeporte");
    }

    public IActionResult VerDetallePais(int idPais)
    {
        ViewBag.ListaPaises = BD.Pais(idPais);
        ViewBag.ListaDeportistasPais = BD.ListarDeportistasXpais(idPais).ToList();
        return View("VerDetallePais");
    }

    public IActionResult VerDetalleDeportista(int IdDeportista)
    {
        ViewBag.DatpsDeportista = BD.Deportista(IdDeportista);
        return View("VerDetalleDeportista");
    }

    public IActionResult AgregarDeportista(){

        ViewBag.ListaPaises = BD.ListarPaises().ToList();
        ViewBag.ListaDeportes = BD.ListarDeportes().ToList();
        return View(); //form con deportistas para cargar.
    }

    public IActionResult EliminarDeportista (int idCandidato)
    {
        ViewBag.CantDeportistaEliminado = "Deportistas eliminados: "+ BD.EliminarDeportista(idCandidato);
        return View("Index");

    }

    [HttpPost] public IActionResult GuardarDeportista (Deportista dep)
    {
        BD.AgregarDeportista(dep);
        return View("Index");
    }

    public IActionResult Creditos ()
    {
        return View();
    }

    public IActionResult Historia()
    {
        return View();
    }

    




    

    
}
