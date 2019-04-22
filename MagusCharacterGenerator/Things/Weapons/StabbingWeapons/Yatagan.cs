using MagusCharacterGenerator.GameSystem.Attributes;
using MagusCharacterGenerator.GameSystem.Valuables;
using MagusCharacterGenerator.GameSystem.Weapons;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.StabbingWeapons
{
    class Yatagan : Weapon, IMeleeWeapon
    {
        public double AttacksPerRound => 1;

        public byte InitiatingValue => 7;

        public byte AttackingValue => 14;

        public byte DefendingValue => 14;

        public double Weight => 0.8;

        public Money Price => new Money(1, 4);

		[DiceThrow(ThrowType._1K6)]
		[DiceThrowModifier(2)]
		public byte GetDamage() => (byte)(DiceThrow._1K6() + 2);

        public override string ToString() => Lng.Elem("Yatagan");
    }
}