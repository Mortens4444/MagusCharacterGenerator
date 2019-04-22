using MagusCharacterGenerator.GameSystem.Attributes;
using MagusCharacterGenerator.GameSystem.Valuables;
using MagusCharacterGenerator.GameSystem.Weapons;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Weapons.Spears
{
    class Halberd : Weapon, IMeleeWeapon
    {
        public double AttacksPerRound =>  1/2;

        public byte InitiatingValue => 1;

        public byte AttackingValue => 14;

        public byte DefendingValue => 15;

        public double Weight => 3;

        public Money Price => new Money(5);

		[DiceThrow(ThrowType._2K6)]
		[DiceThrowModifier(2)]
		public byte GetDamage() => (byte)(DiceThrow._2K6() + 2);

        public override string ToString() => Lng.Elem("Halberd");
    }
}