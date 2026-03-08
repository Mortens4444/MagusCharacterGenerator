using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;
using M.A.G.U.S.Things.Weapons;

namespace M.A.G.U.S.Bestiary.Mythical;

public class Nayan : Creature
{
    public Nayan()
    {
        Occurrence = Occurrence.VeryRare;
        Size = Size.Big;
        PlacesOfOccurrence = TerrainType.Icefield;

        AttackValue = 120;
        DefenseValue = 185;
        InitiateValue = 70;

        AttackModes =
        [
            new MeleeAttack(new CommonWeapon("Claw", 0, 0, 0, throwType: ThrowType._3D6), AttackValue),
            new MeleeAttack(new CommonWeapon("Claw", 0, 0, 0, throwType: ThrowType._3D6), AttackValue),
            new MeleeAttack(new CommonWeapon("Bite", 0, 0, 0, throwType: ThrowType._2D6), AttackValue),
            new MeleeAttack(new CommonWeapon("Tail", 0, 0, 0, throwType: ThrowType._4D6), AttackValue)
        ];

        HealthPoints = 20;
        PainTolerancePoints = 90;

        AstralMagicResistance = Int32.MaxValue;
        MentalMagicResistance = Int32.MaxValue;
        PoisonResistance = Int32.MaxValue;

        Intelligence = Enums.Intelligence.Low;

        ExperiencePoints = 5000;
    }

    public override string Name => "Ice Demon (Nayan)";

    public override string[] Images => ["nayan.png"];

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;
    
    [DiceThrow(ThrowType._4D6)]
    public override int GetDamage() => DiceThrow._4D6();

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 200)];
}