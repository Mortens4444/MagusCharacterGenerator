using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Accomodation;

public class Bath : Thing
{
	public override Money Price => new(0, 0, 3);

    public override string Description => "Bathing Chamber\r\n\r\nThe Hot Vapours and Scrubbing Chamber. A common tub of heated waters, often shared by others, yet welcome to the weary traveller to wash away the road dust and grime. For those of higher purse, a private curtain may afford some modesty.";
}
