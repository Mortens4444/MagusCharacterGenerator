using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Bestiary.Mythical;

public sealed class ClockworkServant : Creature
{
    public ClockworkServant()
    {
        Occurrence = Occurrence.VeryRare;
        Size = Size.Human;

        AttackValue = 58;
        DefenseValue = 88;
        InitiateValue = 12;

        HealthPoints = 32;

        AstralMagicResistance = Int32.MaxValue;
        MentalMagicResistance = Int32.MaxValue;
        PoisonResistance = Int32.MaxValue;

        Intelligence = Enums.Intelligence.None;
        ExperiencePoints = 200;
    }

    public override string Name => "Clockwork servant";

    [DiceThrow(ThrowType._1D6)]
    public override int GetDamage() => DiceThrow._1D6(); // or by weapon

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 70)];
}