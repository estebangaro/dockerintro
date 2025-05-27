namespace DotNet.Docker
{
    internal class CounterProgram : Entities.Interfaces.ICounterProgram
    {
        Entities.Interfaces.ICounterManager counterManager;
        public CounterProgram(Entities.Interfaces.ICounterManager counterManager)
        {
            this.counterManager = counterManager;
        }

        public async Task Run(string tag, string[] args)
        {
            var max = 0;
            if (args != null && args.Length is 2)
            {
                Console.WriteLine($"Número de argumentos \"{args.Length}\": {string.Join(',', args)}.");
                max = int.Parse(args[1]);
            }
            else
            {
                max = -1;
            }

            int counter = counterManager.GetCounterValue(tag);
            while (max == -1 || counter < max)
            {
                Console.WriteLine($"Counter: {++counter}");
                counterManager.IncrementCounter(tag);
                await Task.Delay(millisecondsDelay: 1_000);
            }
        }
    }
}