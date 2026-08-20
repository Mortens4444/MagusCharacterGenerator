namespace MAGUS.GameSystem.Places;

/// <summary>
/// Approximate (X, Y) position in miles for each City, estimated from the two Ynev world maps in
/// Első Törvénykönyv (p.465 "Észak-Ynev", North; p.466 "Dél-Ynev", South - both hand-drawn, no
/// printed scale bar), calibrated against the book's one stated real-world distance ("Lar-Dor to
/// Ó-Pyarron, close to a thousand miles apart", p.452). X = east(+)/west(-), Y = north(+)/south(-),
/// origin at Pyarron. This is flavor-accurate, not survey-grade: 11 of the 19 cities were directly
/// map-labeled or clearly placed by the geography chapter text (p.417-464) - the other 8 (noted
/// below) appear nowhere in the map or that chapter and are placed only from the regional hints
/// already in City.cs's own comments, so treat distances involving those as rough estimates.
/// </summary>
public static class CityCoordinates
{
    private static readonly Dictionary<City, (double X, double Y)> Coordinates = new()
    {
        [City.Pyarron] = (0, 0), // High confidence - dot-marked "Új-Pyarron", South map
        [City.Toron] = (2594, 9914), // High confidence - directly labeled, North map
        [City.Ordan] = (-2173, 6298), // Low-medium confidence - not map-labeled; placed per text (Sheral-range pass valley, Városállamok strip near Erion)
        [City.Doran] = (2627, 11590), // High confidence - dot-marked, North map
        [City.Erion] = (-2173, 3736), // High confidence - dot-marked at map's south edge, matches extensive text (Kalandozók Városa)
        [City.Erigow] = (2692, 11227), // High confidence - directly labeled, North map, adjacent to Doran
        [City.Shadon] = (3211, -2400), // Medium-high confidence - "Shadon Birodalom" region label centroid, South map
        [City.Abasis] = (3470, 6963), // High confidence - labeled "Abaszisz", North map
        [City.Gorvik] = (5092, 454), // High confidence - labeled "Gorwick", South map
        [City.Tiadlan] = (5448, 9427), // High confidence - directly labeled, North map
        [City.Enosuke] = (5610, 10718), // Low confidence - not on map/in text; placed with the far-east island nations (Tarin, Gro-Ugon) per Country.cs grouping
        [City.Alidax] = (1232, 1719), // Low confidence - not on map/in text; City.cs comment says "Délvidék/Dzsad környék", placed in the dzsad desert region
        [City.TierNanGorduin] = (2043, 1946), // Low confidence - same regional placement (dzsad area); City.cs comment "Darton híres helye" gave no independent map location
        [City.Abesar] = (2854, 1395), // Low confidence - same regional placement (dzsad area)
        [City.Allanor] = (1622, 9427), // Low confidence - not on map/in text; City.cs comment "Toron környéke", placed near Toron
        [City.Evervis] = (3405, 9590), // Low confidence - same ("Toron környéke"), placed near Toron, opposite side
        [City.Riegoy] = (-2530, 10644), // High confidence - explicitly labeled "Riegoy-öböl" bay, North map; matches text and Country.cs "Riegoy Bay"
        [City.Sonnion] = (1395, 1946), // Low confidence - ruined amund city (Thon-nion), not individually mapped; placed in the amunds' historical Taba-el-Ibara desert homeland
        [City.Talasea] = (2367, 1395), // Low confidence - ruined amund city of Refis (Thalatheia), same desert region, different spot
    };

    /// <summary>Straight-line ("légvonal") distance between two cities, in miles.</summary>
    public static double DistanceInMiles(City from, City to)
    {
        var a = Coordinates[from];
        var b = Coordinates[to];
        return Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2));
    }
}
