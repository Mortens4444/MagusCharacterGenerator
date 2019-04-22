using MagusCharacterGenerator.GameSystem.Attributes;
using MagusCharacterGenerator.GameSystem.Valuables;
using MagusCharacterGenerator.GameSystem.Weapons;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Weapons.AimingWeapons
{
    class HandCrossbow : Weapon, IRangedWeapon
    {
        public double AttacksPerRound => 2;

        public byte InitiatingValue => 3;

        public byte AimingValue => 14;

        public ushort Distance => 30;

        public double Weight => 2;

        public Money Price => new Money(20);

		[DiceThrow(ThrowType._1K3)]
		public byte GetDamage() => (byte)DiceThrow._1K3_RangedAttack();

        public override string ToString() => Lng.Elem("Hand crossbow");
    }
}