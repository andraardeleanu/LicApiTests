﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicApiTests.Models.Responses
{
    public class ApiResponseResponse
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public string ValidationMessage { get; set; }
    }
}
