using MagusCharacterGenerator.GameSystem.Attributes;
using MagusCharacterGenerator.GameSystem.Valuables;
using MagusCharacterGenerator.GameSystem.Weapons;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Weapons.AimingWeapons
{
    class AquirianCrossbow : Weapon, IRangedWeapon
    {
        public double AttacksPerRound => 2;

        public byte InitiatingValue => 5;

        public byte AimingValue => 18;

        public ushort Distance => 35;

        public double Weight => 2;

        public Money Price => new Money(1000);

		[DiceThrow(ThrowType._1K5)]
		public byte GetDamage() => (byte)DiceThrow._1K5_RangedAttack();

        public override string ToString() => Lng.Elem("Aquirian crossbow");
    }
}