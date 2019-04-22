using MagusCharacterGenerator.GameSystem.Attributes;
using MagusCharacterGenerator.GameSystem.Valuables;
using MagusCharacterGenerator.GameSystem.Weapons;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.StabbingWeapons
{
    class BattleAx : Weapon, IMeleeWeapon
    {
        public double AttacksPerRound => 1;

        public byte InitiatingValue => 5;

        public byte AttackingValue => 11;

        public byte DefendingValue => 8;

        public double Weight => 2.5;

        public Money Price => new Money(0, 8);

		[DiceThrow(ThrowType._1K10)]
		public byte GetDamage() => (byte)DiceThrow._1K10();

        public override string ToString() => Lng.Elem("Battle ax");
    }
}