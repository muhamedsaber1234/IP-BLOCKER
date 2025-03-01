using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dataacsess.Repositories
{
    public interface ITemporalBlockRepository
    {
        bool AddTemporalBlock(string countryCode, DateTime expiration);
        bool RemoveTemporalBlock(string countryCode);
        IEnumerable<KeyValuePair<string, DateTime>> GetAllTemporalBlocks();
    }
}
