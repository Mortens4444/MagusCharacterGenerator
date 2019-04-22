using Mtf.Helper;
using Mtf.Languages;
using System;

namespace MagusCharacterGenerator.GameSystem.Valuables
{
	class Money
    {
        public uint Mithrill { get; set; }

        public uint Gold { get; set; }

        public uint Silver { get; set; }

        public uint Copper { get; set; }

        public Money(uint gold, uint silver = 0, uint copper = 0)
        {
            Gold = gold;
            Silver = silver;
            Copper = copper;
        }

		public override string ToString()
		{
			var mitrill = Mithrill > 0 ? $"{Mithrill} {Lng.Elem(nameof(Mithrill))}" : String.Empty;
			var gold = Gold > 0 ? $"{Gold} {Lng.Elem(nameof(Gold))}" : String.Empty;
			var silver = Silver > 0 ? $"{Silver} {Lng.Elem(nameof(Silver))}" : String.Empty;
			var copper = Copper > 0 ? $"{Copper} {Lng.Elem(nameof(Copper))}" : String.Empty;
			return StringExtensions.Join(", ", mitrill, gold, silver, copper);
		}
	}
}
