namespace MAGUS.Interfaces;

public interface ILiving
{
    int ActualHealthPoints { get; }

    int? ActualPainTolerancePoints { get; }
}
