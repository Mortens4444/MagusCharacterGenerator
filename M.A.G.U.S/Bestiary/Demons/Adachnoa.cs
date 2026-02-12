using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;
using M.A.G.U.S.Things.Weapons;

namespace M.A.G.U.S.Bestiary.Mythical;

public sealed class Adachnoa : Creature
{
    public Adachnoa()
    {
        Occurrence = Occurrence.VeryRare;
        Size = Size.Human;

        AttackModes =
        [
            new MeleeAttack(new CommonWeapon("Sword", 0, 0, 0, throwType: ThrowType._2D6, attacksPerRound: 2), AttackValue),
            new RangedAttack(new CommonRangedWeapon("Crossbow", 0, 0, 50, throwType: ThrowType._1D6_Ranged, attacksPerRound: 2), AimValue)
        ];
        AttackValue = 95;
        DefenseValue = 175;
        InitiateValue = 65;
        HealthPoints = 55;
        AstralMagicResistance = Int32.MaxValue;
        MentalMagicResistance = 45;
        PoisonResistance = Int32.MaxValue;
        Intelligence = Enums.Intelligence.High;
        Alignment = Enums.Alignment.Chaos;
        ExperiencePoints = 7650;
    }

    public override string Name => "Adachnoa (mirror demon)";

    public override string[] Images => ["adachnoa.png"];


    [DiceThrow(ThrowType._1D6)]
    public override int GetDamage() => DiceThrow._1D6();

    public override int GetNumberAppearing() => 1;

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 140)];
}
