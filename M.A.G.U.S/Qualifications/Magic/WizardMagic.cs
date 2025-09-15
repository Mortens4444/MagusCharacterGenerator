using M.A.G.U.S.GameSystem.Magic;

namespace M.A.G.U.S.Qualifications.Magic;

public class WizardMagic : Sorcery
{
    public WizardMagic()
    {
        ManaPoints = 10;
    }

    public override string Name => "Wizard magic";
}
