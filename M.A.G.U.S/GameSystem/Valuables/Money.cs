namespace M.A.G.U.S.GameSystem.Valuables;

public class Money : IComparable<Money>, IEquatable<Money>
{
    public const decimal CopperPerSilver = 100;
    public const decimal CopperPerGold = 1000;
    public const decimal CopperPerMithril = 100000;

    public static readonly Money Free = new(0);


    public Money(decimal gold = 0, decimal silver = 0, decimal copper = 0, decimal mithril = 0)
    {
        Mithril = mithril;
        Gold = gold;
        Silver = silver;
        Copper = copper;
    }

    private Money(decimal totalCopper)
    {
        Mithril = Math.Floor(totalCopper / CopperPerMithril);
        totalCopper %= CopperPerMithril;

        Gold = Math.Floor(totalCopper / CopperPerGold);
        totalCopper %= CopperPerGold;

        Silver = Math.Floor(totalCopper / CopperPerSilver);
        Copper = totalCopper % CopperPerSilver;
    }

    public static Money DoubleIt(Money money) => money + money;

    public decimal Mithril { get; set; }
    
    public decimal Gold { get; set; }
    
    public decimal Silver { get; set; }
    
    public decimal Copper { get; set; }

    public decimal Summa => Mithril * CopperPerMithril + Gold * CopperPerGold + Silver * CopperPerSilver + Copper;

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

    public override string ToString() => $"{Mithril}m {Gold}g {Silver}s {Copper}c";

    public static Money operator +(Money a, Money b)
    {
        if (a == null) throw new ArgumentNullException(nameof(a));
        if (b == null) throw new ArgumentNullException(nameof(b));

        return FromCopper(a.Summa + b.Summa);
    }

    public static Money operator -(Money a, Money b)
    {
        if (a == null) throw new ArgumentNullException(nameof(a));
        if (b == null) throw new ArgumentNullException(nameof(b));

        if (a.Summa < b.Summa)
            throw new InvalidOperationException("Insufficient funds.");

        return FromCopper(a.Summa - b.Summa);
    }

    private static Money FromCopper(decimal copperTotal)
    {
        return new Money(copperTotal);
    }
}
