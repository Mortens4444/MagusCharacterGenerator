using MagusCharacterGenerator.GameSystem.Attributes;
using MagusCharacterGenerator.GameSystem.Valuables;
using MagusCharacterGenerator.GameSystem.Weapons;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Weapons.OtherWeapons
{
    class Bola : Weapon, IMeleeWeapon
    {
        public double AttacksPerRound => 1;

        public byte InitiatingValue => 2;

        public byte AttackingValue => 10;

        public byte DefendingValue => 2;

        public double Weight => 0.8;

        public Money Price => new Money(0, 0, 40);

		[DiceThrow(ThrowType._1K5)]
		[DiceThrowModifier(1)]
		public byte GetDamage() => (byte)(DiceThrow._1K5() + 1);

        public override string ToString() => Lng.Elem("Bola");
    }
}