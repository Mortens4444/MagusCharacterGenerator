using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Bestiary.Undead;

public sealed class Phantom : LivingDead
{
    public Phantom()
    {
        Occurrence = Occurrence.Rare;
        Size = Size.Human;
        PlacesOfOccurrence = TerrainType.Anywhere;

        AttackValue = 45;
        DefenseValue = 70;
        InitiateValue = 15;

        HealthPoints = 32;
        PoisonResistance = Int32.MaxValue;
        AstralMagicResistance = Int32.MaxValue;
        MentalMagicResistance = Int32.MaxValue;

        Intelligence = Enums.Intelligence.Low;
        Alignment = Alignment.ChaosDeath;
        ExperiencePoints = 80;
        NecrographyDepartment = NecrographyDepartment.Incubus;
    }

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    [DiceThrow(ThrowType._1D6)]
    public override int GetDamage() => DiceThrow._1D6();

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 160)];
}
