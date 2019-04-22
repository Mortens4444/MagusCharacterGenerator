using MagusCharacterGenerator.GameSystem.Attributes;
using MagusCharacterGenerator.GameSystem.Valuables;
using MagusCharacterGenerator.GameSystem.Weapons;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Weapons.Spears
{
    class RidingLance : Weapon, IMeleeWeapon
    {
        public double AttacksPerRound => 1/2;

        public byte InitiatingValue => 1;

        public byte AttackingValue => 15;

        public byte DefendingValue => 0;

        public double Weight => 3.5;

        public Money Price => new Money(1);

		[DiceThrow(ThrowType._1K6)]
		public byte GetDamage() => (byte)(DiceThrow._1K6());

        public override string ToString() => Lng.Elem("Riding lance");
    }
}