using Models.Data;

namespace Models
{
    public class CounterManager : Entities.Interfaces.ICounterManager
    {
        PruebasContext _pruebasContext;
        public CounterManager(PruebasContext pruebasContext)
        {
            _pruebasContext = pruebasContext;
        }

        public int GetCounterValue(string tag)
        {
            var counter = _pruebasContext.Counters.FirstOrDefault(c => c.Tag == tag);
            return counter?.Count ?? 0;
        }

        public void IncrementCounter(string tag)
        {
            var counter = _pruebasContext.Counters.FirstOrDefault(c => c.Tag == tag);
            if (counter == null)
            {
                counter = new Models.Counter
                {
                    Tag = tag,
                    Count = 1,
                    Createdate = DateTime.Now,
                    Lastupdatedate = DateTime.Now
                };
                _pruebasContext.Counters.Add(counter);
            }
            else
            {
                counter.Count++;
                counter.Lastupdatedate = DateTime.Now;
            }
            _pruebasContext.SaveChanges();
        }
    }
}
