using MagusCharacterGenerator.GameSystem.Attributes;
using MagusCharacterGenerator.GameSystem.Valuables;
using MagusCharacterGenerator.GameSystem.Weapons;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Weapons.CrushingWeapons
{
    class Shortstaff : Weapon, IMeleeWeapon
    {
        public double AttacksPerRound => 1;

        public byte InitiatingValue => 9;

        public byte AttackingValue => 9;

        public byte DefendingValue => 17;

        public double Weight => 0.7;

        public Money Price => new Money(0, 0, 30);

		[DiceThrow(ThrowType._1K3)]
		public byte GetDamage() => (byte)DiceThrow._1K3();

        public override string ToString() => Lng.Elem("Short staff");
    }
}