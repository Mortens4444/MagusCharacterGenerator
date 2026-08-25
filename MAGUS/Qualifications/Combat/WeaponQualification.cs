using MAGUS.GameSystem.Qualifications;
using MAGUS.Things.Weapons;

namespace MAGUS.Qualifications.Combat;

public abstract class WeaponQualification(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : Qualification(qualificationLevel, level)
{
    public override string Key => $"{GetType().Name}:{Weapon?.GetType().Name ?? Guid.NewGuid().ToString()}";

    public Weapon? Weapon { get; set; }

    public override bool NeedsSelection => Weapon == null;

    public WeaponQualification() : this(QualificationLevel.Base) { }
}
