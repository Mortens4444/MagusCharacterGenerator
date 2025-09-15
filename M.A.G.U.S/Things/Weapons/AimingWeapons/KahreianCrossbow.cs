﻿using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Weapons.AimingWeapons;

public class KahreianCrossbow : Weapon, IRangedWeapon
{
    public double AttacksPerRound => 3;

    public byte InitiatingValue => 9;

    public byte AimingValue => 13;

    public ushort Distance => 30;

    public double Weight => 3;

    public Money Price => new(80);

    [DiceThrow(ThrowType._1K3)]
    public byte GetDamage() => (byte)DiceThrow._1K3_RangedAttack();

    public override string Name => "Kahreian crossbow";
}