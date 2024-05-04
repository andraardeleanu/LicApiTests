using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicApiTests.Dtos
{
    public class WorkpointAllDataMapper
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string CreatedBy { get; set; }
        public int CompanyId { get; set; }
        public string Company { get; set; }
        public int Id { get; set; }
        public string Author { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
             
    }
}
