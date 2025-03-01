using Bussiness_logic.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Bussiness_logic.DTOS;
namespace IP_BLOCKER.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly BlockedCountryService _blockedService;
        private readonly TemporalBlockService _temporalService;

        public CountriesController(
            BlockedCountryService blockedService,
            TemporalBlockService temporalService)
        {
            _blockedService = blockedService;
            _temporalService = temporalService;
        }

        [HttpPost("block")]
        public IActionResult BlockCountry([FromBody] BlockCountryDTO request)
        {
            if (!_blockedService.BlockCountry(request.CountryCode))
                return Conflict("Country already blocked");
            return Ok();
        }

        [HttpDelete("block/{countryCode}")]
        public IActionResult UnblockCountry([FromRoute] string countryCode)
        {
            if (!_blockedService.UnblockCountry(countryCode))
                return NotFound();
            return NoContent();
        }

        [HttpGet("blocked")]
        public IActionResult GetBlockedCountries([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var countries = _blockedService.GetBlockedCountries()
                .Skip((page - 1) * pageSize)
                .Take(pageSize);
            return Ok(countries);
        }

        [HttpPost("temporal-block")]
        public IActionResult AddTemporalBlock([FromBody] TemporalBlockDTO request)
        {
            if (!_temporalService.AddTemporalBlock(request.CountryCode, request.DurationMinutes))
                return Conflict("Temporal block already exists");
            return Ok();
        }
    }
}
