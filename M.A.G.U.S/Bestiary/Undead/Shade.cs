using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Bestiary.Undead;

public sealed class Shade : LivingDead
{
    public Shade()
    {
        Occurrence = Occurrence.Rare;
        Size = Size.Human;
        PlacesOfOccurrence = TerrainType.Anywhere;

        AttackValue = 50;
        DefenseValue = 90;
        InitiateValue = 20;

        HealthPoints = 30;

        AstralMagicResistance = Int32.MaxValue;
        MentalMagicResistance = Int32.MaxValue;
        PoisonResistance = Int32.MaxValue;

        Intelligence = Enums.Intelligence.Low;
        Alignment = Alignment.ChaosDeath;
        ExperiencePoints = 550;
        NecrographyDepartment = NecrographyDepartment.Incubus;
    }
    
    public override string Name => "Shade (Arich)";

    public override string[] Images => ["shade.png"];

    [DiceThrow(ThrowType._1D10)]
    public override int GetDamage() => DiceThrow._1D10();

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 160)];
}