using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPISampleProjectAPI.Models.Outbound
{
    public class Claim
    {
        public int MemberID { get; set; }
        public DateTime ClaimDate { get; set; }
        public double ClaimAmount { get; set; }
    }
}
