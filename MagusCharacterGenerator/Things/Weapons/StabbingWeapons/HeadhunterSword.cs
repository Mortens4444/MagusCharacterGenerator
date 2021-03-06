﻿using MagusCharacterGenerator.GameSystem.Attributes;
using MagusCharacterGenerator.GameSystem.Valuables;
using MagusCharacterGenerator.GameSystem.Weapons;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.StabbingWeapons
{
    class HeadhunterSword : Weapon, IMeleeWeapon
    {
        public double AttacksPerRound => 1;

        public byte InitiatingValue => 8;

        public byte AttackingValue => 16;

        public byte DefendingValue => 16;

        public double Weight => 0.8;

        public Money Price => new Money(2);

		[DiceThrow(ThrowType._1K6)]
		[DiceThrowModifier(2)]
		public byte GetDamage() => (byte)(DiceThrow._1K6() + 2);

        public override string ToString() => Lng.Elem("Headhunter sword");
    }
}