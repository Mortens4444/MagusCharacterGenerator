using MagusCharacterGenerator.GameSystem.Attributes;
using MagusCharacterGenerator.GameSystem.Valuables;
using MagusCharacterGenerator.GameSystem.Weapons;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.StabbingWeapons
{
    class ThrowingAx : Weapon, IMeleeWeapon
    {
        public double AttacksPerRound => 2;

        public byte InitiatingValue => 9;

        public byte AttackingValue => 10;

        public byte DefendingValue => 4;

        public double Weight => 1.2;

        public Money Price => new Money(0, 1);

		[DiceThrow(ThrowType._1K6)]
		public byte GetDamage() => (byte)DiceThrow._1K6();

        public override string ToString() => Lng.Elem("Throwing ax");
    }
}