using M.A.G.U.S.Enums;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Bestiary.Animals;

public sealed class Spider : Creature
{
    public Spider()
    {
        Occurrence = Occurrence.Frequent;
        Size = Size.Small;
        HealthPoints = 1;
        PoisonResistance = 8;
        Intelligence = Enums.Intelligence.Animal;
        ExperiencePoints = 0;
    }

    public override int GetDamage() => 0;

    public override int GetNumberAppearing() => 1;

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 5)];
}
