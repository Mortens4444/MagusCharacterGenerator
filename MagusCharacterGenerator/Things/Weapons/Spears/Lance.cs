using MagusCharacterGenerator.GameSystem.Attributes;
using MagusCharacterGenerator.GameSystem.Valuables;
using MagusCharacterGenerator.GameSystem.Weapons;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Weapons.Spears
{
    class Lance : Weapon, IMeleeWeapon
    {
        public double AttacksPerRound => 1;

        public byte InitiatingValue => 2;

        public byte AttackingValue => 11;

        public byte DefendingValue => 12;

        public double Weight => 2;

        public Money Price => new Money(0, 9);

		[DiceThrow(ThrowType._1K10)]
		public byte GetDamage() => (byte)(DiceThrow._1K10());

        public override string ToString() => Lng.Elem("Lance");
    }
}