using Bussiness_logic.Services;
using Dataacsess.IRepositories;
using Dataacsess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace IP_BLOCKER.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IpController : ControllerBase
    {
        private readonly GeolocationService _geoService;
        private readonly BlockedCountryService _blockedService;
        private readonly BlockedAttemptLogService _logRepository;

        public IpController(
            GeolocationService geoService,
            BlockedCountryService blockedService,
            BlockedAttemptLogService logRepository)
        {
            _geoService = geoService;
            _blockedService = blockedService;
            _logRepository = logRepository;
        }

        [HttpGet("lookup")]
        public async Task<IActionResult> LookupIp([FromQuery] string? ipAddress)
        {
            var ip = ipAddress ?? HttpContext.Connection.RemoteIpAddress?.ToString();
            if (!IPAddress.TryParse(ip, out _))
                return BadRequest("Invalid IP format");

            var geoData = await _geoService.GetGeolocationAsync(ip!);
            return Ok(geoData);
        }

        [HttpGet("check-block")]
        public async Task<IActionResult> CheckBlock([FromQuery] string? ipAddress)
        {
            var ip = ipAddress ?? HttpContext.Connection.RemoteIpAddress?.ToString();
            if (ip is null) return BadRequest("IP not detected");

            var geoData = await _geoService.GetGeolocationAsync(ip);
            var isBlocked = _blockedService.GetBlockedCountries().Contains(geoData.CountryCode);

            _logRepository.LogAttempt(ip, geoData.CountryCode,
                Request.Headers.UserAgent.ToString());

            return Ok(new { IsBlocked = isBlocked });
        }
    }
}
