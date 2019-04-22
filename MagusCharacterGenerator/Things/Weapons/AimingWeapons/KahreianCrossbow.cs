using MagusCharacterGenerator.GameSystem.Attributes;
using MagusCharacterGenerator.GameSystem.Valuables;
using MagusCharacterGenerator.GameSystem.Weapons;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Weapons.AimingWeapons
{
    class KahreianCrossbow : Weapon, IRangedWeapon
    {
        public double AttacksPerRound => 3;

        public byte InitiatingValue => 9;

        public byte AimingValue => 13;

        public ushort Distance => 30;

        public double Weight => 3;

        public Money Price => new Money(80);

		[DiceThrow(ThrowType._1K3)]
		public byte GetDamage() => (byte)DiceThrow._1K3_RangedAttack();

        public override string ToString() => Lng.Elem("Kahreian crossbow");
    }
}