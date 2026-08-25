namespace MAGUS.GameSystem.Places;

/// <summary>
/// A precise (X, Y) point in the same mile-based coordinate space as CityCoordinates - unlike City,
/// which only names discrete settlements, this can represent anywhere in between (a character's real
/// position mid-journey, or a point stopped short of the destination - see Character.Position).
/// </summary>
public readonly record struct WorldPosition(double X, double Y)
{
    public double DistanceTo(WorldPosition other) => Math.Sqrt(Math.Pow(X - other.X, 2) + Math.Pow(Y - other.Y, 2));
}
