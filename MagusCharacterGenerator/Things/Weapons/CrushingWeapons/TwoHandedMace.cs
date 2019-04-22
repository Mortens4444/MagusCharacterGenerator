using MagusCharacterGenerator.GameSystem.Attributes;
using MagusCharacterGenerator.GameSystem.Valuables;
using MagusCharacterGenerator.GameSystem.Weapons;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Weapons.CrushingWeapons
{
    class TwoHandedMace : Weapon, IMeleeWeapon
    {
        public double AttacksPerRound => 1/2;

        public byte InitiatingValue => 0;

        public byte AttackingValue => 7;

        public byte DefendingValue => 6;

        public double Weight => 3;

        public Money Price => new Money(1, 2);

		[DiceThrow(ThrowType._3K6)]
		public byte GetDamage() => (byte)DiceThrow._3K6();

        public override string ToString() => Lng.Elem("Two-handed mace");
    }
}