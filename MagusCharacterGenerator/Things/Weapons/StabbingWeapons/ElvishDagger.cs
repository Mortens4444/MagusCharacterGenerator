using MagusCharacterGenerator.GameSystem.Attributes;
using MagusCharacterGenerator.GameSystem.Valuables;
using MagusCharacterGenerator.GameSystem.Weapons;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.StabbingWeapons
{
    class ElvishDagger : Weapon, IMeleeWeapon
    {
        public double AttacksPerRound => 2;

        public byte InitiatingValue => 9;

        public byte AttackingValue => 9;

        public byte DefendingValue => 2;

        public double Weight => 0.2;

        public Money Price => new Money(5);

		[DiceThrow(ThrowType._1K6)]
		[DiceThrowModifier(1)]
		public byte GetDamage() => (byte)(DiceThrow._1K6() + 1);

        public override string ToString() => Lng.Elem("Elvish dagger");
    }
}