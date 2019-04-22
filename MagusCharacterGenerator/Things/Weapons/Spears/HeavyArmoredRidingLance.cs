using MagusCharacterGenerator.GameSystem.Valuables;
using MagusCharacterGenerator.GameSystem.Weapons;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Weapons.Spears
{
    class HeavyArmoredRidingLance : Weapon, IMeleeWeapon
    {
        public double AttacksPerRound => 1/3;

        public byte InitiatingValue => 0;

        public byte AttackingValue => 16;

        public byte DefendingValue => 0;

        public double Weight => 5;

        public Money Price => new Money(1, 5);

        public byte GetDamage() => (byte)(DiceThrow._2K10());

        public override string ToString() => Lng.Elem("Heavy armored riding lance");
    }
}