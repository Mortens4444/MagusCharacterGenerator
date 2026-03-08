using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;
using M.A.G.U.S.Things.Weapons;

namespace M.A.G.U.S.Bestiary.Mythical;

public sealed class Eccydoorr : Creature
{
    public Eccydoorr()
    {
        Occurrence = Occurrence.VeryRare;
        Size = Size.Huge;
        PlacesOfOccurrence = TerrainType.SouthernSnowfield;

        AttackValue = 95;
        DefenseValue = 80;

        AttackModes =
        [
            new MeleeAttack(new CommonWeapon("Claw", 0, 0, 0, throwType: ThrowType._4D6), AttackValue),
            new MeleeAttack(new CommonWeapon("Claw", 0, 0, 0, throwType: ThrowType._4D6), AttackValue),
            new MeleeAttack(new CommonWeapon("Bite", 0, 0, 0, throwType: ThrowType._3D10), AttackValue)
        ];

        HealthPoints = 55;
        PainTolerancePoints = 140;

        AstralMagicResistance = Int32.MaxValue;
        MentalMagicResistance = Int32.MaxValue;
        PoisonResistance = Int32.MaxValue;

        Intelligence = Enums.Intelligence.Average;
        Alignment = Alignment.Chaos;

        ExperiencePoints = 1850;
    }

    public override string Name => "Ice Dragon (Eccydoo'rr)";

    public override string[] Images => ["eccydoo_rr.png"];

    [DiceThrow(ThrowType._4D6)]
    public override int GetDamage() => DiceThrow._4D6();

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    public override List<Speed> Speeds =>
    [
        new Speed(TravelMode.OnLand, 60),
        new Speed(TravelMode.InTheAir, 120)
    ];
}