using M.A.G.U.S.GameSystem.Valuables;
using M.A.G.U.S.Interfaces;

namespace M.A.G.U.S.Things.Armors;

public class AquirianBattleArmor : Armor, INotForSale
{
    public override string Name => "Aquirian battle armor";

    public override Money Price => new(1000, 0, 0);

    public override int ArmorClass => 10;

    public override double Weight => 20;

    public override string Description => "The Typical Aquir Battle Armor is a masterpiece constructed from complex metal plates and segments with a cold sheen. If worn by a Trueblood, its Armor Class (AC) is 10, and the creature can only be wounded through it by a critical hit (over-penetration). It behaves like a second skin; the gaps created in it close quickly, regenerating 2 Hit Points per round, meaning it is capable of protecting the Aquir from bleeding out. If anyone else attempts to wear the armor, they must make a Health and Willpower test every day. If the Health test fails, the individual loses 1 Health Point (Hp), which can only be recovered via a Healing spell. If the Willpower test fails, the wearer is seized by an inexplicable horror, reducing their combat and other attributes by 50%. If both tests fail during the day, the armor triumphs: it leaches the individual's personality, which is lost forever, and a wandering soul takes its place within the body and armor, thereafter seeking the lives of any potential companions to the best of its ability.";
}
