using Dataacsess.IRepositories;
using Dataacsess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dataacsess.Repositories;
namespace Bussiness_logic.Services
{
    public class BlockedAttemptLogService
    {
       
            private readonly IBlockedAttemptLogRepository _repository;

            public BlockedAttemptLogService(IBlockedAttemptLogRepository repository)
            {
                _repository = repository;
            }

            public void LogAttempt(string ip, string countryCode, string userAgent)
            {
                var log = new BlockedAttemptLog(ip, DateTime.UtcNow, countryCode, userAgent);
                _repository.LogAttempt(log);
            }

            public IEnumerable<BlockedAttemptLog> GetLogs(int page, int pageSize)
            {
                var logs = _repository.GetLogs(page, pageSize);
                return logs.Select(log => new BlockedAttemptLog(
                    log.IpAddress,
                    log.Timestamp,
                    log.CountryCode,
                    log.UserAgent
                ));
            }
        
    }
}
