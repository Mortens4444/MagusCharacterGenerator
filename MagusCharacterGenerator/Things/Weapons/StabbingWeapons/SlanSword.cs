using MagusCharacterGenerator.GameSystem.Attributes;
using MagusCharacterGenerator.GameSystem.Valuables;
using MagusCharacterGenerator.GameSystem.Weapons;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.StabbingWeapons
{
    class SlanSword : Weapon, IMeleeWeapon
    {
        public double AttacksPerRound => 1;

        public byte InitiatingValue => 8;

        public byte AttackingValue => 20;

        public byte DefendingValue => 12;

        public double Weight => 1.4;

        public Money Price => new Money(100);

		[DiceThrow(ThrowType._1K10)]
		public byte GetDamage() => (byte)(DiceThrow._1K10() + 2);

        public override string ToString() => Lng.Elem("Slan sword");
    }
}