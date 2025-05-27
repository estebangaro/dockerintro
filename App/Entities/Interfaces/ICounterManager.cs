namespace Entities.Interfaces
{
    public interface ICounterManager
    {
        int GetCounterValue(string tag);

        void IncrementCounter(string tag);
    }
}