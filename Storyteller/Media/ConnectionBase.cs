namespace Storyteller.Media
{
	public class ConnectionBase
	{
		public string Name { get; private set; }

		public ConnectionBase(string name)
		{
			Name = name;
		}

		public override string ToString()
		{
			return Name;
		}
	}
}
