namespace M.A.G.U.S.GameSystem.Valuables;

public class Money(decimal gold, decimal silver = 0, decimal copper = 0) : IComparable<Money>, IEquatable<Money>
{
    private const decimal CopperPerSilver = 100;
    private const decimal CopperPerGold = 1000;
    private const decimal CopperPerMithrill = 100000;

    public static readonly Money Free = new(0);

    public decimal Mithrill { get; set; }
    
    public decimal Gold { get; set; } = gold;
    
    public decimal Silver { get; set; } = silver;
    
    public decimal Copper { get; set; } = copper;

    public decimal Summa => Mithrill * CopperPerMithrill + Gold * CopperPerGold + Silver * CopperPerSilver + Copper;

    public int CompareTo(Money other)
    {
        if (ReferenceEquals(other, null))
        {
            return 1;
        }

        return Summa.CompareTo(other.Summa);
    }

    public int CompareTo(ulong copperAmount) => Summa.CompareTo(copperAmount);

    public bool IsAtLeast(ulong copperAmount) => Summa >= copperAmount;

    public override bool Equals(object obj) => Equals(obj as Money);
    public bool Equals(Money other) => other is not null && Summa == other.Summa;
    public override int GetHashCode() => Summa.GetHashCode();

    public static bool operator ==(Money a, Money b) => ReferenceEquals(a, b) || (!ReferenceEquals(a, null) && !ReferenceEquals(b, null) && a.Summa == b.Summa);
    
    public static bool operator !=(Money a, Money b) => !(a == b);

    public static bool operator <(Money a, Money b) => a is not null && b is not null && a.Summa < b.Summa;
    
    public static bool operator >(Money a, Money b) => a is not null && b is not null && a.Summa > b.Summa;
    
    public static bool operator <=(Money a, Money b) => ReferenceEquals(a, b) || (a is not null && b is not null && a.Summa <= b.Summa);
    
    public static bool operator >=(Money a, Money b) => ReferenceEquals(a, b) || (a is not null && b is not null && a.Summa >= b.Summa);

    public override string ToString() => $"{Mithrill}m {Gold}g {Silver}s {Copper}c";
}
