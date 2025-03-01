using Bussiness_logic.DTOS;
using Bussiness_logic.Services;
using Dataacsess.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IP_BLOCKER.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogsController : ControllerBase
    {
        private readonly BlockedAttemptLogService _logRepository;

        public LogsController(BlockedAttemptLogService logRepository)
        {
            _logRepository = logRepository;
        }

        [HttpGet("blocked-attempts")]
        public IActionResult GetLogs([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var logs = _logRepository.GetLogs(page, pageSize)
                .Select(log => new BlockedAttemptLogDTO(
                    log.IpAddress,
                    log.Timestamp,
                    log.CountryCode,
                    log.UserAgent
                ));
            return Ok(logs);
        }
    }
}
