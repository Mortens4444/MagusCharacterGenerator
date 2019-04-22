using MagusCharacterGenerator.GameSystem.Attributes;
using MagusCharacterGenerator.GameSystem.Valuables;
using MagusCharacterGenerator.GameSystem.Weapons;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.StabbingWeapons
{
    class MaraSequor : Weapon, IMeleeWeapon
    {
        public double AttacksPerRound => 1;

        public byte InitiatingValue => 7;

        public byte AttackingValue => 16;

        public byte DefendingValue => 14;

        public double Weight => 1;

        public Money Price => new Money(2);

		[DiceThrow(ThrowType._2K6)]
		[DiceThrowModifier(2)]
		public byte GetDamage() => (byte)(DiceThrow._2K6() + 2);

        public override string ToString() => Lng.Elem("Mara-sequor");
    }
}