using M.A.G.U.S.Enums;

namespace M.A.G.U.S.GameSystem;

public abstract class Attack(string name, int value, Func<int> getDamageCallback)
{
    public string Name { get; set; } = name;

    public int Value { get; set; } = value;

    public Func<int> GetDamage { get; set; } = getDamageCallback;

    public (AttackImpact impact, int value) GetAttack()
    {
        var diceThrow = new DiceThrow();
        var roll = diceThrow._1D100();
        var impact = roll == 100 ? AttackImpact.Critical : roll == 1 ? AttackImpact.Fatal : AttackImpact.Normal;
        return (impact, Value + roll);
    }
}
