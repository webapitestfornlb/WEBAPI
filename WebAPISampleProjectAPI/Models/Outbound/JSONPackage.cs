using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPISampleProjectAPI.Models.Outbound
{
    public class JSONPackage<T>
    {
        public JSONPackage() { }

        public bool IsSuccess { get; set; }
        public string ServerMessage { get; set; }
        public T Package { get; set; }

        public void Exception(Exception ex)
        {
            this.IsSuccess = false;
            this.ServerMessage = ex.Message;
        }
        public void Success()
        {
            this.IsSuccess = true;
        }
    }
}