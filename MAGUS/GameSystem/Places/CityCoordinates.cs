namespace MAGUS.GameSystem.Places;

/// <summary>
/// (X, Y) position in miles for each City. Originally estimated by eye from the two Ynev world maps
/// in Első Törvénykönyv (p.465/p.466, hand-drawn, no printed scale bar) - that first pass turned out
/// to place several cities substantially wrong (e.g. TierNanGorduin/Alidax came out ~9500 miles - a
/// 200+ day walk - from Enosuke, when the real figure is closer to 1600 miles/35 days). Replaced with
/// coordinates read off the community-maintained interactive Ynev map at kalandozok.hu/ynev/, which
/// carries its own internally consistent (and much larger, ~1700-place) coordinate dataset for the
/// same world. Both the old and new coordinate spaces are calibrated against the same one stated
/// real-world distance in the book ("Lar-Dor to Ó-Pyarron, close to a thousand miles apart", p.452;
/// kalandozok.hu's Lar-Dor<->Ó-Pyarron distance is 978.13 of its own units, giving a scale of 1.02236
/// miles per unit), so this is a straight rescale/re-origin of that site's data, not a new estimate.
/// X = east(+)/west(-), Y = north(+)/south(-), origin at City.Pyarron (matched to kalandozok.hu's
/// "Új-Pyarron" marker - the comment on the old data already identified City.Pyarron as New, not Old,
/// Pyarron). 15 of the 19 cities matched a named marker on kalandozok.hu directly (see the per-city
/// comments for which marker); TierNanGorduin, Abesar, Allanor and Evervis have no matching marker
/// anywhere in that ~1700-place dataset, which is a strong signal they're not canonical MAGUS
/// locations at all (most likely named/placed for this app's own quest content) - those four keep
/// their old estimated offset from their regional anchor city, just re-based onto that anchor's new
/// position, so they stay in the same relative neighborhood without claiming false precision.
/// </summary>
public static class CityCoordinates
{
    private static readonly Dictionary<City, (double X, double Y)> Coordinates = new()
    {
        [City.Pyarron] = (0, 0), // Origin - kalandozok.hu marker "Új-Pyarron"
        [City.Toron] = (2490, 8319), // kalandozok.hu marker "Toron"
        [City.Ordan] = (-293, 2819), // kalandozok.hu marker "Ordan"
        [City.Doran] = (1425, 9884), // kalandozok.hu marker "Doran"
        [City.Erion] = (-660, 3121), // kalandozok.hu marker "Erion"
        [City.Erigow] = (1727, 9826), // kalandozok.hu marker "Erigow (város)"
        [City.Shadon] = (3131, -1451), // kalandozok.hu marker "Shadon"
        [City.Abasis] = (2227, 6750), // kalandozok.hu marker "Abaszisz"
        [City.Gorvik] = (3620, 1145), // kalandozok.hu marker "Gorvik (ország)" - no separate city-level marker exists there, only country/province ones
        [City.Tiadlan] = (3747, 8509), // kalandozok.hu marker "Tiadlan"
        [City.Enosuke] = (6403, 8907), // kalandozok.hu marker "Enoszuke"
        [City.Alidax] = (4917, 7242), // kalandozok.hu marker "Alidax"
        [City.TierNanGorduin] = (5728, 7469), // No kalandozok.hu marker (see class remarks) - kept at its old (811, 227) mile offset from Alidax, its regional anchor
        [City.Abesar] = (6539, 6918), // No kalandozok.hu marker (see class remarks) - kept at its old (1622, -324) mile offset from Alidax, its regional anchor
        [City.Allanor] = (1518, 7832), // No kalandozok.hu marker (see class remarks) - kept at its old (-972, -487) mile offset from Toron, its regional anchor
        [City.Evervis] = (3301, 7995), // No kalandozok.hu marker (see class remarks) - kept at its old (811, -324) mile offset from Toron, its regional anchor
        [City.Riegoy] = (-2231, 7798), // kalandozok.hu marker "Riegoy-öböl" (the bay itself, matching Country.cs's "Riegoy Bay" and this city's own book placement)
        [City.Sonnion] = (2424, 3184), // kalandozok.hu marker "Thon-nion" - matches this ruined amund city's own [Description] in City.cs
        [City.Talasea] = (3485, 3801), // kalandozok.hu marker "Thala-theia" - matches this ruined amund city's own [Description] ("Thalatheia") in City.cs

        // 2026-os bővítés (lásd City.cs) - mind kalandozok.hu "varosterkep"/"varosleiras" jelölésű,
        // vagyis a közösség saját maga is önálló várost/települést dokumentáló, oldallal rendelkezik.
        [City.Amaro] = (3121, -394),
        [City.Arascor] = (2448, 1346),
        [City.Arshur] = (-377, 5094),
        [City.Baraadheik] = (2757, 6809),
        [City.Bolk] = (4829, 7695),
        [City.Caedon] = (2726, 6709),
        [City.Davalon] = (2351, 9022),
        [City.ElHamed] = (620, 1639),
        [City.ElZashra] = (2313, 1549),
        [City.Elya] = (3856, 8710),
        [City.Emarion] = (2577, -2142),
        [City.Eren] = (1092, 9927),
        [City.ErkMedence] = (-495, 980),
        [City.Garhudda] = (2692, 6361),
        [City.Ghastal] = (773, 7738),
        [City.Haonwell] = (1433, 10234),
        [City.Haralk] = (5274, 7458),
        [City.Ifin] = (2145, 6582),
        [City.Jemirre] = (-2429, 8476),
        [City.Kalaril] = (-266, 5353),
        [City.Laorgan] = (-964, -224),
        [City.Lavandron] = (-1003, 2659),
        [City.Mezrud] = (-361, 2355),
        [City.Nastral] = (-1510, -1615),
        [City.Nurween] = (2121, 8757),
        [City.OPyarron] = (-485, -940),
        [City.Odra] = (2245, 339),
        [City.Qunzais] = (-423, 1119),
        [City.Roxen] = (-615, 1319),
        [City.SelDuriem] = (1358, 6427),
        [City.SinogKul] = (700, 10299),
        [City.Sushtar] = (1009, 358),
        [City.Syburr] = (-1486, -1487),
        [City.Tadzeh] = (1818, 6670),
        [City.Tagreosz] = (1387, -1457),
        [City.Terragin] = (4501, 7048),
        [City.Tervin] = (-442, 5380),
        [City.Triyang] = (6537, 9266),
        [City.Tuurian] = (2774, 6454),
        [City.Varreon] = (2741, 6528),
    };

    /// <summary>Straight-line ("légvonal") distance between two cities, in miles.</summary>
    public static double DistanceInMiles(City from, City to) => GetPosition(from).DistanceTo(GetPosition(to));

    /// <summary>The city's (X, Y) position in miles - see the class remarks for how this is calibrated.</summary>
    public static WorldPosition GetPosition(City city)
    {
        var (x, y) = Coordinates[city];
        return new WorldPosition(x, y);
    }

    /// <summary>Same as GetPosition, but false (instead of throwing) for a city with no coordinate entry - i.e. City.Unknown.</summary>
    public static bool TryGetPosition(City city, out WorldPosition position)
    {
        if (Coordinates.TryGetValue(city, out var c))
        {
            position = new WorldPosition(c.X, c.Y);
            return true;
        }

        position = default;
        return false;
    }
}
