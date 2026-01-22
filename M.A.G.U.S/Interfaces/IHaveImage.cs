namespace M.A.G.U.S.Interfaces;

public interface IHaveImage
{
    string[] Images { get; }

    string DefaultImage { get; }

    string RandomImage { get; }
}
