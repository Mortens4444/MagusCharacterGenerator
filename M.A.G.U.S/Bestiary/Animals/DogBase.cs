using M.A.G.U.S.GameSystem.BreedModifiers;
using M.A.G.U.S.Interfaces;
using Mtf.Extensions.Services;

namespace M.A.G.U.S.Bestiary.Animals;

public abstract class DogBase : Creature
{
    protected readonly IBreedModifier breedModifier;

    protected DogBase()
    {
        var modifierTypes = new List<IBreedModifier> { new Aeternam(), new Blegront(), new Cirnecos(), new Hastin(), new Pittaros(), new Robardoar() };
        breedModifier = modifierTypes[RandomProvider.GetSecureRandomInt(0, modifierTypes.Count)];
    }

    protected void ApplyBreedModifier()
    {
        InitiateValue += breedModifier.InitiateValue;
        AttackValue += breedModifier.AttackValue;
        DefenseValue += breedModifier.DefenseValue;

        if (HealthPoints.HasValue)
        {
            HealthPoints = Math.Max(1, HealthPoints.Value + breedModifier.ExtraHealtPoints);
        }

        if (PainTolerancePoints.HasValue)
        {
            PainTolerancePoints = Math.Max(1, PainTolerancePoints.Value + breedModifier.ExtraPainTolerancePoints);
        }

        ExperiencePoints = Math.Max(1, (ulong)((int)ExperiencePoints + breedModifier.ExtraExperiancePoints));
    }

    protected int ApplyDamageModifier(int baseDamage) => Math.Max(0, baseDamage + breedModifier.ExtraDamage);
}