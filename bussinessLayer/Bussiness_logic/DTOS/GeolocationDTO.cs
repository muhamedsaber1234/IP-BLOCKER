namespace Bussiness_logic.DTOS
{
    public class GeolocationDTO
    {
        public string Ip {  get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public string Isp { get; set; }
        public GeolocationDTO(string Ip, string CountryCode, string CountryName, string Isp)
        {
         this.Ip = Ip;
            this.CountryCode = CountryCode;
            this.CountryName = CountryName;
            this.Isp = Isp;
        }
    }
}
