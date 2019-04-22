using MagusCharacterGenerator.GameSystem.Qualifications;

namespace MagusCharacterGenerator.GameSystem.Magic
{
	abstract class Sorcery : ISpecialQualification
    {
        public ushort ManaPoints { get; set; }

        public virtual ushort GetManaPointsModifier()
        {
            return ManaPoints;
        }
    }
}
