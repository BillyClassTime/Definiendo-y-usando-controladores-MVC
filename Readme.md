## Creacion y enrutamiento de Controllers (MVC)

### Middleware Class Startup

#### Configure Services

``` csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddSingleton<ISimpleModel, SimpleModel>();
    services.AddMvc(); //Uso del Patron MVC
}
```

#### Configure

```csharp
public void Configure(IApplicationBuilder app, IHostingEnvironment env)
{
    if (env.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
    }
	// Para que encuentre las rutas MVC por defectos	
    //app.UseMvcWithDefaultRoute(); 
    app.UseMvc(routes =>
    {
        routes.MapRoute(
            name:"default",
            template: "{controller}/{action}/{id?}",
            defaults: new { controller = "Another", 
                           action = "AnotherAction" });
    });
    app.Run(async (context) =>
    {
    	await context.Response.WriteAsync("Paginillas no encontradas :)");
    });
}
```

### Controller Class

#### Home Controller

```csharp
public class HomeController : Controller
{
    public ISimpleModel _simpleModel;
    public HomeController(ISimpleModel simpleModel)
    {
        _simpleModel = simpleModel;
    }
    public IActionResult Index()
    {
        ViewBag.Message = "Datas from HomeController Action Index";
        ViewBag.ServerTime = DateTime.Now;
        _simpleModel.Value = "Valor desde Home Action Index";
        return View(_simpleModel);
    }
}
```

#### Photo Controller

```csharp
public class PhotoController : Controller
{
    public IActionResult Index()
    {
        //ViewBag.Message = "some text"; 
        //ViewBag.ServerTime = DateTime.Now;
        ViewData["Message"] = "some text"; 
        ViewData["ServerTime"] = DateTime.Now;
        SimpleModel model = new SimpleModel() 
        { Value = "mi valor en el modelo" }; 
        return View(model);
    }
    //public RedirectToActionResult Index()
    //{
    //    return RedirectToAction("PhotoGallery");
    //}
    public IActionResult PhotoGallery()
    {
        SimpleModel model = new SimpleModel() 
        { Value = "Un valor para Photo Gallery" };
        return View(model);
    }
    public RedirectToRouteResult Otro()
    {
        return RedirectToRoute(new 
        { controller = "Another", action = "AnotherAction" });
    }
}
```

#### Another Controller

```csharp
public class AnotherController : Controller
{
    public ContentResult AnotherAction(string id)
    {
        //Ejemplo de llamado: http://localhost:5468/?id=%22Texto%22
        return Content($"Some Text:{id}"); 
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
        return Content($"Mensaje desde la Action: NuevaAction" + 
                       "del Another Controller, parametro:{titulo}");
    }
}
```

