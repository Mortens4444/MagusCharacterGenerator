using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Specialities;

public class NotTolerateStrongLight(byte maximumToleratedLightEnergy, sbyte modifierInStrongLight) : SpecialQualification
{
    public byte MaximumToleratedLightEnergy { get; } = maximumToleratedLightEnergy;

    public sbyte ModifierInStrongLight { get; } = modifierInStrongLight;

    public override string Name => "Cannot tolerate strong light";
}
