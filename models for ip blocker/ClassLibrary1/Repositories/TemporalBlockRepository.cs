using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dataacsess.Repositories
{
    public class TemporalBlockRepository:ITemporalBlockRepository
    {
        private readonly ConcurrentDictionary<string, DateTime> _temporalBlocks = new();

        public bool AddTemporalBlock(string countryCode, DateTime expiration) =>
            _temporalBlocks.TryAdd(countryCode, expiration);

        public bool RemoveTemporalBlock(string countryCode) =>
            _temporalBlocks.TryRemove(countryCode, out _);

        public IEnumerable<KeyValuePair<string, DateTime>> GetAllTemporalBlocks() =>
            _temporalBlocks;
    }
}
