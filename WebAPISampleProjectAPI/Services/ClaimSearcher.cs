using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPISampleProjectAPI.Services
{
    public class ClaimSearcher
    {
        public static Models.Internal.APIResult<List<Models.Outbound.Member>> GetClaimsByDate(DateTime date)
        {
            Models.Internal.APIResult<List<Models.Outbound.Member>> apiResult = new Models.Internal.APIResult<List<Models.Outbound.Member>>();
            apiResult.Package = new List<Models.Outbound.Member>();

            if(date == DateTime.MinValue) return apiResult;

            try
            {
                // Load Data
                List<Models.Outbound.Member> members = new List<Models.Outbound.Member>();
                List<Models.Outbound.Claim> claims = new List<Models.Outbound.Claim>();

                // Load the members and claims
                using (var reader = new StreamReader(@"G:\Discard\WebAPI-SampleProject\Member.csv"))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    members = csv.GetRecords<Models.Outbound.Member>().ToList();
                }

                using (var reader = new StreamReader(@"G:\Discard\WebAPI-SampleProject\Claim.csv"))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    claims = csv.GetRecords<Models.Outbound.Claim>().ToList();
                }

                // Build model & Search Data
                foreach (var member in members)
                {
                    // Get child claims
                    member.Claims = claims.Where(x => x.MemberID == member.MemberID && x.ClaimDate.Date == date.Date).ToList();
                    if (member.Claims.Count != 0)
                    {
                        apiResult.Package.Add(member);
                    }
                }

            }
            catch (Exception ex)
            {
                apiResult.IsSuccess = false;
                apiResult.ServiceMessage = ex.Message;
            }

            return apiResult;
        }
}
}
