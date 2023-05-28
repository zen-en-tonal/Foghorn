namespace Foghorn.Logging
{
    public interface ILogOutputProvider
    {
        ILogOutput CreateLogOutput();
    }
}
