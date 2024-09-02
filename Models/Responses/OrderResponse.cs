﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicApiTests.Models.Responses
{
    public class OrderResponse
    {
        public int Id { get; set; }
        public string OrderNo { get; set; }
        public int WorkpointId { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
