using MagusCharacterGenerator.GameSystem.Attributes;
using MagusCharacterGenerator.GameSystem.Valuables;
using MagusCharacterGenerator.GameSystem.Weapons;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Weapons.Spears
{
    class Harpoon : Weapon, IMeleeWeapon
    {
        public double AttacksPerRound => 1;

        public byte InitiatingValue => 4;

        public byte AttackingValue => 15;

        public byte DefendingValue => 10;

        public double Weight => 2;

        public Money Price => new Money(0, 5);

		[DiceThrow(ThrowType._1K10)]
		[DiceThrowModifier(1)]
		public byte GetDamage() => (byte)(DiceThrow._1K10() + 1);

        public override string ToString() => Lng.Elem("Harpoon");
    }
}