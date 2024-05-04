using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicApiTests.Dtos
{
    public class TokenMapper
    {
        public string token { get; set; }
        public DateTime expiration { get; set; }
    }
}
