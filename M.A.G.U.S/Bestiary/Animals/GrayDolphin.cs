﻿using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;

namespace M.A.G.U.S.Bestiary.Animals;

public sealed class GrayDolphin : Creature
{
    public GrayDolphin()
    {
        Occurrence = Occurrence.Frequent;
        Intelligence = Intelligence.High;
        Size = Size._1_5_meters;
        Speed = 160;
        AttackValue = 40;
        DefenseValue = 80;
        InitiatingValue = 20;
        MaxHealthPoints = 15;
        HealthPoints = 15;
        MaxPainTolerancePoints = 30;
        PainTolerancePoints = 30;
        AstralMagicResistance = 3;
        MentalMagicResistance = 3;
        PoisonResistance = 4;
        ExperiencePoints = 0;
        Alignment = Enums.Alignment.Life;
    }

    public override string Name => "Gray dolphin";

    [DiceThrow(ThrowType._1K6)]
    [DiceThrowModifier(2)]
    public override byte GetDamage() => (byte)(DiceThrow._1K6() + 2);

    [DiceThrow(ThrowType._2K6)]
    public override byte GetNumberAppearing() => (byte)DiceThrow._2K6();
}
