namespace Outputer
{
    public interface IOutputable
    {
        bool IsEmpty { get; }

        string ToString();
    }
}
