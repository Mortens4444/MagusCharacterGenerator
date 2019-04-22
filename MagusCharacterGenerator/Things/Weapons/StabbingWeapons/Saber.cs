﻿using MagusCharacterGenerator.GameSystem.Attributes;
using MagusCharacterGenerator.GameSystem.Valuables;
using MagusCharacterGenerator.GameSystem.Weapons;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.StabbingWeapons
{
    class Saber : Weapon, IMeleeWeapon
    {
        public double AttacksPerRound => 1;

        public byte InitiatingValue => 7;

        public byte AttackingValue => 15;

        public byte DefendingValue => 17;

        public double Weight => 1.5;

        public Money Price => new Money(1, 6);

		[DiceThrow(ThrowType._1K6)]
		[DiceThrowModifier(2)]
		public byte GetDamage() => (byte)(DiceThrow._1K6() + 2);

        public override string ToString() => Lng.Elem("Saber");
    }
}