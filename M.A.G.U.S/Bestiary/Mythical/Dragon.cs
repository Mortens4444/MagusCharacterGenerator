using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;
using M.A.G.U.S.Things.Weapons;

namespace M.A.G.U.S.Bestiary.Mythical;

public sealed class Dragon : Creature
{
    public Dragon()
    {
        Occurrence = Occurrence.VeryRare;
        Size = Size.Huge;

        AttackModes =
        [
            new MeleeAttack(new BodyPart("Weak paw strike", ThrowType._5D6), 60),
            new MeleeAttack(new BodyPart("Powerful paw strike", ThrowType._7D6), 145),
            new MeleeAttack(new BodyPart("Weak tail strike", ThrowType._10D6), 70),
            new MeleeAttack(new BodyPart("Powerful tail strike", ThrowType._14D6), 125),
            new MeleeAttack(new BodyPart("Weak bite strike", ThrowType._4D6), 100),
            new MeleeAttack(new BodyPart("Powerful bite strike", ThrowType._8D6), 175),
            new RangeAttack(new BreathWeaponcs("Weak fire breath", ThrowType._1D6_Ranged), 40),
            new RangeAttack(new BreathWeaponcs("Powerful fire breath", ThrowType._15D6_Ranged), 60)
        ];
        AttackValue = 70;
        DefenseValue = 125;
        InitiateValue = 0;
        MinHealthPoints = 50;
        MaxHealthPoints = 250;
        MinPainTolerancePoints = 150;
        MaxPainTolerancePoints = 650;
        AstralMagicResistance = Byte.MaxValue;
        MentalMagicResistance = Byte.MaxValue;
        PoisonResistance = Byte.MaxValue;
        MinIntelligence = Enums.Intelligence.Average;
        MaxIntelligence = Enums.Intelligence.Outstanding;
        //ManaPoints = Variable;
        Alignment = Enums.Alignment.ChaosDeath;
        ExperiencePoints = 300000;
    }

    [DiceThrow(ThrowType._1D6)]
    public override int GetDamage() => DiceThrow._1D6();

    public override int GetNumberAppearing() => 1;

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 50), new Speed(TravelMode.InTheAir, 300)];
}
