using M.A.G.U.S.GameSystem.Qualifications;
using M.A.G.U.S.Interfaces;

namespace M.A.G.U.S.Qualifications.Specialities;

public class HeadHunterUnknownWeaponUse : SpecialQualification, ICombatModifier
{
    public int InitiateValue => -5;

    public int AttackValue => -5;

    public int DefenseValue => -10;

    public int AimValue => -15;
    
    public override string Name => "Untrained weapon penalty";
}
