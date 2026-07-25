using M.A.G.U.S.Interfaces;
using Newtonsoft.Json;

namespace M.A.G.U.S.GameSystem;

public sealed class PsiAttack : MysticAttack
{
    public IPsiDiscipline Discipline { get; init; }

    public int PsiPointCost => Discipline.PsiPointCost;

    [JsonConstructor]
    public PsiAttack() : base() { }

    public PsiAttack(IPsiDiscipline discipline)
        : base(discipline.Name, discipline.InitiateValue, discipline.ResistanceType, discipline.CastingTimeInSegments, discipline.DurationInRounds, discipline.GetDamage)
    {
        Discipline = discipline;
    }
}
