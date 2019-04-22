using MagusCharacterGenerator.Castes;
using MagusCharacterGenerator.GameSystem.Attributes;
using MagusCharacterGenerator.GameSystem.Valuables;
using MagusCharacterGenerator.GameSystem.Weapons;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Weapons.Spears
{
    class Javelin : Weapon, IMeleeWeapon
    {
        public double AttacksPerRound => 1;

        public byte InitiatingValue => 8;

        public byte AttackingValue => 13;

        public byte DefendingValue => 5;

        public double Weight => 1.5;

        public Money Price => new Money(0, 5);

		[DiceThrow(ThrowType._1K6)]
		[DiceThrowModifier(1)]
		public byte GetDamage() => (byte)(DiceThrow._1K6() + 1);

        public override string ToString() => Lng.Elem("Javelin");
    }
}