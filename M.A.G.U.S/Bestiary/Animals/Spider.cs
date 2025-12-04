using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;

namespace M.A.G.U.S.Bestiary.Animals;

public sealed class Spider : Creature
{
    public Spider()
    {
        Occurrence = Occurrence.Frequent;
        Size = Size.Small;
        Speed = 5;
        HealthPoints = 1;
        PoisonResistance = 8;
        Intelligence = Intelligence.Animal;
        ExperiencePoints = 0;
    }

    public override byte GetDamage() => 0;

    public override byte GetNumberAppearing() => 1;
}
