namespace M.A.G.U.S.GameSystem.Psi;

public class PsiEvent
{
    public byte Level { get; set; }

    public byte Modifier { get; set; }

    public IPsi SourceSkill { get; set; }
}
