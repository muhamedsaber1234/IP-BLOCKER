using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dataacsess.Repositories
{
    public interface IBlockedCountryRepository
    {
        bool Add(string countryCode);
        bool Remove(string countryCode);
        IEnumerable<string> GetAll();
        bool Exists(string countryCode);
    }
}
