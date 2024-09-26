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
        return View();
    }

    public IActionResult GetChartDataAndTimeResult()
    {
        double h = 1;
        double g = 9.81;

        double timeStraightLine = _getTimeService.CalculateStraightSlideTime(g);
        double timeParabola = _getTimeService.CalculateParabolicSlideTime(g);

        //Calculate data for chart
        int points = 100;
        double[] straightLinePoints = new double[points + 1];
        double[] parabolaPoints = new double[points + 1];
        string[] labels = new string[points + 1];
        for (int i = 0; i < points; i++)
        {
            double fraction = (double)i / points;
            straightLinePoints[i] = h * fraction;
            parabolaPoints[i] = h * Math.Pow(fraction, 2);
            labels[i] = fraction.ToString("F2");
        }

        //Data for chart
        var chartData = new
        {
            labels,
            straightLinePoints,
            parabolaPoints,
            time = new
            {
                timeStraightLine,
                timeParabola
            }
        };

        return Json(chartData);
    }
}
