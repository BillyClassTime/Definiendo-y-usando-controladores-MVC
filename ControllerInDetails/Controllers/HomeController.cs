using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControllerInDetails.Models;
namespace ControllerInDetails.Controllers
{
    public class PhotoController : Controller
    {
        public IActionResult Index()
        {
            //ViewBag.Message = "some text"; 
            //ViewBag.ServerTime = DateTime.Now;
            ViewData["Message"] = "some text"; 
            ViewData["ServerTime"] = DateTime.Now;
            SimpleModel model = new SimpleModel() { Value = "mi valor en el modelo" }; 
            return View(model);
        }
        //public RedirectToActionResult Index()
        //{
        //    return RedirectToAction("PhotoGallery");
        //}
        public IActionResult PhotoGallery()
        {
            SimpleModel model = new SimpleModel() { Value = "Un valor para Photo Gallery" };
            return View(model);
        }
        public RedirectToRouteResult Otro()
        {
            return RedirectToRoute(new { controller = "Another", action = "AnotherAction" });
        }

    }

    public class AnotherController : Controller
    {
        public ContentResult AnotherAction(string id)
        {
            return Content($"Some Text:{id}"); //Ejemplo de llamado: http://localhost:5468/?id=%22Texto%22
                                               //Siempre y cuando siga siendo la ruta por defecto
        }

        public StatusCodeResult Index()
        {
            return new StatusCodeResult(404);
        }

        public StatusCodeResult Ciudades()
        {
            return new StatusCodeResult(500);
        }

        public IActionResult NuevaAction()//string titulo)
        {
            string titulo = (string)RouteData.Values["Titulo"];
            return Content($"Mensaje desde la Action: NuevaAction, parametro:{titulo}");
        }
    }
}
