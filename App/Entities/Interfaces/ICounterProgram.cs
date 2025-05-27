namespace Entities.Interfaces
{
    public interface ICounterProgram
    {
        Task Run(string tag, string[] args);
    }
}