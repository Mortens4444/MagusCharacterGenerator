using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;
using M.A.G.U.S.Things.Weapons;

namespace M.A.G.U.S.Bestiary.Elementals;

public sealed class AirLord : ElementalLord
{
    public AirLord()
    {
        Size = Size.Human;

        AttackValue = 80;
        DefenseValue = 180;
        InitiateValue = 60;

        AttackModes =
        [
            new MeleeAttack(new BodyPart("Air strike", ThrowType._1D10), AttackValue)
        ];

        HealthPoints = 60;

        ExperiencePoints = 15000;
    }

    public override string Name => "Air Lord";

    [DiceThrow(ThrowType._1D10)]
    public override int GetDamage() => DiceThrow._1D10();

    public override List<Speed> Speeds => [new Speed(TravelMode.InTheAir, 140)];
}