using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Specialities;

public class NotTolerateStrongLight(int maximumToleratedLightEnergy, int modifierInStrongLight) : SpecialQualification
{
    public int MaximumToleratedLightEnergy { get; } = maximumToleratedLightEnergy;

    public int ModifierInStrongLight { get; } = modifierInStrongLight;

    public override string Name => "Cannot tolerate strong light";
}
