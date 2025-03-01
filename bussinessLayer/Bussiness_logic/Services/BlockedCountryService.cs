using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dataacsess.IRepositories;
using Dataacsess.Repositories;
namespace Bussiness_logic.Services
{
    public class BlockedCountryService
    {
        private readonly IBlockedCountryRepository _repository;

        public BlockedCountryService(IBlockedCountryRepository repository)
        {
            _repository = repository;
        }

        public bool BlockCountry(string countryCode) => _repository.Add(countryCode);
        public bool UnblockCountry(string countryCode) => _repository.Remove(countryCode);
        public IEnumerable<string> GetBlockedCountries() => _repository.GetAll();
    }
}
