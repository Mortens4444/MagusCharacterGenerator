using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;
using M.A.G.U.S.Things.Weapons;

namespace M.A.G.U.S.Bestiary.Elementals;

public sealed class WaterLord : ElementalLord
{
    public WaterLord()
    {
        Size = Size.Human;

        InitiateValue = 36;
        AttackValue = 95;
        DefenseValue = 170;

        AttackModes =
        [
            new MeleeAttack(new BodyPart("Great Ice Sword", ThrowType._1D10, 36), AttackValue), // 1k10+60 őstűz lényei ellen
        ];

        HealthPoints = 60; // Regenerates 1 HP per minute when in contact with natural water. Magic or Fire-based weapons only, Fire deals max damage but loses 10 E.

        ExperiencePoints = 40000;
    }

    public override string Name => "Water Lord";

    [DiceThrow(ThrowType._1D10)]
    [DiceThrowModifier(36)]
    public override int GetDamage() => DiceThrow._1D10() + 36;

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 80), new Speed(TravelMode.InWater, 160)];
}