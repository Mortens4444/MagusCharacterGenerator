using MAGUS.Enums;

namespace MAGUS.Bestiary.Undead;

public abstract class LivingDead : Creature
{
    public NecrographyDepartment NecrographyDepartment { get; set; }

    public override bool IsUndead { get; set; } = true;
}
