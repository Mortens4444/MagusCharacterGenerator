using M.A.G.U.S.GameSystem.Attributes;

namespace M.A.G.U.S.Enums;

public enum Deity
{
    // --- Pyarroni Panteon ---

    [AvailableSpheres(Sphere.Life, Sphere.Magic)]
    Adron, // A mágia ura

    [AvailableSpheres(Sphere.Nature, Sphere.Life)] // Hagyományosan bárdok is tisztelik
    Alborne,

    [AvailableSpheres(Sphere.Nature, Sphere.Life)] // A tengerek ura
    Antoh,

    [AvailableSpheres(Sphere.Nature, Sphere.Life)] // A harc és természet úrnője
    Arel,

    [AvailableSpheres(Sphere.Death, Sphere.Soul)] // A halál és tréfa istene
    Darton,

    [AvailableSpheres(Sphere.Soul, Sphere.Magic)] // A művészetek úrnője
    Della,

    [AvailableSpheres(Sphere.Order, Sphere.Life)] // A rend és kereskedelem úrnője (Pyarron főistene)
    Dreina,

    [AvailableSpheres(Sphere.Life, Sphere.Soul)] // A szerelem és szépség úrnője
    Ellana,

    [AvailableSpheres(Sphere.Life, Sphere.Chaos)] // A mesteremberek istene, "balul sikerült dolgok"
    Gilron,

    [AvailableSpheres(Sphere.Life, Sphere.Soul)] // A tudás ura
    Krad,

    [AvailableSpheres(Sphere.Order, Sphere.Destruction)] // A végzet és törvény ura
    Kyel,

    [AvailableSpheres(Sphere.Soul, Sphere.Order)] // A szerencse és tolvajok istene (kétarcú)
    Noir,

    [AvailableSpheres(Sphere.Death, Sphere.Soul)] // A bosszú ura
    Uwel,

    [AvailableSpheres(Sphere.Death, Sphere.Destruction)] // A "Kitaszított", a panteon ellensége
    Orwella,

    // --- Shadon ---

    [AvailableSpheres(Sphere.Life, Sphere.Soul)] // Az Egyetlen, hétarcú isten
    Domvik,

    // --- Sötét Istenek / Toron / Krán ---

    [AvailableSpheres(Sphere.Destruction, Sphere.Chaos)] // A káosz és pusztítás (Toron)
    Tharr,

    [AvailableSpheres(Sphere.Domination, Sphere.Death)] // A Kosfejes Úr (Krán)
    Ranagol,

    [AvailableSpheres(Sphere.Fire, Sphere.Destruction)] // A Tűzkobra (Ordan)
    Sogron,

    // --- Kiegészítő / Egyéb ---

    [AvailableSpheres(Sphere.Order, Sphere.Magic)]
    Weila // Kyria régi főistene
}