using Lab1ModernMethodsOfDistributedInformationSystems.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace Lab1ModernMethodsOfDistributedInformationSystems.Controllers;

public class BallDownController : Controller
{
    private readonly IGetTimeService _getTimeService;

    public BallDownController(IGetTimeService getTimeService)
    {
        _getTimeService = getTimeService;
    }

    [Route("/")]
    public IActionResult Index()
    {
        double g = 9.81;

        ViewBag.StraightTime = _getTimeService.CalculateStraightSlideTime(g).ToString();
        ViewBag.ParabolaTime = _getTimeService.CalculateParabolicSlideTime(g).ToString();

        return View();
    }
}
