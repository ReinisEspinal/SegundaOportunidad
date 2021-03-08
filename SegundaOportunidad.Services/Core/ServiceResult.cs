using System;
using System.Collections.Generic;
using System.Text;

namespace SegundaOportunidad.Services.Core
{
   public  class ServiceResult
    {
        public ServiceResult()
        {
            this.success = true;
        }
        public bool success { get; set; }
        public string message { get; set; }
        public dynamic Data { get; set; }
    }
}
