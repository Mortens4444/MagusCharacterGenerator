using MagusCharacterGenerator.GameSystem.Attributes;
using MagusCharacterGenerator.GameSystem.Valuables;
using MagusCharacterGenerator.GameSystem.Weapons;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Weapons.StabbingWeapons
{
    class ShortSword : Weapon, IMeleeWeapon
    {
        public double AttacksPerRound => 1;

        public byte InitiatingValue => 9;

        public byte AttackingValue => 12;

        public byte DefendingValue => 14;

        public double Weight => 1;

        public Money Price => new Money(1);

		[DiceThrow(ThrowType._1K6)]
		[DiceThrowModifier(1)]
		public byte GetDamage() => (byte)(DiceThrow._1K6() + 1);

        public override string ToString() => Lng.Elem("Short sword");
    }
}