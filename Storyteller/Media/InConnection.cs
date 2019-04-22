using System.Collections.Generic;

namespace Storyteller.Media
{
	public class InConnection : ConnectionBase
	{
		private IEnumerable<IInputPort> inputPins;

		public IEnumerable<IInputPort> InputPins
		{
			get => inputPins;
			set
			{
				if (inputPins != value)
				{
					inputPins = value;
					if (inputPins != null)
					{
						foreach (var inputPin in inputPins)
						{
							inputPin.Filter = this;
						}
					}
				}
			}
		}

		public InConnection(string name, IEnumerable<IInputPort> inputPins = null)
			: base(name)
		{
			InputPins = inputPins;
		}
	}

}
