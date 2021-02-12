using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPISampleProjectAPI.Controllers
{
    [ApiController]
    public class Claims : ControllerBase
    {
        [HttpGet]
        [Route("Claims/SearchClaims")]
        public IActionResult SearchClaims([FromQuery] DateTime searchDate)
        {
            Models.Outbound.JSONPackage<List<Models.Outbound.Member>> package = new Models.Outbound.JSONPackage<List<Models.Outbound.Member>>();

            try
            {
                // Search Claims                
                Models.Internal.APIResult<List<Models.Outbound.Member>> apiResult = Services.ClaimSearcher.GetClaimsByDate(searchDate);

                if (apiResult.IsSuccess)
                {
                    package.Package = apiResult.Package;
                }
                else
                {
                    package.IsSuccess = true;
                    package.ServerMessage = apiResult.ServiceMessage;
                }

                package.Success();
            }
            catch (Exception ex)
            {
                package.Exception(ex);
            }

            return Ok(package);
        }
    }
}
