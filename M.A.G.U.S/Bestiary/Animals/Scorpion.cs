using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Bestiary.Animals;

public sealed class Scorpion : Creature
{
    public Scorpion()
    {
        Occurrence = Occurrence.Frequent;
        Size = Size.Small;
        HealthPoints = 1;
        PoisonResistance = 8;
        Intelligence = Enums.Intelligence.Animal;
    }

    [DiceThrowModifier(1)]
    public override int GetDamage() => 1; // + add poison damage

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 5)];
}
