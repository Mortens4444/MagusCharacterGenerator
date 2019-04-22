using MagusCharacterGenerator.GameSystem.Attributes;
using MagusCharacterGenerator.GameSystem.Valuables;
using MagusCharacterGenerator.GameSystem.Weapons;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Weapons.OtherWeapons
{
    class Fist : Weapon, IMeleeWeapon
    {
        public double AttacksPerRound => 2;

        public byte InitiatingValue => 10;

        public byte AttackingValue => 4;

        public byte DefendingValue => 1;

        public double Weight => 0;

        public Money Price => null;

		[DiceThrow(ThrowType._1K2)]
		public byte GetDamage() => (byte)DiceThrow._1K2();

        public override string ToString() => Lng.Elem("Fist");
    }
}