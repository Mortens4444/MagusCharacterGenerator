using MagusCharacterGenerator.GameSystem.Attributes;
using MagusCharacterGenerator.GameSystem.Valuables;
using MagusCharacterGenerator.GameSystem.Weapons;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.StabbingWeapons
{
    class JannSaber : Weapon, IMeleeWeapon
    {
        public double AttacksPerRound => 1;

        public byte InitiatingValue => 9;

        public byte AttackingValue => 20;

        public byte DefendingValue => 17;

        public double Weight => 120;

        public Money Price => new Money(0, 5);

		[DiceThrow(ThrowType._1K6)]
		[DiceThrowModifier(3)]
		public byte GetDamage() => (byte)(DiceThrow._1K6() + 3);

        public override string ToString() => Lng.Elem("Jann saber");
    }
}