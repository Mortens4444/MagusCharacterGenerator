using MagusCharacterGenerator.GameSystem.Attributes;
using MagusCharacterGenerator.GameSystem.Valuables;
using MagusCharacterGenerator.GameSystem.Weapons;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.StabbingWeapons
{
    class Knife : Weapon, IMeleeWeapon
    {
        public double AttacksPerRound => 2;

        public byte InitiatingValue => 10;

        public byte AttackingValue => 4;

        public byte DefendingValue => 0;

        public double Weight => 0.2;

        public Money Price => new Money(0, 0, 50);

		[DiceThrow(ThrowType._1K5)]
		public byte GetDamage() => (byte)DiceThrow._1K5();

        public override string ToString() => Lng.Elem("Knife");
    }
}