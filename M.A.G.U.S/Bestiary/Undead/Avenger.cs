using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Bestiary.Undead;

public sealed class Avenger : LivingDead
{
    public Avenger()
    {
        Occurrence = Occurrence.Rare;
        Size = Size.Human;
        PlacesOfOccurrence = TerrainType.Anywhere;

        AttackValue = 30;
        DefenseValue = 70;
        InitiateValue = 10;

        HealthPoints = 10;

        AstralMagicResistance = Int32.MaxValue;
        MentalMagicResistance = 15;
        PoisonResistance = Int32.MaxValue;

        Intelligence = Enums.Intelligence.High;
        Alignment = Alignment.ChaosDeath;
        ExperiencePoints = 30;
        NecrographyDepartment = NecrographyDepartment.NightMonster;
    }
    
    public override string Name => "Avenger (Beid)";

    public override string[] Images => ["avenger.png"];

    [DiceThrow(ThrowType._1D6)]
    public override int GetDamage() => DiceThrow._1D6();

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 75)];
}