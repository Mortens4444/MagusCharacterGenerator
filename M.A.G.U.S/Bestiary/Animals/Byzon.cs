using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;
using M.A.G.U.S.Things.Armors;
using M.A.G.U.S.Things.Weapons;

namespace M.A.G.U.S.Bestiary.Animals;

public sealed class Byzon : Creature
{
    public Byzon()
    {
        Armor = new NaturalArmor(1);
        Occurrence = Occurrence.Frequent;
        Size = Size.Big;
        AttackValue = 60;
        DefenseValue = 60;
        InitiateValue = 7;
        AttackModes =
        [
            new MeleeAttack(new BodyPart("Horn​", ThrowType._1D6, 2), AttackValue),
            new MeleeAttack(new BodyPart("Hoof", ThrowType._1D6, 4), AttackValue),
        ];
        HealthPoints = 42;
        PainTolerancePoints = 54;
        PoisonResistance = 4;
        Intelligence = Enums.Intelligence.Animal;
        ExperiencePoints = 6;
    }

    public override double AttacksPerRound => 1.0 / 3;

    public override string Name => "Byzon-buffalo";

    public override string[] Images => ["byzon.png"];

    [DiceThrow(ThrowType._1D10)]
    public override int GetDamage() => DiceThrow._1D10();

    [DiceThrow(ThrowType._1D100)]
    public override int GetNumberAppearing() => DiceThrow._1D100();

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 150)];
}
