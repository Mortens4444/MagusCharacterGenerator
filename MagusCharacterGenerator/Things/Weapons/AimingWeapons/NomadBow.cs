using MagusCharacterGenerator.GameSystem.Attributes;
using MagusCharacterGenerator.GameSystem.Valuables;
using MagusCharacterGenerator.GameSystem.Weapons;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Weapons.AimingWeapons
{
    class NomadBow : Weapon, IRangedWeapon
    {
        public double AttacksPerRound => 2;

        public byte InitiatingValue => 3;

        public byte AimingValue => 8;

        public ushort Distance => 180;

        public double Weight => 0.7;

        public Money Price => new Money(25);

		[DiceThrow(ThrowType._1K10)]
		public byte GetDamage() => (byte)DiceThrow._1K10_RangedAttack();

        public override string ToString() => Lng.Elem("Nomad bow");
    }
}