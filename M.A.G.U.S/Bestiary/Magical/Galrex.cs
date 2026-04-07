using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Bestiary.Magical;

public sealed class Galrex : Creature
{
    public Galrex()
    {
        Occurrence = Occurrence.VeryRare;
        Size = Size.Huge;

        DefenseValue = 60;

        HealthPoints = 80;

        AstralMagicResistance = 100;
        MentalMagicResistance = 100;
        PoisonResistance = Int32.MaxValue;

        Intelligence = Enums.Intelligence.Low;
        Alignment = Alignment.Chaos;
        ExperiencePoints = 3000;
    }

    public override int GetDamage() => 0;

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    public override List<Speed> Speeds => [new Speed(TravelMode.InTheAir, 160)];
}
