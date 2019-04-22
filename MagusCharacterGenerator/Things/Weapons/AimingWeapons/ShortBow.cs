using MagusCharacterGenerator.GameSystem.Attributes;
using MagusCharacterGenerator.GameSystem.Valuables;
using MagusCharacterGenerator.GameSystem.Weapons;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Weapons.AimingWeapons
{
    class ShortBow : Weapon, IRangedWeapon
    {
        public double AttacksPerRound => 2;

        public byte InitiatingValue => 5;

        public byte AimingValue => 4;

        public ushort Distance => 90;

        public double Weight => 0.6;

        public Money Price => new Money(3);

		[DiceThrow(ThrowType._1K6)]
		public byte GetDamage() => (byte)DiceThrow._1K6_RangedAttack();

        public override string ToString() => Lng.Elem("Short bow");
    }
}