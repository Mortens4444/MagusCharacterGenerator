using M.A.G.U.S.GameSystem.Qualifications;
using M.A.G.U.S.Things.Weapons;

namespace M.A.G.U.S.Qualifications.Battle;

public class WeaponUse(QualificationLevel qualificationLevel = QualificationLevel.Base, byte level = 1) : Qualification(qualificationLevel, level), ICanHaveMany
{
    public IWeapon? Weapon { get; set; }

    public override string Name => "Weapon use";
}
