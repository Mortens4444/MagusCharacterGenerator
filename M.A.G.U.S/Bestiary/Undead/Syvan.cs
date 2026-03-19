using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Bestiary.Undead;

public sealed class Syvan : LivingDead
{
    public Syvan()
    {
        Occurrence = Occurrence.VeryRare;
        Size = Size.Human;
        PlacesOfOccurrence = TerrainType.Grassland;
        Country = GameSystem.Places.Country.DwyllUnion;

        AttackValue = 60;
        DefenseValue = 90;
        InitiateValue = 25;

        HealthPoints = 13;

        AstralMagicResistance = Int32.MaxValue;
        MentalMagicResistance = 7;
        PoisonResistance = Int32.MaxValue;

        Intelligence = Enums.Intelligence.High;
        Alignment = Alignment.ChaosDeath;

        ExperiencePoints = 850;
        NecrographyDepartment = NecrographyDepartment.NightMonster;
    }

    [DiceThrow(ThrowType._1D6)]
    public override int GetNumberAppearing() => DiceThrow._1D6();

    [DiceThrow(ThrowType._1D6)]
    public override int GetDamage() => DiceThrow._1D6();

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 40)];
}