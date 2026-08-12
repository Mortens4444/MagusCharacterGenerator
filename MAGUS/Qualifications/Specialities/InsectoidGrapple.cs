using MAGUS.GameSystem.Qualifications;

namespace MAGUS.Qualifications.Specialities;

public sealed class InsectoidGrapple : SpecialQualification
{
    public override string Name => "Insectoid grapple";

    public int GrappleBonus { get; }

    public InsectoidGrapple(int grappleBonus = 20)
    {
        GrappleBonus = grappleBonus;
    }

    //public override string ToString() => $" (+{GrappleBonus} grapple)";
}