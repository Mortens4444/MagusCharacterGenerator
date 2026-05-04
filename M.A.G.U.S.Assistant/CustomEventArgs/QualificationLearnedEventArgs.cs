using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Assistant.CustomEventArgs;

internal class QualificationLearnedEventArgs(Qualification qualification, QualificationLevel qualificationLevel) : EventArgs
{
    public Qualification Qualification { get; } = qualification ?? throw new ArgumentNullException(nameof(qualification));

    public QualificationLevel QualificationLevel { get; } = qualificationLevel;
}
