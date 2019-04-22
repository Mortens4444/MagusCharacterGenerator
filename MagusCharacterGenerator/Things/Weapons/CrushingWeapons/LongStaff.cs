using MagusCharacterGenerator.GameSystem.Attributes;
using MagusCharacterGenerator.GameSystem.Valuables;
using MagusCharacterGenerator.GameSystem.Weapons;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Weapons.CrushingWeapons
{
    class LongStaff : Weapon, IMeleeWeapon
    {
        public double AttacksPerRound => 1;

        public byte InitiatingValue => 4;

        public byte AttackingValue => 10;

        public byte DefendingValue => 16;

        public double Weight => 1.2;

        public Money Price => new Money(0, 0, 50);

		[DiceThrow(ThrowType._1K5)]
		public byte GetDamage() => (byte)DiceThrow._1K5();

        public override string ToString() => Lng.Elem("Long staff");
    }
}