using MagusCharacterGenerator.GameSystem.Valuables;
using MagusCharacterGenerator.GameSystem.Weapons;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Weapons.OtherWeapons
{
    class ThrowingNets : Weapon, IMeleeWeapon
    {
        public double AttacksPerRound => 1/3;

        public byte InitiatingValue => 1;

        public byte AttackingValue => 8;

        public byte DefendingValue => 4;

        public double Weight => 1;

        public Money Price => new Money(0, 3);

        public byte GetDamage() => 0;

        public override string ToString() => Lng.Elem("Throwing nets");
    }
}