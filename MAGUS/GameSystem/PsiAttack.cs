using MAGUS.Interfaces;
using Newtonsoft.Json;

namespace MAGUS.GameSystem;

public sealed class PsiAttack : MysticAttack
{
    public IPsiDiscipline Discipline { get; init; }

    public int PsiPointCost => Discipline.PsiPointCost;

    [JsonConstructor]
    public PsiAttack() : base() { }

    public PsiAttack(IPsiDiscipline discipline)
        : base(discipline.Name, discipline.Power, discipline.ResistanceType, discipline.CastingTimeInSegments, discipline.DurationInRounds, discipline.GetDamage)
    {
        Discipline = discipline;
    }
}
