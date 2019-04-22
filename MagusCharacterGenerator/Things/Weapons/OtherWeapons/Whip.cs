using MagusCharacterGenerator.GameSystem.Attributes;
using MagusCharacterGenerator.GameSystem.Valuables;
using MagusCharacterGenerator.GameSystem.Weapons;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Weapons.OtherWeapons
{
    class Whip : Weapon, IMeleeWeapon
    {
        public double AttacksPerRound => 2;

        public byte InitiatingValue => 3;

        public byte AttackingValue => 6;

        public byte DefendingValue => 0;

        public double Weight => 0.6;

        public Money Price => new Money(0, 1);

		[DiceThrow(ThrowType._1K2)]
		public byte GetDamage() => (byte)DiceThrow._1K2();

        public override string ToString() => Lng.Elem("Whip");
    }
}