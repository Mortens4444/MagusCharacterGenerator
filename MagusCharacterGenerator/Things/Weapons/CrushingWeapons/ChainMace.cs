using MagusCharacterGenerator.GameSystem.Attributes;
using MagusCharacterGenerator.GameSystem.Valuables;
using MagusCharacterGenerator.GameSystem.Weapons;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Weapons.CrushingWeapons
{
    class ChainMace : Weapon, IMeleeWeapon
    {
        public double AttacksPerRound => 1;

        public byte InitiatingValue => 4;

        public byte AttackingValue => 13;

        public byte DefendingValue => 11;

        public double Weight => 2;

        public Money Price => new Money(1, 2);

		[DiceThrow(ThrowType._1K6)]
		[DiceThrowModifier(3)]
		public byte GetDamage() => (byte)(DiceThrow._1K6() + 3);

        public override string ToString() => Lng.Elem("Chain mace");
    }
}