using MagusCharacterGenerator.GameSystem.Attributes;
using MagusCharacterGenerator.GameSystem.Valuables;
using MagusCharacterGenerator.GameSystem.Weapons;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.StabbingWeapons
{
    class Longsword : Weapon, IMeleeWeapon
    {
        public double AttacksPerRound => 1;

        public byte InitiatingValue => 6;

        public byte AttackingValue => 14;

        public byte DefendingValue => 16;

        public double Weight => 1.5;

        public Money Price => new Money(1, 5);

		[DiceThrow(ThrowType._1K10)]
		public byte GetDamage() => (byte)DiceThrow._1K10();

        public override string ToString() => Lng.Elem("Longsword");
    }
}