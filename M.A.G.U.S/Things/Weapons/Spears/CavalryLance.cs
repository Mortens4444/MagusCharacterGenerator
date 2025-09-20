﻿using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Weapons.Spears;

public class CavalryLance : Weapon, IMeleeWeapon
{
    public double AttacksPerRound => 1 / 2;

    public byte InitiatingValue => 1;

    public byte AttackingValue => 15;

    public byte DefendingValue => 0;

    public double Weight => 3.5;

    public override Money Price => new(1);

    [DiceThrow(ThrowType._1K6)]
    public byte GetDamage() => (byte)(DiceThrow._1K6());

    public override string Name => "Cavalry lance";
}