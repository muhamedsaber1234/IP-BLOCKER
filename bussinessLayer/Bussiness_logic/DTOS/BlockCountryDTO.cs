using System.ComponentModel.DataAnnotations;

namespace Bussiness_logic.DTOS
{
    public class BlockCountryDTO
    {
        [RegularExpression(@"^[A-Z]{2}$")]
       public string CountryCode { get; set; }
    }
}
