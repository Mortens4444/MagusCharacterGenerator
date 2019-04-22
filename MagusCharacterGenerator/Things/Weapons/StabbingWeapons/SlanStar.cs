using MagusCharacterGenerator.GameSystem.Attributes;
using MagusCharacterGenerator.GameSystem.Valuables;
using MagusCharacterGenerator.GameSystem.Weapons;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.StabbingWeapons
{
    class SlanStar : Weapon, IMeleeWeapon
    {
        public double AttacksPerRound => 3;

        public byte InitiatingValue => 10;

        public byte AttackingValue => 4;

        public byte DefendingValue => 4;

        public double Weight => 0.1;

        public Money Price => new Money(0, 0, 40);

		[DiceThrow(ThrowType._1K3)]
		public byte GetDamage() => (byte)DiceThrow._1K3();

        public override string ToString() => Lng.Elem("Slan star");
    }
}