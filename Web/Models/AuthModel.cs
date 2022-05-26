using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class AuthModel
    {
        public class AuthDataResult
        {
            public Data data { get; set; }
            public bool success { get; set; }
            public string message { get; set; }
        }

        public class Data
        {
            public string[] claims { get; set; }
            public string token { get; set; }
            public DateTime expiration { get; set; }
        }
    }
}
