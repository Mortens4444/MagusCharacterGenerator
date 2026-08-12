using MAGUS.GameSystem.Qualifications;

namespace MAGUS.Qualifications.Specialities;

public class CharmAura(int intensity) : SpecialQualification
{
    public int Intensity { get; } = intensity;

    public override string Name => "Charm Aura";
}
