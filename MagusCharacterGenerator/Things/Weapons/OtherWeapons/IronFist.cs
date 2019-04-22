using MagusCharacterGenerator.GameSystem.Attributes;
using MagusCharacterGenerator.GameSystem.Valuables;
using MagusCharacterGenerator.GameSystem.Weapons;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Weapons.OtherWeapons
{
    class IronFist : Weapon, IMeleeWeapon
    {
        public double AttacksPerRound => 2;

        public byte InitiatingValue => 9;

        public byte AttackingValue => 5;

        public byte DefendingValue => 2;

        public double Weight => 0.2;

        public Money Price => new Money(0, 1);

		[DiceThrow(ThrowType._1K3)]
		public byte GetDamage() => (byte)DiceThrow._1K3();

        public override string ToString() => Lng.Elem("IronFist");
    }
}