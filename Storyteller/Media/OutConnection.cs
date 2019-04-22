using System.Collections.Generic;

namespace Storyteller.Media
{
	public class OutConnection : ConnectionBase
	{
		private IEnumerable<IOutputPort> outputPins;

		public IEnumerable<IOutputPort> OutputPins
		{
			get => outputPins;
			set
			{
				if (outputPins != value)
				{
					outputPins = value;
					if (outputPins != null)
					{
						foreach (var outputPin in outputPins)
						{
							outputPin.Filter = this;
						}
					}
				}
			}
		}
		public OutConnection(string name, IEnumerable<IOutputPort> outputPins = null)
			: base(name)
		{
			OutputPins = outputPins;
		}
	}

}
