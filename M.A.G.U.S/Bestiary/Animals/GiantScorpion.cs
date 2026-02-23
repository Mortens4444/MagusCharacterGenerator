using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;
using M.A.G.U.S.Things.Armors;
using M.A.G.U.S.Things.Weapons;

namespace M.A.G.U.S.Bestiary.Animals;

public sealed class GiantScorpion : Creature
{
    public GiantScorpion()
    {
        Occurrence = Occurrence.VeryRare;
        Intelligence = Enums.Intelligence.Animal;
        Size = Size.Small;
        InitiateValue = 30;
        AttackValue = 40;
        DefenseValue = 80;
        Armor = new NaturalArmor(3);
        AttackModes =
        [
            new MeleeAttack(new BodyPart("Sting", ThrowType._1D6), AttackValue), // + add poison damage
            new MeleeAttack(new BodyPart("Scissors", ThrowType._1D10), AttackValue)
        ];
        HealthPoints = 24;
        PainTolerancePoints = 14;
        PoisonResistance = 8;
        ExperiencePoints = 35;
    }

    [DiceThrow(ThrowType._2D10)]
    public override int GetDamage() => DiceThrow._2D10();

    public override string Name => "Giant scorpion";


    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 85)];
}
