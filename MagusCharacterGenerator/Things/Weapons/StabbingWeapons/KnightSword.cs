using MagusCharacterGenerator.GameSystem.Attributes;
using MagusCharacterGenerator.GameSystem.Valuables;
using MagusCharacterGenerator.GameSystem.Weapons;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.StabbingWeapons
{
    class KnightSword : Weapon, IMeleeWeapon
    {
        public double AttacksPerRound => 1;

        public byte InitiatingValue => 2;

        public byte AttackingValue => 10;

        public byte DefendingValue => 7;

        public double Weight => 3.5;

        public Money Price => new Money(3);

		[DiceThrow(ThrowType._2K6)]
		[DiceThrowModifier(6)]
		public byte GetDamage() => (byte)(DiceThrow._2K6() + 6);

        public override string ToString() => Lng.Elem("Knight sword");
    }
}