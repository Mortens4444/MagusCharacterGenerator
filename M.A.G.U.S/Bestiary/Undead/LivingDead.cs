using M.A.G.U.S.Enums;

namespace M.A.G.U.S.Bestiary.Undead;

public abstract class LivingDead : Creature
{
    public NecrographyDepartment NecrographyDepartment { get; set; }

    public override bool IsUndead { get; set; } = true;
}
