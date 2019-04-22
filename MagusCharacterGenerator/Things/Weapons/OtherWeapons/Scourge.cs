using MagusCharacterGenerator.GameSystem.Attributes;
using MagusCharacterGenerator.GameSystem.Valuables;
using MagusCharacterGenerator.GameSystem.Weapons;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Weapons.OtherWeapons
{
    class Scourge : Weapon, IMeleeWeapon
    {
        public double AttacksPerRound => 2;

        public byte InitiatingValue => 4;

        public byte AttackingValue => 6;

        public byte DefendingValue => 0;

        public double Weight => 0.5;

        public Money Price => new Money(0, 1, 20);

		[DiceThrow(ThrowType._1K3)]
		public byte GetDamage() => (byte)DiceThrow._1K3();

        public override string ToString() => Lng.Elem("Scourge");
    }
}