using Dataacsess.IRepositories;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dataacsess.Models;
namespace Dataacsess.Repositories
{
    public class BlockedAttemptLogRepository : IBlockedAttemptLogRepository
    {

        private readonly ConcurrentQueue<BlockedAttemptLog> _logs = new();

        public void LogAttempt(BlockedAttemptLog log) =>
            _logs.Enqueue(log);

        public IEnumerable<BlockedAttemptLog> GetLogs(int page, int pageSize) =>
            _logs.Skip((page - 1) * pageSize).Take(pageSize);
    }
}
