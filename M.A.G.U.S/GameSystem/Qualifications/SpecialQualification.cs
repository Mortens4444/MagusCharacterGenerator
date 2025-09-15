namespace M.A.G.U.S.GameSystem.Qualifications
{
    public class SpecialQualification : ISpecialQualification
    {
        public virtual string Name => GetType().Name;
    }
}
