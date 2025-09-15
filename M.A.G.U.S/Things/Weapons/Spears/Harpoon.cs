﻿using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Weapons.Spears;

public class Harpoon : Weapon, IMeleeWeapon
{
    public double AttacksPerRound => 1;

    public byte InitiatingValue => 4;

    public byte AttackingValue => 15;

    public byte DefendingValue => 10;

    public double Weight => 2;

    public Money Price => new(0, 5);

    [DiceThrow(ThrowType._1K10)]
    [DiceThrowModifier(1)]
    public byte GetDamage() => (byte)(DiceThrow._1K10() + 1);
}