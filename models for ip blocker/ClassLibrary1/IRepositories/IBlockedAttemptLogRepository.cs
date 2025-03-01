using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dataacsess.Models;
namespace Dataacsess.IRepositories
{
    public interface IBlockedAttemptLogRepository
    {
        void LogAttempt(BlockedAttemptLog log);
        IEnumerable<BlockedAttemptLog> GetLogs(int page, int pageSize);
    }
}
