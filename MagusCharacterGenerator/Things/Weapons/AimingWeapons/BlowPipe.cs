using MagusCharacterGenerator.GameSystem.Attributes;
using MagusCharacterGenerator.GameSystem.Valuables;
using MagusCharacterGenerator.GameSystem.Weapons;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Weapons.AimingWeapons
{
    class BlowPipe : Weapon, IRangedWeapon
    {
        public double AttacksPerRound => 3;

        public byte InitiatingValue => 8;

        public byte AimingValue => 7;

        public ushort Distance => 30;

        public double Weight => 0.2;

        public Money Price => new Money(0, 6);

		[DiceThrow(ThrowType._1K1)]
		public byte GetDamage()
        {
            if (DiceThrow._1K6() == 6)
            {
                return 1;
            }
            return 0;
        }

        public override string ToString() => Lng.Elem("Blow pipe");
    }
}