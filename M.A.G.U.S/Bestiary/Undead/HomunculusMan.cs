using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Bestiary.Undead;

public sealed class HomunculusMan : Creature
{
    public HomunculusMan()
    {
        Occurrence = Occurrence.Rare;
        Size = Size.Human;

        AttackValue = 25;
        DefenseValue = 75;
        InitiateValue = 20;

        HealthPoints = 20;
        PoisonResistance = Int32.MaxValue;
        AstralMagicResistance = 2;
        MentalMagicResistance = 2;

        Intelligence = Enums.Intelligence.Average;
        Alignment = Alignment.Neutral;
        ExperiencePoints = 70;
    }

    public override string Name => "Homunculus-man";

    [DiceThrow(ThrowType._1D1)]
    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    [DiceThrow(ThrowType._1D6)]
    public override int GetDamage() => DiceThrow._1D6();

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 100)];
}