using MagusCharacterGenerator.GameSystem.Attributes;
using MagusCharacterGenerator.GameSystem.Valuables;
using MagusCharacterGenerator.GameSystem.Weapons;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Weapons.AimingWeapons
{
    class LongBow : Weapon, IRangedWeapon
    {
        public double AttacksPerRound => 2;

        public byte InitiatingValue => 4;

        public byte AimingValue => 6;

        public ushort Distance => 110;

        public double Weight => 0.7;

        public Money Price => new Money(3, 5);

		[DiceThrow(ThrowType._1K6)]
		[DiceThrowModifier(1)]
		public byte GetDamage() => (byte)(DiceThrow._1K6_RangedAttack() + 1);

        public override string ToString() => Lng.Elem("Long bow");
    }
}