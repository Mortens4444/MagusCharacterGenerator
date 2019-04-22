using MagusCharacterGenerator.GameSystem.Attributes;
using MagusCharacterGenerator.GameSystem.Valuables;
using MagusCharacterGenerator.GameSystem.Weapons;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.StabbingWeapons
{
    class BastardSword : Weapon, IMeleeWeapon
    {
        public double AttacksPerRound => 1;

        public byte InitiatingValue => 4;

        public byte AttackingValue => 13;

        public byte DefendingValue => 12;

        public double Weight => 2;

        public Money Price => new Money(2, 5);

		[DiceThrow(ThrowType._2K6)]
		public byte GetDamage() => (byte)DiceThrow._2K6();

        public override string ToString() => Lng.Elem("Bastard sword");
    }
}