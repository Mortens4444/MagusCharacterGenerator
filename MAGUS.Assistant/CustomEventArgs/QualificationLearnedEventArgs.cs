using MAGUS.GameSystem.Qualifications;

namespace MAGUS.Assistant.CustomEventArgs;

internal sealed class QualificationLearnedEventArgs(Qualification qualification, QualificationLevel qualificationLevel) : EventArgs
{
    public Qualification Qualification { get; } = qualification ?? throw new ArgumentNullException(nameof(qualification));

    public QualificationLevel QualificationLevel { get; } = qualificationLevel;
}
