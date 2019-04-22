namespace Storyteller.Media
{
    public interface IPortBase
    {
        string Name { get; }

        ConnectionBase Filter { get; set; }

        IPortBase ConnectedPort { get; set; }
    }
}
