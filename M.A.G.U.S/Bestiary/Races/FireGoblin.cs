using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;
using M.A.G.U.S.Things.Weapons.RangedWeapons;
using M.A.G.U.S.Things.Weapons.StabbingWeapons;

namespace M.A.G.U.S.Bestiary.Races;

public sealed class FireGoblin : Creature
{
    public FireGoblin()
    {
        Occurrence = Occurrence.Rare;
        Size = Size.Small; // 3-4 arasz
        PlacesOfOccurrence = TerrainType.Forest | TerrainType.Urban;

        AttackValue = 35;
        DefenseValue = 110;
        InitiateValue = 45;
        AimValue = 22;

        AttackModes =
        [
            new MeleeAttack(new ShortSword(), AttackValue),
            new RangedAttack(new HandCrossbow(), AimValue)
        ];

        HealthPoints = 2;
        PainTolerancePoints = 12;

        AstralMagicResistance = 55;
        MentalMagicResistance = 25;
        PoisonResistance = 8;

        Intelligence = Enums.Intelligence.High;
        Alignment = Alignment.ChaosLife;
        ExperiencePoints = 100;
    }

    public override double AttacksPerRound => 2;

    [DiceThrow(ThrowType._1D3)]
    public override int GetNumberAppearing() => DiceThrow._1D3();

    [DiceThrow(ThrowType._1D2)]
    public override int GetDamage() => DiceThrow._1D2();

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 120)];

    public override string Name => "Fire goblin";

    //public override int StealthChance => 75;

    //public override int HidingChance => 75;

    //public override string[] Sounds => ["fire_goblin_laugh", "fire_goblin_giggle"];

    //public bool IsImmuneToFire => true;

    //public bool IsAfraidOfWater => true;
}
