using System.ComponentModel.DataAnnotations;

namespace Bussiness_logic.DTOS
{
    public class TemporalBlockDTO
    {
        [RegularExpression(@"^[A-Z]{2}$")]
        public string CountryCode {  get; set; }

        [Range(1, 1440)] 
        public int DurationMinutes { get; set; }
    }
}
