using MagusCharacterGenerator.GameSystem.Attributes;
using MagusCharacterGenerator.GameSystem.Valuables;
using MagusCharacterGenerator.GameSystem.Weapons;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Weapons.AimingWeapons
{
    class HeavyCrossbow : Weapon, IRangedWeapon
    {
        public double AttacksPerRound => 1/3;

        public byte InitiatingValue => 0;

        public byte AimingValue => 15;

        public ushort Distance => 60;

        public double Weight => 6;

        public Money Price => new Money(12);

		[DiceThrow(ThrowType._1K10)]
		[DiceThrowModifier(2)]
		public byte GetDamage() => (byte)(DiceThrow._1K10_RangedAttack() + 2);

        public override string ToString() => Lng.Elem("Heavy crossbow");
    }
}