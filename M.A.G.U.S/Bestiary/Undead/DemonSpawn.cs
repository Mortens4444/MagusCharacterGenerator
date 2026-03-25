using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Bestiary.Undead;

public sealed class DemonSpawn : LivingDead
{
    public DemonSpawn()
    {
        Occurrence = Occurrence.Rare;
        Size = Size.Human;
        PlacesOfOccurrence = TerrainType.Anywhere;

        AttackValue = 15;
        DefenseValue = 60;
        InitiateValue = 0;

        HealthPoints = 20;

        AstralMagicResistance = Int32.MaxValue;
        MentalMagicResistance = Int32.MaxValue;
        PoisonResistance = Int32.MaxValue;

        Intelligence = Enums.Intelligence.None;
        Alignment = Alignment.ChaosDeath;
        ExperiencePoints = 65;
        NecrographyDepartment = NecrographyDepartment.UnconsciousUndead;
    }

    public override string Name => "Demonspawn (Denebola)";

    public override string[] Images => ["denebola.png"];

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(1)]
    public override int GetDamage() => DiceThrow._1D6() + 1;

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 80)];
}