using MagusCharacterGenerator.GameSystem.Attributes;
using MagusCharacterGenerator.GameSystem.Valuables;
using MagusCharacterGenerator.GameSystem.Weapons;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Weapons.CrushingWeapons
{
    class Warhammer : Weapon, IMeleeWeapon
    {
        public double AttacksPerRound => 1;

        public byte InitiatingValue => 5;

        public byte AttackingValue => 10;

        public byte DefendingValue => 8;

        public double Weight => 3;

        public Money Price => new Money(0, 8);

		[DiceThrow(ThrowType._1K6)]
		[DiceThrowModifier(2)]
		public byte GetDamage() => (byte)(DiceThrow._1K6() + 2);

        public override string ToString() => Lng.Elem("Warhammer");
    }
}