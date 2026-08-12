namespace MAGUS.Qualifications.Specialities;

public sealed class ChitinExoskeleton(int armorClass) : NaturalArmor(armorClass)
{
    public override string Name => "Chitin exoskeleton";
}