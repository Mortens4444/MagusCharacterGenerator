using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Specialities;

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