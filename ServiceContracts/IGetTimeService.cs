namespace Lab1ModernMethodsOfDistributedInformationSystems.ServiceContracts;

public interface IGetTimeService
{
    public double CalculateStraightSlideTime(double h, double g);
    public double CalculateParabolicSlideTime(double h, double g);
    public double CalculateIntegral(double finish, double start, int N, double g);
}
