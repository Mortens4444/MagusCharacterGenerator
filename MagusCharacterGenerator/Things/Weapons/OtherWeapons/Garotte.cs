using MagusCharacterGenerator.GameSystem.Attributes;
using MagusCharacterGenerator.GameSystem.Valuables;
using MagusCharacterGenerator.GameSystem.Weapons;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Weapons.OtherWeapons
{
    class Garotte : Weapon, IMeleeWeapon
    {
        public double AttacksPerRound => 1;

        public byte InitiatingValue => 0;

        public byte AttackingValue => 5;

        public byte DefendingValue => 0;//-20;

        public double Weight => 0.1;

        public Money Price => new Money(0, 1);

		[DiceThrow(ThrowType._1K10)]
		public byte GetDamage() => (byte)DiceThrow._1K10();

        public override string ToString() => Lng.Elem("Garotte");
    }
}