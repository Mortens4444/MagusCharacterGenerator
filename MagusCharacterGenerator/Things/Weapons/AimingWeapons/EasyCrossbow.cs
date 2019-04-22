using MagusCharacterGenerator.GameSystem.Attributes;
using MagusCharacterGenerator.GameSystem.Valuables;
using MagusCharacterGenerator.GameSystem.Weapons;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Weapons.AimingWeapons
{
    class EasyCrossbow : Weapon, IRangedWeapon
    {
        public double AttacksPerRound => 1;

        public byte InitiatingValue => 2;

        public byte AimingValue => 16;

        public ushort Distance => 50;

        public double Weight => 3.5;

        public Money Price => new Money(8);

		[DiceThrow(ThrowType._1K6)]
		[DiceThrowModifier(1)]
		public byte GetDamage() => (byte)(DiceThrow._1K6_RangedAttack() + 1);

        public override string ToString() => Lng.Elem("Easy crossbow");
    }
}