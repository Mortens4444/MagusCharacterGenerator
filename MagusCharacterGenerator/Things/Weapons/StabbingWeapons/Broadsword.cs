using MagusCharacterGenerator.GameSystem.Attributes;
using MagusCharacterGenerator.GameSystem.Valuables;
using MagusCharacterGenerator.GameSystem.Weapons;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.StabbingWeapons
{
    class Broadsword : Weapon, IMeleeWeapon
    {
        public double AttacksPerRound => 1/2;

        public byte InitiatingValue => 0;

        public byte AttackingValue => 6;

        public byte DefendingValue => 2;

        public double Weight => 7;

        public Money Price => new Money(5);

		[DiceThrow(ThrowType._3K6)]
		[DiceThrowModifier(2)]
		public byte GetDamage() => (byte)(DiceThrow._3K6() + 2);

        public override string ToString() => Lng.Elem("Broadsword");
    }
}