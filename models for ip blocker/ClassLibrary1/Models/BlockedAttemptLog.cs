using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dataacsess.Models
{
    public class BlockedAttemptLog
    {
          public  string IpAddress {  get; set; }
          public  DateTime Timestamp {  get; set; }
          public  string CountryCode {  get; set; }
          public  string UserAgent {  get; set; }
       public BlockedAttemptLog(string _IpAddress, DateTime _Timestamp, string _CountryCode, string _UserAgent)
        {
        this.IpAddress = _IpAddress;
            this.Timestamp = _Timestamp;
            this.CountryCode = _CountryCode;
            this.UserAgent = _UserAgent;
        
        }
    }
}
