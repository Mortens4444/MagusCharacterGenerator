using M.A.G.U.S.GameSystem.FightModifiers;
using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Specialities;

public class HeadHunterUnknownWeaponUse : SpecialQualification, IFightModifier
{
    public short InitiatingValue => -5;

    public short AttackingValue => -5;

    public short DefendingValue => -10;

    public short AimingValue => -15;
    
    public override string Name => "Untrained weapon penalty";
}
