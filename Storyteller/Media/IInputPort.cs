namespace Storyteller.Media
{
    public interface IInputPort : IPortBase
    {
        new IOutputPort ConnectedPort { get; set; }
    }
}