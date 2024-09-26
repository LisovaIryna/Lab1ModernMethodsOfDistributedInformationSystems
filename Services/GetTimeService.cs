using Lab1ModernMethodsOfDistributedInformationSystems.ServiceContracts;

namespace Lab1ModernMethodsOfDistributedInformationSystems.Services;

public class GetTimeService : IGetTimeService
{
    //Calculation of the time of movement of the ball along the straight line
    public double CalculateStraightSlideTime(double g) =>
        2 / Math.Sqrt(g);

    //Calculation of the time of movement of the ball along the parabola
    public double CalculateParabolicSlideTime(double g) =>
        CalculateIntegral(0, 1, 1000, g);

    //Calculation of the integral of a parabola
    public double CalculateIntegral(double x0, double x1, int N, double g)
    {
        double sum = 0;
        double subintervalWidth = (x1 - x0) / N;

        for (int i = 0; i < N; i++)
        {
            double x = x0 + i * subintervalWidth;
            double derivativeOfFunction = 2 * x;
            double integralCurve = Math.Sqrt(1 +  derivativeOfFunction * derivativeOfFunction) / Math.Sqrt(1 - Math.Pow(x, 2));
            sum += integralCurve;
        }
        double integralResult = subintervalWidth * sum;

        return integralResult / Math.Sqrt(2 * g);
    }
}
