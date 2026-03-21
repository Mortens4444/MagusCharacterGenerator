using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Bestiary.Undead;

public sealed class FlameWisp : LivingDead
{
    public FlameWisp()
    {
        Occurrence = Occurrence.VeryRare;
        //Size = Size.Small;
        Size = Size.Human;
        PlacesOfOccurrence = TerrainType.Swamp;

        AttackValue = 40;
        DefenseValue = 84;
        InitiateValue = 20;

        HealthPoints = 18;

        AstralMagicResistance = Int32.MaxValue;
        MentalMagicResistance = Int32.MaxValue;
        PoisonResistance = Int32.MaxValue;

        Intelligence = Enums.Intelligence.Average;
        Alignment = Alignment.Death;
        ExperiencePoints = 60;
        NecrographyDepartment = NecrographyDepartment.Incubus;
    }

    public override string Name => "Flame Wisp";

    [DiceThrow(ThrowType._1D6)]
    public override int GetDamage() => DiceThrow._1D6();

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    public override List<Speed> Speeds => [new Speed(TravelMode.InTheAir, 160)];
}
