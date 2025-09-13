using DependencyInjectionSample.Interfaces;
using DependencyInjectionSample.Services;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjectionSample.Controllers;

public class OperationsController : Controller
{
    private static int _requestNumber = 0;

    public IActionResult Index(
        [FromServices] OperationService service,
        [FromServices] IOperationTransient transient,
        [FromServices] IOperationScoped scoped,
        [FromServices] IOperationSingleton singleton,
        [FromServices] IOperationSingletonInstance instance)
    {
        _requestNumber++;
        ViewBag.RequestNumber = _requestNumber;
        ViewBag.Service = service;
        ViewBag.Transient = transient;
        ViewBag.Scoped = scoped;
        ViewBag.Singleton = singleton;
        ViewBag.SingletonInstance = instance;
        return View();
    }
}
