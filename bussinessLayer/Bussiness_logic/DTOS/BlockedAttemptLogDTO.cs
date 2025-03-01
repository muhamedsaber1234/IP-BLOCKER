namespace Bussiness_logic.DTOS
{
    public class BlockedAttemptLogDTO
    {
        string IpAddress { get; set; }
        DateTime Timestamp { get; set; }
        string CountryCode { get; set; }
        string UserAgent    { get; set; }
        public BlockedAttemptLogDTO(string IpAddress, DateTime Timestamp, string CountryCode, string UserAgent)
        {
        this.IpAddress = IpAddress;
            this.Timestamp = Timestamp;
            this.CountryCode = CountryCode;
            this.UserAgent = UserAgent;
        }
    }
}
