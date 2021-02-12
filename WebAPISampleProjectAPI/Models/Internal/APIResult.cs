using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPISampleProjectAPI.Models.Internal
{
    public class APIResult<T>
    {

        public bool IsSuccess { get; set; }
        public string ServiceMessage { get; set; }
        public T Package { get; set; }
    }
}