namespace Lab1ModernMethodsOfDistributedInformationSystems.ServiceContracts;

public interface IGetTimeService
{
    public double CalculateStraightSlideTime(double h, double g);
    public double CalculateParabolicSlideTime(double g);
    public double CalculateIntegral(double x0, double x1, int N, double g);
}
