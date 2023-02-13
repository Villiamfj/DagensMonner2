using DagensMonnerWithEntityFramework.Data;
using System.Data.Entity;

namespace DagensMonnerWithEntityFramework.Models
{
    public class MonnerController : IMonnerController
    {
        private LogState _state;
        private string connectionString { get; }

        public MonnerController(string connectionstring)
        {
            connectionString = connectionstring;
            using MonnerContext context = new MonnerContext(connectionString);

            if (context.LogStates.Any())
            {
                var lastState = context.LogStates.OrderBy(state => state.Id).Last();

                if (DateOnly.FromDateTime(lastState.Date) < DateOnly.FromDateTime(DateTime.Now))
                {
                    _state = MakeNewState(context);
                }
                else
                {
                    context.Entry(lastState).Reference(state => state.Monner).Load();
                    _state = lastState;
                }
            }
            else
            {
                _state = MakeNewState(context);
            }
        }

        public Monner GetMonner()
        {
            if (DateOnly.FromDateTime(_state.Date) < DateOnly.FromDateTime(DateTime.Now))
            {
                using MonnerContext context = new MonnerContext(connectionString);
                _state = MakeNewState(context);
            }
            return _state.Monner;
        }

        private LogState MakeNewState(MonnerContext context)
        {
            LogState newState = new LogState { Date = DateTime.Now, Monner = FindNewMonner(context) };

            context.LogStates.Add(newState);
            context.SaveChanges();

            return newState;
        }

        private Monner FindNewMonner(MonnerContext context)
        {
            if (!context.Monners.Any()) throw new Exception("no monners in db");

            int lastTakenKey = _state == null? -1 : _state.Monner.Id;

            var monners = context.Monners.Where(monner => monner.Id != lastTakenKey).ToList();

            var max = monners.MaxBy(monner => monner.TimesTaken);
            var min = monners.MinBy(monner => monner.TimesTaken);

            var limit = (max.TimesTaken + min.TimesTaken) / 2;

            var filteredMonners = monners.Where(monner => monner.TimesTaken <= limit);

            Random rand = new Random();
            int skipCount = rand.Next(0, filteredMonners.Count());

            Monner selected = filteredMonners.Skip(skipCount).First();
            selected.TimesTaken++;
            context.SaveChanges();

            return selected;
        }
    }
}
