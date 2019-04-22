using MagusCharacterGenerator.GameSystem.Attributes;
using MagusCharacterGenerator.GameSystem.Valuables;
using MagusCharacterGenerator.GameSystem.Weapons;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.StabbingWeapons
{
    class OneHandedHatchet : Weapon, IMeleeWeapon
    {
        public double AttacksPerRound => 1;

        public byte InitiatingValue => 5;

        public byte AttackingValue => 12;

        public byte DefendingValue => 11;

        public double Weight => 2;

        public Money Price => new Money(0, 6);

		[DiceThrow(ThrowType._1K10)]
		public byte GetDamage() => (byte)DiceThrow._1K10();

        public override string ToString() => Lng.Elem("One-handed hatchet");
    }
}