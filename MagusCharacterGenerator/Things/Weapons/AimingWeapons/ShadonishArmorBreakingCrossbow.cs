using MagusCharacterGenerator.GameSystem.Valuables;
using MagusCharacterGenerator.GameSystem.Weapons;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Weapons.AimingWeapons
{
    class ShadonishArmorBreakingCrossbow : Weapon, IRangedWeapon
    {
        public double AttacksPerRound => 1/5;

        public byte InitiatingValue => 0;

        public byte AimingValue => 17;

        public ushort Distance => 80;

        public double Weight => 8;

        public Money Price => new Money(40);

        public byte GetDamage() => (byte)DiceThrow._2K10_RangedAttack();

        public override string ToString() => Lng.Elem("Shadonish armor breaking crossbow");
    }
}