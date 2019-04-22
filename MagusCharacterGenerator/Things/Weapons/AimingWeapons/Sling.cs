using MagusCharacterGenerator.GameSystem.Attributes;
using MagusCharacterGenerator.GameSystem.Valuables;
using MagusCharacterGenerator.GameSystem.Weapons;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Weapons.AimingWeapons
{
    class Sling : Weapon, IRangedWeapon
    {
        public double AttacksPerRound => 2;

        public byte InitiatingValue => 2;

        public byte AimingValue => 1;

        public ushort Distance => 100;

        public double Weight => 0.1;

        public Money Price => new Money(0, 0, 30);

		[DiceThrow(ThrowType._1K5)]
		public byte GetDamage() => (byte)DiceThrow._1K5_RangedAttack();

        public override string ToString() => Lng.Elem("Sling");
    }
}