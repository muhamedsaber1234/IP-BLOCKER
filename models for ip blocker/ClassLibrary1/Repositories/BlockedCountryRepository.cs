using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dataacsess.Repositories
{
    public class BlockedCountryRepository:IBlockedCountryRepository
    {
        private readonly ConcurrentDictionary<string, bool> _blockedCountries = new();

        public bool Add(string countryCode) =>
            _blockedCountries.TryAdd(countryCode, true);

        public bool Remove(string countryCode) =>
            _blockedCountries.TryRemove(countryCode, out _);

        public IEnumerable<string> GetAll() => _blockedCountries.Keys;

        public bool Exists(string countryCode) =>
            _blockedCountries.ContainsKey(countryCode);
    }
}
