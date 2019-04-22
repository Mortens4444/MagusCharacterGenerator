namespace Storyteller.Media
{
    public interface IOutputPort : IPortBase
    {
        new IInputPort ConnectedPort { get; set; }
    }
}