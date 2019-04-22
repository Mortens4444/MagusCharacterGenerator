using MagusCharacterGenerator.GameSystem.Attributes;
using MagusCharacterGenerator.GameSystem.Valuables;
using MagusCharacterGenerator.GameSystem.Weapons;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.StabbingWeapons
{
    class ThrowingDagger : Weapon, IMeleeWeapon
    {
        public double AttacksPerRound => 2;

        public byte InitiatingValue => 10;

        public byte AttackingValue => 11;

        public byte DefendingValue => 2;

        public double Weight => 0.5;

        public Money Price => new Money(0, 1, 50);

		[DiceThrow(ThrowType._1K6)]
		public byte GetDamage() => (byte)DiceThrow._1K6();

        public override string ToString() => Lng.Elem("Throwing dagger");
    }
}