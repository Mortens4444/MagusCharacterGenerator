using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Specialities;

public class CharmAura(int intensity) : SpecialQualification
{
    public int Intensity { get; } = intensity;

    public override string Name => "Charm Aura";
}
