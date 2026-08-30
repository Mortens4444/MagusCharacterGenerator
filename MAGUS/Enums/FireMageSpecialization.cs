namespace MAGUS.Enums;

/// <summary>
/// The three Utak (Paths) a Tűzvarázsló (Fire Mage) must choose between at level 5 - Második
/// Törvénykönyv, "Kasztok", "A tűzvarázslók három Útja" (p.34-36). See FireMage.Specialization.
/// </summary>
public enum FireMageSpecialization
{
    /// <summary>Not yet chosen - only valid below level 5.</summary>
    None,

    /// <summary>Pusztító Tűz Útja (Path of Destructive Fire) - joins the Tűz Harcosai Rend.</summary>
    DestructiveFire,

    /// <summary>Fény Ösvénye (Path of Light) - joins the Tűz Hordozói Rend.</summary>
    Light,

    /// <summary>Sogron Útja (Path of Sogron) - joins the Tűz Táplálói Rend and becomes a priest from here on.</summary>
    Sogron
}
