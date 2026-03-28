using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;
using M.A.G.U.S.Things.Weapons.RangedWeapons;
using M.A.G.U.S.Things.Weapons.StabbingWeapons;

namespace M.A.G.U.S.Bestiary.Mythical;

public sealed class Dvorgaz : Creature
{
    public Dvorgaz()
    {
        Occurrence = Occurrence.VeryRare;
        Size = Size.Small;
        PlacesOfOccurrence = TerrainType.Urban | TerrainType.Catacombs | TerrainType.Sewer | TerrainType.DeepUnderground;

        AttackValue = 45;
        DefenseValue = 115;
        InitiateValue = 35;
        AimValue = 35;

        AttackModes =
        [
            new MeleeAttack(new Dagger(), AttackValue),
            new RangedAttack(new Sling(), AimValue)
        ];

        HealthPoints = 5;
        PainTolerancePoints = 29;

        AstralMagicResistance = 25;
        MentalMagicResistance = 35;
        PoisonResistance = 6;

        Intelligence = Enums.Intelligence.Average;
        Alignment = Alignment.ChaosDeath;
        ExperiencePoints = 175;
    }

    [DiceThrow(ThrowType._1D4)]
    public override int GetDamage() => DiceThrow._1D4();

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 160)];

    //public override string[] Sounds => ["dvorgaz_hiss", "dvorgaz_screech"];
}