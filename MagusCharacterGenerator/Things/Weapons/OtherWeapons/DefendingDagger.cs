using MagusCharacterGenerator.GameSystem.Attributes;
using MagusCharacterGenerator.GameSystem.Valuables;
using MagusCharacterGenerator.GameSystem.Weapons;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Weapons.OtherWeapons
{
    class DefendingDagger : Weapon, IMeleeWeapon
    {
        public double AttacksPerRound => 2;

        public byte InitiatingValue => 8;

        public byte AttackingValue => 4;

        public byte DefendingValue => 19;

        public double Weight => 0.3;

        public Money Price => new Money(0, 2);

		[DiceThrow(ThrowType._1K6)]
		public byte GetDamage() => (byte)DiceThrow._1K6();

        public override string ToString() => Lng.Elem("Defending dagger");
    }
}